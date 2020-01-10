using System;

namespace FocalCompiler
{
    partial class Compiler
    {
        OpCodes OpCodes = new OpCodes ();

        /////////////////////////////////////////////////////////////

        CompileResult CompileMnemonicType2 (OpCode OpCode, ref int OutCodeLength, ref byte[] OutCode, out String ErrorMsg)
        {
            CompileResult Error = CompileResult.Ok;
            ErrorMsg = String.Empty;
            Token Token = new Token ();

            Lex.GetToken (ref Token);

            switch (Token.TokenType)
            {
                case Token.TokType.Int:
                    if (OpCode.ShortParamRange == FctType.R_0_14 && 0 <= Token.IntValue && Token.IntValue <= 14)
                    {
                        OutCodeLength = 1;
                        OutCode[0] = (byte)(((byte)OpCode.ShortFunction + (byte)Token.IntValue) & 0xff);
                    }
                    else
                    if (OpCode.ShortParamRange == FctType.R_0_15 && 0 <= Token.IntValue && Token.IntValue <= 15)
                    {
                        OutCodeLength = 1;
                        OutCode[0] = (byte)(((byte)OpCode.ShortFunction | (byte)Token.IntValue) & 0xff);
                    }
                    else
                    if (0 <= Token.IntValue && Token.IntValue <= 101)
                    {
                        OutCodeLength = 2;
                        OutCode[0] = (byte)(OpCode.Function & 0xff);
                        OutCode[1] = (byte)(Token.IntValue & 0xff);
                    }
                    else
                    {
                        Error = CompileResult.CompileError;
                        ErrorMsg = String.Format ("Parameter out of range \"{0}\"", Token.StringValue);
                    }
                    break;

                case Token.TokType.Letter:
                {
                    short Value;

                    if (Parameter.GetStackParamter (Token.StringValue, out Value))
                    {
                        OutCodeLength = 2;
                        OutCode[0] = (byte)(OpCode.Function & 0xff);
                        OutCode[1] = (byte)(Value & 0xff);
                    }
                    else
                    {
                        Error = CompileResult.CompileError;
                        ErrorMsg = String.Format ("Wrong stack parameter \"{0}\"", Token.StringValue);
                    }
                    break;
                }

                case Token.TokType.Indirect:
                    Lex.GetToken (ref Token);

                    switch (Token.TokenType)
                    {
                        case Token.TokType.Int:
                            OutCodeLength = 2;
                            OutCode[0] = (byte)(OpCode.Function & 0xff);
                            OutCode[1] = (byte)((Token.IntValue & 0xff) | 0x80);
                            break;

                        case Token.TokType.Letter:
                        {
                            short Value;

                            if (Parameter.GetStackParamter (Token.StringValue, out Value))
                            {
                                OutCodeLength = 2;
                                OutCode[0] = (byte)(OpCode.Function & 0xff);
                                OutCode[1] = (byte)((Value & 0xff) | 0x80);
                            }
                            else
                            {
                                Error = CompileResult.CompileError;
                                ErrorMsg = String.Format ("Wrong stack parameter \"{0}\"", Token.StringValue);
                            }
                            break;
                        }

                    default:
                        Error = CompileResult.CompileError;
                        ErrorMsg = String.Format ("Wrong parameter type or parameter expected");
                        break;
                    }
                    break;
                        
                default:
                    Error = CompileResult.CompileError;
                    ErrorMsg = String.Format ("Wrong parameter type or parameter expected");
                    break;
            }

            return Error;
        }

        /////////////////////////////////////////////////////////////

