using System;
using System.Collections.Generic;
using System.Text;
using FocalXRomCodes;

namespace FocalCompiler
{
    partial class Compiler
    {
        CompileResult CompileXRom (Token Token, ref int OutCodeLength, ref byte[] OutCode, out String ErrorMsg)
        {
            ErrorMsg = String.Empty;
            XRomCode XRomCode;

            if (!XRoms.FindMnemonic (Token.StringValue, out XRomCode))
            {
                return CompileResult.UnknowStatement;
            }

            OutCodeLength = 2;

            OutCode[0] = (byte)(0xA0 + ((byte)XRomCode.Rom >> 2));
            OutCode[1] = (byte)((((byte)XRomCode.Rom & 0x03) << 6) + (byte)XRomCode.Function);

            return CompileResult.Ok;
        }
    }
}
