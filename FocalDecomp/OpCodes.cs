using System;
using System.Collections.Generic;
using System.Text;

namespace FocalDecompiler
{
    class OpCodes
    {
        public enum FctType
        {
            Null,
            NoParam,
            R_0_14,
            GTO_0_14,
            Number,
            LabelAlpha,
            GTO_XEQ_Alpha,
            R_0_15,
            R_0_101_Stack,
            R_0_9,
            XRom,
            R_0_55,
            GTO_XEQ_Ind,
            LBL_0_99_A_J,
            R_0_99_A_J,
            Alpha
        }

        /////////////////////////////////////////////////////////////

        public class OpCode
        {
            public String Mnemonic;
            public FctType FctType;

            public OpCode (String Mnemonic, FctType ParamType)
            {
                this.Mnemonic = Mnemonic;
                this.FctType = ParamType;
            }
        }

        /////////////////////////////////////////////////////////////

        List<OpCode> OpCodeTable = new List<OpCode> ()
        {
            //00-0F
            new OpCode ("null",   FctType.Null),
            new OpCode ("LBL",    FctType.R_0_14),
            new OpCode ("LBL",    FctType.R_0_14),
            new OpCode ("LBL",    FctType.R_0_14),
            new OpCode ("LBL",    FctType.R_0_14),
            new OpCode ("LBL",    FctType.R_0_14),
            new OpCode ("LBL",    FctType.R_0_14),
            new OpCode ("LBL",    FctType.R_0_14),
            new OpCode ("LBL",    FctType.R_0_14),
            new OpCode ("LBL",    FctType.R_0_14),
            new OpCode ("LBL",    FctType.R_0_14),
            new OpCode ("LBL",    FctType.R_0_14),
            new OpCode ("LBL",    FctType.R_0_14),
            new OpCode ("LBL",    FctType.R_0_14),
            new OpCode ("LBL",    FctType.R_0_14),
            new OpCode ("LBL",    FctType.R_0_14),

            //10-1F
            new OpCode ("0",      FctType.Number),
            new OpCode ("1",      FctType.Number),
            new OpCode ("2",      FctType.Number),
            new OpCode ("3",      FctType.Number),
            new OpCode ("4",      FctType.Number),
            new OpCode ("5",      FctType.Number),
            new OpCode ("6",      FctType.Number),
            new OpCode ("7",      FctType.Number),
            new OpCode ("8",      FctType.Number),
            new OpCode ("9",      FctType.Number),
            new OpCode (".",      FctType.Number),
            new OpCode ("E",      FctType.Number),
            new OpCode ("-",      FctType.Number),
            new OpCode ("GTO",    FctType.GTO_XEQ_Alpha),
            new OpCode ("XEQ",    FctType.GTO_XEQ_Alpha),
            new OpCode ("space",  FctType.NoParam),
                                 
            //20-2F              
            new OpCode ("RCL",    FctType.R_0_15),
            new OpCode ("RCL",    FctType.R_0_15),
            new OpCode ("RCL",    FctType.R_0_15),
            new OpCode ("RCL",    FctType.R_0_15),
            new OpCode ("RCL",    FctType.R_0_15),
            new OpCode ("RCL",    FctType.R_0_15),
            new OpCode ("RCL",    FctType.R_0_15),
            new OpCode ("RCL",    FctType.R_0_15),
            new OpCode ("RCL",    FctType.R_0_15),
            new OpCode ("RCL",    FctType.R_0_15),
            new OpCode ("RCL",    FctType.R_0_15),
            new OpCode ("RCL",    FctType.R_0_15),
            new OpCode ("RCL",    FctType.R_0_15),
            new OpCode ("RCL",    FctType.R_0_15),
            new OpCode ("RCL",    FctType.R_0_15),
            new OpCode ("RCL",    FctType.R_0_15),

            //30-3F
            new OpCode ("STO",    FctType.R_0_15),
            new OpCode ("STO",    FctType.R_0_15),
            new OpCode ("STO",    FctType.R_0_15),
            new OpCode ("STO",    FctType.R_0_15),
            new OpCode ("STO",    FctType.R_0_15),
            new OpCode ("STO",    FctType.R_0_15),
            new OpCode ("STO",    FctType.R_0_15),
            new OpCode ("STO",    FctType.R_0_15),
            new OpCode ("STO",    FctType.R_0_15),
            new OpCode ("STO",    FctType.R_0_15),
            new OpCode ("STO",    FctType.R_0_15),
            new OpCode ("STO",    FctType.R_0_15),
            new OpCode ("STO",    FctType.R_0_15),
            new OpCode ("STO",    FctType.R_0_15),
            new OpCode ("STO",    FctType.R_0_15),
            new OpCode ("STO",    FctType.R_0_15),
                                 
            //40-4F              
            new OpCode ("+",      FctType.NoParam),
            new OpCode ("-",      FctType.NoParam),
            new OpCode ("*",      FctType.NoParam),
            new OpCode ("/",      FctType.NoParam),
            new OpCode ("X<Y?",   FctType.NoParam),
            new OpCode ("X>Y?",   FctType.NoParam),
            new OpCode ("X<=Y?",  FctType.NoParam),
            new OpCode ("S+",     FctType.NoParam),
            new OpCode ("S-",     FctType.NoParam),
            new OpCode ("HMS+",   FctType.NoParam),
            new OpCode ("HMS-",   FctType.NoParam),
            new OpCode ("MOD",    FctType.NoParam),
            new OpCode ("%",      FctType.NoParam),
            new OpCode ("%CH",    FctType.NoParam),
            new OpCode ("P-R",    FctType.NoParam),
            new OpCode ("R-P",    FctType.NoParam),

            //50-5F
            new OpCode ("LN",     FctType.NoParam),
            new OpCode ("X^2",    FctType.NoParam),
            new OpCode ("SQRT",   FctType.NoParam),
            new OpCode ("Y^X",    FctType.NoParam),
            new OpCode ("CHS",    FctType.NoParam),
            new OpCode ("E^X",    FctType.NoParam),
            new OpCode ("LOG",    FctType.NoParam),
            new OpCode ("10^X",   FctType.NoParam),
            new OpCode ("E^X-1",  FctType.NoParam),
            new OpCode ("SIN",    FctType.NoParam),
            new OpCode ("COS",    FctType.NoParam),
            new OpCode ("TAN",    FctType.NoParam),
            new OpCode ("ASIN",   FctType.NoParam),
            new OpCode ("ACOS",   FctType.NoParam),
            new OpCode ("ATAN",   FctType.NoParam),
            new OpCode ("DEC",    FctType.NoParam),
                                 
            //60-6F              
            new OpCode ("1/X",    FctType.NoParam),
            new OpCode ("ABS",    FctType.NoParam),
            new OpCode ("FACT",   FctType.NoParam),
            new OpCode ("X#0?",   FctType.NoParam),
            new OpCode ("X>0?",   FctType.NoParam),
            new OpCode ("LN1+X",  FctType.NoParam),
            new OpCode ("X<0?",   FctType.NoParam),
            new OpCode ("X=0?",   FctType.NoParam),
            new OpCode ("INT",    FctType.NoParam),
            new OpCode ("FRC",    FctType.NoParam),
            new OpCode ("D-R",    FctType.NoParam),
            new OpCode ("R-D",    FctType.NoParam),
            new OpCode ("HMS",    FctType.NoParam),
            new OpCode ("HR",     FctType.NoParam),
            new OpCode ("RND",    FctType.NoParam),
            new OpCode ("OCT",    FctType.NoParam),

            //70-7F
            new OpCode ("CLS",    FctType.NoParam),
            new OpCode ("X<>Y",   FctType.NoParam),
            new OpCode ("PI",     FctType.NoParam),
            new OpCode ("CLST",   FctType.NoParam),
            new OpCode ("R^",     FctType.NoParam),
            new OpCode ("RDN",    FctType.NoParam),
            new OpCode ("LASTX",  FctType.NoParam),
            new OpCode ("CLX",    FctType.NoParam),
            new OpCode ("X=Y?",   FctType.NoParam),
            new OpCode ("X#Y?",   FctType.NoParam),
            new OpCode ("SIGN",   FctType.NoParam),
            new OpCode ("X<=0?",  FctType.NoParam),
            new OpCode ("MEAN",   FctType.NoParam),
            new OpCode ("SDEV",   FctType.NoParam),
            new OpCode ("AVIEW",  FctType.NoParam),
            new OpCode ("CLD",    FctType.NoParam),

            //80-8F
            new OpCode ("DEG",    FctType.NoParam),
            new OpCode ("RAD",    FctType.NoParam),
            new OpCode ("GRAD",   FctType.NoParam),
            new OpCode ("ENTER^",  FctType.NoParam),
            new OpCode ("STOP",   FctType.NoParam),
            new OpCode ("RTN",    FctType.NoParam),
            new OpCode ("BEEP",   FctType.NoParam),
            new OpCode ("CLA",    FctType.NoParam),
            new OpCode ("ASHF",   FctType.NoParam),
            new OpCode ("PSE",    FctType.NoParam),
            new OpCode ("CLRG",   FctType.NoParam),
            new OpCode ("AOFF",   FctType.NoParam),
            new OpCode ("AON",    FctType.NoParam),
            new OpCode ("OFF",    FctType.NoParam),
            new OpCode ("PROMPT", FctType.NoParam),
            new OpCode ("ADV",    FctType.NoParam),

            //90-9F
            new OpCode ("RCL",    FctType.R_0_101_Stack),
            new OpCode ("STO",    FctType.R_0_101_Stack),
            new OpCode ("ST+",    FctType.R_0_101_Stack),
            new OpCode ("ST-",    FctType.R_0_101_Stack),
            new OpCode ("ST*",    FctType.R_0_101_Stack),
            new OpCode ("ST/",    FctType.R_0_101_Stack),
            new OpCode ("ISG",    FctType.R_0_101_Stack),
            new OpCode ("DSE",    FctType.R_0_101_Stack),
            new OpCode ("VIEW",   FctType.R_0_101_Stack),
            new OpCode ("SREG",   FctType.R_0_101_Stack),
            new OpCode ("ASTO",   FctType.R_0_101_Stack),
            new OpCode ("ARCL",   FctType.R_0_101_Stack),
            new OpCode ("FIX",    FctType.R_0_9),
            new OpCode ("SCI",    FctType.R_0_9),
            new OpCode ("ENG",    FctType.R_0_9),
            new OpCode ("TONE",   FctType.R_0_9),

            //A0-AF
            new OpCode ("XROM",   FctType.XRom),
            new OpCode ("XROM",   FctType.XRom),
            new OpCode ("XROM",   FctType.XRom),
            new OpCode ("XROM",   FctType.XRom),
            new OpCode ("XROM",   FctType.XRom),
            new OpCode ("XROM",   FctType.XRom),
            new OpCode ("XROM",   FctType.XRom),
            new OpCode ("XROM",   FctType.XRom),
            new OpCode ("SF",     FctType.R_0_55),
            new OpCode ("CF",     FctType.R_0_55),
            new OpCode ("FS?C",   FctType.R_0_55),
            new OpCode ("FC?C",   FctType.R_0_55),
            new OpCode ("FS?",    FctType.R_0_55),
            new OpCode ("FC?",    FctType.R_0_55),
            new OpCode ("gtoxeqind", FctType.GTO_XEQ_Ind),
            new OpCode ("spare",  FctType.NoParam),

            //B0-BF
            new OpCode ("SPARE",  FctType.NoParam),
            new OpCode ("GTO",    FctType.GTO_0_14),
            new OpCode ("GTO",    FctType.GTO_0_14),
            new OpCode ("GTO",    FctType.GTO_0_14),
            new OpCode ("GTO",    FctType.GTO_0_14),
            new OpCode ("GTO",    FctType.GTO_0_14),
            new OpCode ("GTO",    FctType.GTO_0_14),
            new OpCode ("GTO",    FctType.GTO_0_14),
            new OpCode ("GTO",    FctType.GTO_0_14),
            new OpCode ("GTO",    FctType.GTO_0_14),
            new OpCode ("GTO",    FctType.GTO_0_14),
            new OpCode ("GTO",    FctType.GTO_0_14),
            new OpCode ("GTO",    FctType.GTO_0_14),
            new OpCode ("GTO",    FctType.GTO_0_14),
            new OpCode ("GTO",    FctType.GTO_0_14),
            new OpCode ("GTO",    FctType.GTO_0_14),

            //C0-CF
            new OpCode ("LBL",    FctType.LabelAlpha),
            new OpCode ("LBL",    FctType.LabelAlpha),
            new OpCode ("LBL",    FctType.LabelAlpha),
            new OpCode ("LBL",    FctType.LabelAlpha),
            new OpCode ("LBL",    FctType.LabelAlpha),
            new OpCode ("LBL",    FctType.LabelAlpha),
            new OpCode ("LBL",    FctType.LabelAlpha),
            new OpCode ("LBL",    FctType.LabelAlpha),
            new OpCode ("LBL",    FctType.LabelAlpha),
            new OpCode ("LBL",    FctType.LabelAlpha),
            new OpCode ("LBL",    FctType.LabelAlpha),
            new OpCode ("LBL",    FctType.LabelAlpha),
            new OpCode ("LBL",    FctType.LabelAlpha),
            new OpCode ("LBL",    FctType.LabelAlpha),
            new OpCode ("x<>",    FctType.R_0_101_Stack),
            new OpCode ("LBL",    FctType.LBL_0_99_A_J),

            //D0-DF
            new OpCode ("GTO",    FctType.R_0_99_A_J),
            new OpCode ("GTO",    FctType.R_0_99_A_J),
            new OpCode ("GTO",    FctType.R_0_99_A_J),
            new OpCode ("GTO",    FctType.R_0_99_A_J),
            new OpCode ("GTO",    FctType.R_0_99_A_J),
            new OpCode ("GTO",    FctType.R_0_99_A_J),
            new OpCode ("GTO",    FctType.R_0_99_A_J),
            new OpCode ("GTO",    FctType.R_0_99_A_J),
            new OpCode ("GTO",    FctType.R_0_99_A_J),
            new OpCode ("GTO",    FctType.R_0_99_A_J),
            new OpCode ("GTO",    FctType.R_0_99_A_J),
            new OpCode ("GTO",    FctType.R_0_99_A_J),
            new OpCode ("GTO",    FctType.R_0_99_A_J),
            new OpCode ("GTO",    FctType.R_0_99_A_J),
            new OpCode ("GTO",    FctType.R_0_99_A_J),
            new OpCode ("GTO",    FctType.R_0_99_A_J),

            //E0-EF
            new OpCode ("XEQ",    FctType.R_0_99_A_J),
            new OpCode ("XEQ",    FctType.R_0_99_A_J),
            new OpCode ("XEQ",    FctType.R_0_99_A_J),
            new OpCode ("XEQ",    FctType.R_0_99_A_J),
            new OpCode ("XEQ",    FctType.R_0_99_A_J),
            new OpCode ("XEQ",    FctType.R_0_99_A_J),
            new OpCode ("XEQ",    FctType.R_0_99_A_J),
            new OpCode ("XEQ",    FctType.R_0_99_A_J),
            new OpCode ("XEQ",    FctType.R_0_99_A_J),
            new OpCode ("XEQ",    FctType.R_0_99_A_J),
            new OpCode ("XEQ",    FctType.R_0_99_A_J),
            new OpCode ("XEQ",    FctType.R_0_99_A_J),
            new OpCode ("XEQ",    FctType.R_0_99_A_J),
            new OpCode ("XEQ",    FctType.R_0_99_A_J),
            new OpCode ("XEQ",    FctType.R_0_99_A_J),
            new OpCode ("XEQ",    FctType.R_0_99_A_J),

            //F0-FF
            new OpCode ("alpha",  FctType.Alpha),
            new OpCode ("alpha",  FctType.Alpha),
            new OpCode ("alpha",  FctType.Alpha),
            new OpCode ("alpha",  FctType.Alpha),
            new OpCode ("alpha",  FctType.Alpha),
            new OpCode ("alpha",  FctType.Alpha),
            new OpCode ("alpha",  FctType.Alpha),
            new OpCode ("alpha",  FctType.Alpha),
            new OpCode ("alpha",  FctType.Alpha),
            new OpCode ("alpha",  FctType.Alpha),
            new OpCode ("alpha",  FctType.Alpha),
            new OpCode ("alpha",  FctType.Alpha),
            new OpCode ("alpha",  FctType.Alpha),
            new OpCode ("alpha",  FctType.Alpha),
            new OpCode ("alpha",  FctType.Alpha),
            new OpCode ("alpha",  FctType.Alpha),
        };

        public OpCode GetOpCodeInfo (int OpCode)
        {
            return OpCodeTable[OpCode];
        }
    }
}