        CompileResult CompileMnemonicType3 (OpCode OpCode, ref int OutCodeLength, ref byte[] OutCode, out String ErrorMsg)
        {
            CompileResult Error = CompileResult.Ok;
            ErrorMsg = String.Empty;
            Token Token = new Token ();

            Lex.GetToken (ref Token);

            switch (Token.TokenType)
            {
                case Token.TokType.Int:
                    if (0 <= Token.IntValue && Token.IntValue <= 9)
                    {
                        OutCodeLength = 2;
                        OutCode[0] = (byte)(OpCode.Function & 0xff);
                        OutCode[1] = (byte)(Token.IntValue & 0xff);
                    }
                    else
                    {
                        Error = CompileResult.CompileError;
                        ErrorMsg = String.Format ("Parameter out of range \"{0}\"", Token.StringValue);
                    }
                    break;

                case Token.TokType.Indirect:
                    Lex.GetToken (ref Token);

                    switch (Token.TokenType)
                    {
                        case Token.TokType.Int:
                            if (0 <= Token.IntValue && Token.IntValue <= 101)
                            {
                                OutCodeLength = 2;
                                OutCode[0] = (byte)(OpCode.IndirectFunction & 0xff);
                                OutCode[1] = (byte)(Token.IntValue | (byte)0x80);
                            }
                            else
                            {
                                Error = CompileResult.CompileError;
                                ErrorMsg = String.Format ("Parameter out of range \"{0}\"", Token.StringValue);
                            }
                            break;

                        case Token.TokType.Letter:
                        {
                            short Value;

                            if (Parameter.GetStackParamter (Token.StringValue, out Value))
                            {
                                OutCodeLength = 2;
                                OutCode[0] = (byte)(OpCode.IndirectFunction & 0xff);
                                OutCode[1] = (byte)(Value | (byte)0x80);
                            }
                            else
                            {
                                Error = CompileResult.CompileError;
                                ErrorMsg = String.Format ("Parameter out of range \"{0}\"", Token.StringValue);
                            }
                            break;
                        }

                        default:
                            Error = CompileResult.CompileError;
                            ErrorMsg = String.Format ("Wrong parameter type or parameter expected");
                            break;
                    }
                    break;

                default:
                    Error = CompileResult.CompileError;
                    ErrorMsg = String.Format ("Wronge parameter type or parameter out of range \"{0}\"", Token.StringValue);
                    break;
            }

            return Error;
        }

        /////////////////////////////////////////////////////////////

        CompileResult CompileMnemonicType4 (OpCode OpCode, ref int OutCodeLength, ref byte[] OutCode, out String ErrorMsg)
        {
            CompileResult Error = CompileResult.Ok;
            ErrorMsg = String.Empty;
            Token Token = new Token ();

            Lex.GetToken (ref Token);

            switch (Token.TokenType)
            {
                case Token.TokType.Int:
                    if (0 <= Token.IntValue && Token.IntValue <= 55)
                    {
                        OutCodeLength = 2;
                        OutCode[0] = (byte)(OpCode.Function & 0xff);
                        OutCode[1] = (byte)(Token.IntValue & 0xff);
                    }
                    else
                    {
                        Error = CompileResult.CompileError;
                        ErrorMsg = String.Format ("Wronge parameter type or parameter out of range \"{0}\"", Token.StringValue);
                    }
                    break;

                case Token.TokType.Indirect:
                    Lex.GetToken (ref Token);

                    switch (Token.TokenType)
                    {
                        case Token.TokType.Int:
                            if (0 <= Token.IntValue && Token.IntValue <= 101)
                            {
                                OutCodeLength = 2;
                                OutCode[0] = (byte)(OpCode.IndirectFunction & 0xff);
                                OutCode[1] = (byte)(Token.IntValue | (byte)0x80);
                            }
                            else
                            {
                                Error = CompileResult.CompileError;
                                ErrorMsg = String.Format ("Parameter out of range \"{0}\"", Token.StringValue);
                            }
                            break;

                        case Token.TokType.Letter:
                        {
                            short Value;

                            if (Parameter.GetStackParamter (Token.StringValue, out Value))
                            {
                                OutCodeLength = 2;
                                OutCode[0] = (byte)(OpCode.IndirectFunction & 0xff);
                                OutCode[1] = (byte)(Value | (byte)0x80);
                            }
                            else
                            {
                                Error = CompileResult.CompileError;
                                ErrorMsg = String.Format ("Parameter out of range \"{0}\"", Token.StringValue);
                            }
                            break;
                        }

                        default:
                            Error = CompileResult.CompileError;
                            ErrorMsg = String.Format ("Wrong parameter type or parameter expected");
                            break;
                    }
                    break;

                default:
                    Error = CompileResult.CompileError;
                    ErrorMsg = String.Format ("Wronge parameter type or parameter out of range \"{0}\"", Token.StringValue);
                    break;
            }

            return Error;
        }

        /////////////////////////////////////////////////////////////

