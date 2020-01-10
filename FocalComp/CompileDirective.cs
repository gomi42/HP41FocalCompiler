using System;

namespace FocalCompiler
{
    partial class Compiler
    {
        CompileResult DoDirective (Token Token, ref int OutCodeLength, ref byte[] OutCode, out String ErrorMsg)
        {
            ErrorMsg = String.Empty;
            CompileResult Error = CompileResult.Ok;

            switch (Token.StringValue.ToLower())
            {
                case "define":
                {
                    String Define;

                    Lex.GetToken (ref Token);

                    if (Token.TokenType != Token.TokType.Id)
                    {
                        Error = CompileResult.CompileError;
                        ErrorMsg = String.Format ("Identifier expected \"{0}\"", Token.StringValue);
                        break;
                    }

                    Define = Token.StringValue;
                    Lex.GetToken (ref Token);

                    if (!( Token.TokenType == Token.TokType.Text
                        || Token.TokenType == Token.TokType.Letter
                        || Token.TokenType == Token.TokType.Int
                        || Token.TokenType == Token.TokType.Number))
                    {
                        Error = CompileResult.CompileError;
                        ErrorMsg = String.Format ("Unexpected type \"{0}\"", Token.StringValue);
                        break;
                    }

                    Lex.AddDefine (Define, Token);
                    break;
                }

                case "end":
                case ".end.":
                    OutCodeLength = 3;
                    OutCode[0] = 0xC0;
                    OutCode[1] = 0x00;
                    OutCode[2] = 0x0D;

                    EndProcessed = true;
                    break;

                default:
                    Error = CompileResult.UnknowStatement;
                    break;
            }

            return Error;
        }
    }
}
