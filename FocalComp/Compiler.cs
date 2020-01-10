using System;
using FocalXRomCodes;

namespace FocalCompiler
{
    public enum CompileResult
    {
        Ok,
        CompileError,
        UnknowStatement
    }

    partial class Compiler
    {
        bool EndProcessed = false;
        XRomCodes XRoms = new XRomCodes (true);
        Lex Lex = new Lex ();
        Parameter Parameter = new Parameter ();

        /////////////////////////////////////////////////////////////

        public bool IsEndDetected
        {
            get
            {
                return EndProcessed;
            }
        }

        /////////////////////////////////////////////////////////////

        public void SetXromFile (string filename)
        {
            XRoms.AddMnemonicsFromFile (filename);
        }

        /////////////////////////////////////////////////////////////

        private CompileResult CompileId (Token Token, ref int OutCodeLength, ref byte[] OutCode, out String ErrorMsg)
        {
            ErrorMsg = "";
            CompileResult Res;

            // 1: check standard mnemonic
            Res = CompileMnemonic (Token, ref OutCodeLength, ref OutCode, out ErrorMsg);

            if (Res != CompileResult.UnknowStatement)
                return Res;
                    
            // 2: check XROM mnemonics
            Res = CompileXRom (Token, ref OutCodeLength, ref OutCode, out ErrorMsg);

            if (Res != CompileResult.UnknowStatement)
                return Res;

            // 3: check directive
            Res = DoDirective (Token, ref OutCodeLength, ref OutCode, out ErrorMsg);

            if (Res != CompileResult.UnknowStatement)
                return Res;

            ErrorMsg = String.Format ("Unknown statement \"{0}\"", Token.StringValue);
            return CompileResult.UnknowStatement;
        }

        /////////////////////////////////////////////////////////////

        public bool CompileEnd (ref int OutCodeLength, ref byte[] OutCode)
        {
            string errorMsg;

            return Compile (".END.", ref OutCodeLength, ref OutCode, out errorMsg);
        }

        /////////////////////////////////////////////////////////////

        public bool Compile (String Line, ref int OutCodeLength, ref byte [] OutCode, out String ErrorMsg)
        {
            bool Error = false;
            ErrorMsg = "";
            Token Token = new Token ();

            Lex.GetFirstToken (Line, ref Token);

            if (EndProcessed)
            {
                switch (Token.TokenType)
                {
                    case Token.TokType.Eol:
                    case Token.TokType.Comment:
                        return false;
                    
                    default:
                        ErrorMsg = "Statement after .END. detected";
                        return true;
                }
            }

            switch (Token.TokenType)
            {
                case Token.TokType.Id:
                    if (CompileId (Token, ref OutCodeLength, ref OutCode, out ErrorMsg) != CompileResult.Ok)
                        Error = true;

                    break;
                
                case Token.TokType.Append:
                    if (CompileTextAppend (Token, ref OutCodeLength, ref OutCode, out ErrorMsg) != CompileResult.Ok)
                        Error = true;

                    break;

                case Token.TokType.Text:
                    if (CompileText (Token, ref OutCodeLength, ref OutCode, out ErrorMsg) != CompileResult.Ok)
                        Error = true;

                    break;

                case Token.TokType.Int:
                case Token.TokType.Number:
                    if (CompileNumber (Token, ref OutCodeLength, ref OutCode, out ErrorMsg) != CompileResult.Ok)
                        Error = true;

                    break;

                case Token.TokType.Eol:
                case Token.TokType.Comment:
                    break;

                default:
                    Error = true;
                    ErrorMsg = String.Format ("Unknown statement \"{0}\"", Token.StringValue);
                    break;
            }

            if (!Error)
            {
                Lex.GetToken (ref Token);

                if (Token.TokenType != Token.TokType.Eol && Token.TokenType != Token.TokType.Comment)
                {
                    Error = true;
                    ErrorMsg = String.Format ("Unexpected parameter \"{0}\"", Token.StringValue);
                }
            }

            return Error;
        }
    }
}