        CompileResult CompileMnemonicType5 (OpCode OpCode, ref int OutCodeLength, ref byte[] OutCode, out String ErrorMsg)
        {
            CompileResult Error = CompileResult.Ok;
            ErrorMsg = String.Empty;
            Token Token = new Token ();

            Lex.GetToken (ref Token);

            switch (Token.TokenType)
            {
                case Token.TokType.Int:
                    if (OpCode.ShortParamRange == FctType.R_0_14 && 0 <= Token.IntValue && Token.IntValue <= 14)
                    {
                        OutCodeLength = 1;
                        OutCode[0] = (byte)(((byte)OpCode.ShortFunction + (byte)Token.IntValue) & 0xff);
                    }
                    else
                        if (0 <= Token.IntValue && Token.IntValue <= 101)
                        {
                            OutCodeLength = 2;
                            OutCode[0] = (byte)(OpCode.Function & 0xff);
                            OutCode[1] = (byte)(Token.IntValue & 0xff);
                        }
                        else
                        {
                            Error = CompileResult.CompileError;
                            ErrorMsg = String.Format ("Parameter out of range \"{0}\"", Token.StringValue);
                        }
                    break;

                case Token.TokType.Letter:
                {
                    short Value;

                    if (Parameter.GetShortLabelParamter (Token.StringValue, out Value))
                    {
                        OutCodeLength = 2;
                        OutCode[0] = (byte)(OpCode.Function & 0xff);
                        OutCode[1] = (byte)Value;
                    }
                    else
                    {
                        Error = CompileResult.CompileError;
                        ErrorMsg = String.Format ("Parameter out of range \"{0}\"", Token.StringValue);
                    }
                    break;
                }

                case Token.TokType.Text:
                    if (Token.StringValue.Length <= 14)
                    {
                        OutCode[0] = (byte)OpCode.AlphaFunction;
                        OutCode[1] = 0x00;
                        OutCode[2] = (byte)(0xF1 + Token.StringValue.Length);
                        OutCode[3] = 0x00;

                        OutCodeLength = 4;

                        foreach (char c in Token.StringValue)
                            OutCode[OutCodeLength++] = (byte)c;
                    }
                    else
                    {
                        Error = CompileResult.CompileError;
                        ErrorMsg = String.Format ("Parameter out of range \"{0}\"", Token.StringValue);
                    }
                    break;

                default:
                    Error = CompileResult.CompileError;
                    ErrorMsg = String.Format ("Wrong parameter type or parameter expected");
                    break;
            }

            return Error;
        }

        /////////////////////////////////////////////////////////////

        CompileResult CompileMnemonicType6 (OpCode OpCode, ref int OutCodeLength, ref byte[] OutCode, out String ErrorMsg)
        {
            CompileResult Error = CompileResult.Ok;
            ErrorMsg = String.Empty;
            Token Token = new Token ();

            Lex.GetToken (ref Token);

            switch (Token.TokenType)
            {
                case Token.TokType.Int:
                    if (OpCode.ShortParamRange == FctType.R_0_14 && 0 <= Token.IntValue && Token.IntValue <= 14)
                    {
                        OutCodeLength = 2;
                        OutCode[0] = (byte)(((byte)OpCode.ShortFunction + (byte)Token.IntValue) & 0xff);
                        OutCode[1] = 0x00;
                    }
                    else
                        if (0 <= Token.IntValue && Token.IntValue <= 101)
                        {
                            OutCodeLength = 3;
                            OutCode[0] = (byte)(OpCode.Function & 0xff);
                            OutCode[1] = (byte)0x00;
                            OutCode[2] = (byte)(Token.IntValue & 0xff);
                        }
                        else
                        {
                            Error = CompileResult.CompileError;
                            ErrorMsg = String.Format ("Parameter out of range \"{0}\"", Token.StringValue);
                        }
                    break;

                case Token.TokType.Letter:
                {
                    short Value;

                    if (Parameter.GetShortLabelParamter (Token.StringValue, out Value))
                    {
                        OutCodeLength = 3;
                        OutCode[0] = (byte)(OpCode.Function & 0xff);
                        OutCode[1] = (byte)0x00;
                        OutCode[2] = (byte)Value;
                    }
                    else
                    {
                        Error = CompileResult.CompileError;
                        ErrorMsg = String.Format ("Parameter out of range \"{0}\"", Token.StringValue);
                    }
                    break;
                }

                case Token.TokType.Text:
                    if (Token.StringValue.Length <= 14)
                    {
                        OutCode[0] = (byte)OpCode.AlphaFunction;
                        OutCode[1] = (byte)(0xF0 + Token.StringValue.Length);

                        OutCodeLength = 2;

                        foreach (char c in Token.StringValue)
                            OutCode[OutCodeLength++] = (byte)c;
                    }
                    else
                    {
                        Error = CompileResult.CompileError;
                        ErrorMsg = String.Format ("String too long \"{0}\"", Token.StringValue);
                    }
                    break;

                case Token.TokType.Indirect:
                    Lex.GetToken (ref Token);

                    switch (Token.TokenType)
                    {
                        case Token.TokType.Int:
                            if (0 <= Token.IntValue && Token.IntValue <= 101)
                            {
                                OutCodeLength = 2;
                                OutCode[0] = (byte)(OpCode.IndirectFunction & 0xff);
                                OutCode[1] = (byte)(Token.IntValue);

                                if (OpCode.IndirectOr)
                                    OutCode[1] |= (byte)0x80;
                            }
                            else
                            {
                                Error = CompileResult.CompileError;
                                ErrorMsg = String.Format ("Parameter out of range \"{0}\"", Token.StringValue);
                            }
                            break;

                        case Token.TokType.Letter:
                        {
                            short Value;

                            if (Parameter.GetStackParamter (Token.StringValue, out Value))
                            {
                                OutCodeLength = 2;
                                OutCode[0] = (byte)(OpCode.IndirectFunction & 0xff);
                                OutCode[1] = (byte)(Value);

                                if (OpCode.IndirectOr)
                                    OutCode[1] |= (byte)0x80;
                            }
                            else
                            {
                                Error = CompileResult.CompileError;
                                ErrorMsg = String.Format ("Parameter out of range \"{0}\"", Token.StringValue);
                            }
                            break;
                        }

                        default:
                            Error = CompileResult.CompileError;
                            ErrorMsg = String.Format ("Wrong parameter type or parameter expected");
                            break;
                    }
                    break;

                default:
                    Error = CompileResult.CompileError;
                    ErrorMsg = String.Format ("Wrong parameter type or parameter expected");
                    break;
            }

            return Error;
        }

