using System;
using System.Collections.Generic;
using System.Text;

namespace FocalCompiler
{
    partial class Compiler
    {
        Dictionary<char, char> CharConv = new Dictionary<char, char> ();

        private void InitCharConv()
        {
            CharConv.Add ('|', (char)0x21);
        }

        CompileResult CompileTextAppend (Token Token, ref int OutCodeLength, ref byte[] OutCode, out String ErrorMsg)
        {
            ErrorMsg = String.Empty;

            Lex.GetToken (ref Token);

            if (Token.TokenType != Token.TokType.Text)
            {
                ErrorMsg = String.Format ("Text expected \"{0}\"", Token.StringValue);
                return CompileResult.CompileError;
            }

            return CompileText (Token, ref OutCodeLength, ref OutCode, out ErrorMsg, true);
        }

        /////////////////////////////////////////////////////////////

        CompileResult CompileText (Token Token, ref int OutCodeLength, ref byte[] OutCode, out String ErrorMsg, bool Append = false)
        {
            CompileResult Error = CompileResult.Ok;
            ErrorMsg = String.Empty;
            int Len = Token.StringValue.Length;

            if (Append)
                Len++;

            if (Len <= 15)
            {
                OutCode[0] = (byte)(0xF0 + Len);

                OutCodeLength = 1;

                if (Append)
                    OutCode[OutCodeLength++] = (byte)0x7f;  //append

                foreach (char c in Token.StringValue)
                {
                    OutCode[OutCodeLength++] = (byte)c;
                }
            }
            else
            {
                Error = CompileResult.CompileError;
                ErrorMsg = String.Format ("String to too long \"{0}\"", Token.StringValue);
            }

            return Error;
        }

        /////////////////////////////////////////////////////////////

        CompileResult CompileNumber (Token Token, ref int OutCodeLength, ref byte[] OutCode, out String ErrorMsg)
        {
            CompileResult Error = CompileResult.Ok;
            ErrorMsg = String.Empty;

            OutCodeLength = 0;

            foreach (char c in Token.StringValue)
            {
                if (c == '-')
                    OutCode[OutCodeLength] = 0x1C;
                else if (c == 'E' || c == 'e')
                    OutCode[OutCodeLength] = 0x1B;
                else if (c == '.')
                    OutCode[OutCodeLength] = 0x1A;
                else
                    OutCode[OutCodeLength] = (byte)((byte)0x10 + (byte)c - (byte)'0');

                OutCodeLength++;
            }

            return Error;
        }
    }
}