        /////////////////////////////////////////////////////////////

        CompileResult CompileMnemonicType7 (OpCode OpCode, ref int OutCodeLength, ref byte[] OutCode, out String ErrorMsg)
        {
            CompileResult Error = CompileResult.Ok;
            ErrorMsg = String.Empty;
            Token Token = new Token ();

            int Rom;

            Lex.GetToken (ref Token);

            if (!(Token.TokenType == Token.TokType.Int && 0 <= Token.IntValue && Token.IntValue <= 31))
            {
                ErrorMsg = String.Format ("Parameter 1 out of range \"{0}\"", Token.StringValue);
                return CompileResult.CompileError;
            }

            Rom = Token.IntValue;
            Lex.GetToken (ref Token);

            if (Token.TokenType != Token.TokType.Komma)
            {
                ErrorMsg = String.Format ("',' expected instead of '{0}'", Token.StringValue);
                return CompileResult.CompileError;
            }

            Lex.GetToken (ref Token);

            if (!(Token.TokenType == Token.TokType.Int && 0 <= Token.IntValue && Token.IntValue <= 63))
            {
                ErrorMsg = String.Format ("Parameter 2 out of range \"{0}\"", Token.StringValue);
                return CompileResult.CompileError;
            }

            OutCodeLength = 2;

            OutCode[0] = (byte)(OpCode.Function + ((byte)Rom >> 2));
            OutCode[1] = (byte)((((byte)Rom & 0x03) << 6) + (byte)Token.IntValue);

            return Error;
        }

        /////////////////////////////////////////////////////////////

        CompileResult CompileMnemonic (Token Token, ref int OutCodeLength, ref byte[] OutCode, out String ErrorMsg)
        {
            CompileResult Error = CompileResult.Ok;
            ErrorMsg = String.Empty;
            OpCode OpCode;

            if (!OpCodes.FindMnemonic (Token.StringValue, out OpCode))
            {
                return CompileResult.UnknowStatement;
            }

            switch (OpCode.FctType)
            {
                case FctType.NoParam:
                    OutCodeLength = 1;
                    OutCode[0] = (byte)(OpCode.Function & 0xff);
                    break;

                case FctType.R_0_101_Stack:
                    Error = CompileMnemonicType2 (OpCode , ref OutCodeLength, ref OutCode, out ErrorMsg);
                    break;

                case FctType.R_0_9:
                    Error = CompileMnemonicType3 (OpCode , ref OutCodeLength, ref OutCode, out ErrorMsg);
                    break;

                case FctType.R_0_55:
                    Error = CompileMnemonicType4 (OpCode , ref OutCodeLength, ref OutCode, out ErrorMsg);
                    break;

                case FctType.R_0_99_A_J_Alpha1:
                    Error = CompileMnemonicType5 (OpCode , ref OutCodeLength, ref OutCode, out ErrorMsg);
                    break;

                case FctType.R_0_99_A_J_Alpha2:
                    Error = CompileMnemonicType6 (OpCode , ref OutCodeLength, ref OutCode, out ErrorMsg);
                    break;

                case FctType.XRom:
                    Error = CompileMnemonicType7 (OpCode , ref OutCodeLength, ref OutCode, out ErrorMsg);
                    break;

                default:
                    break;
            }

            return Error;
        }
    }
}
