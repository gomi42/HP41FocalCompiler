using System;
using System.Collections.Generic;

namespace FocalCompiler
{
    public enum FctType
    {
        NoParam,
        R_0_101_Stack,
        R_0_14,
        R_0_15,
        R_0_9,
        R_0_55,
        R_0_99_A_J_Alpha1,
        R_0_99_A_J_Alpha2,
        XRom
    }

    /////////////////////////////////////////////////////////////

    public class OpCode
    {
        public String Mnemonic;

        public int Function;
        public FctType FctType;
        
        public int IndirectFunction;
        public bool Indirect;
        public bool IndirectOr;
        
        public int ShortFunction;
        public FctType ShortParamRange;

        public int AlphaFunction;

        ////////////////////////////////

        public OpCode (String Mnemonic, FctType LongFctType, int Function)
        {
            this.Mnemonic = Mnemonic;
            this.Function = Function;
            this.FctType = LongFctType;
            this.IndirectFunction = Function;
            this.Indirect = true;
            this.IndirectOr = false;
            this.ShortFunction = 0x00;
        }

        public OpCode (String Mnemonic, FctType LongFctType, int Function, FctType ShortFctType, int ShortOpCode)
        {
            this.Mnemonic = Mnemonic;
            this.Function = Function;
            this.FctType = LongFctType;
            this.IndirectFunction = Function;
            this.Indirect = true;
            this.IndirectOr = false;
            this.ShortFunction = ShortOpCode;
            this.ShortParamRange = ShortFctType;
        }

        public OpCode (String Mnemonic, FctType LongFctType, int Function, int IndirectFunction, bool IndirectOr, FctType ShortFctType, int ShortOpCode, int AlphaFunction)
        {
            this.Mnemonic = Mnemonic;
            this.Function = Function;
            this.FctType = LongFctType;
            this.IndirectFunction = IndirectFunction;
            this.Indirect = IndirectFunction != 0x00;
            this.IndirectOr = IndirectOr;
            this.ShortFunction = ShortOpCode;
            this.ShortParamRange = ShortFctType;
            this.AlphaFunction = AlphaFunction;
        }
    }

    /////////////////////////////////////////////////////////////

    class OpCodes
    {
        //command without parameter
        List<OpCode> OpCodeList = new List<OpCode>
        {
            new OpCode ("NULL",      FctType.NoParam, 0x00),
            new OpCode ("+",         FctType.NoParam, 0x40),
            new OpCode ("-",         FctType.NoParam, 0x41),
            new OpCode ("*",         FctType.NoParam, 0x42),
            new OpCode ("/",         FctType.NoParam, 0x43),
            new OpCode ("X<Y?",      FctType.NoParam, 0x44),
            new OpCode ("X>Y?",      FctType.NoParam, 0x45),
            new OpCode ("X<=Y?",     FctType.NoParam, 0x46),
            new OpCode ("S+",        FctType.NoParam, 0x47),
            new OpCode ("S-",        FctType.NoParam, 0x48),
            new OpCode ("HMS+",      FctType.NoParam, 0x49),
            new OpCode ("HMS-",      FctType.NoParam, 0x4a),
            new OpCode ("MOD",       FctType.NoParam, 0x4b),
            new OpCode ("%",         FctType.NoParam, 0x4c),
            new OpCode ("%CH",       FctType.NoParam, 0x4d),
            new OpCode ("P-R",       FctType.NoParam, 0x4e),
            new OpCode ("R-P",       FctType.NoParam, 0x4f),
            new OpCode ("LN",        FctType.NoParam, 0x50),
            new OpCode ("X^2",       FctType.NoParam, 0x51),
            new OpCode ("SQRT",      FctType.NoParam, 0x52),
            new OpCode ("Y^X",       FctType.NoParam, 0x53),
            new OpCode ("CHS",       FctType.NoParam, 0x54),
            new OpCode ("E^X",       FctType.NoParam, 0x55),
            new OpCode ("LOG",       FctType.NoParam, 0x56),
            new OpCode ("10^X",      FctType.NoParam, 0x57),
            new OpCode ("E^X-1",     FctType.NoParam, 0x58),
            new OpCode ("SIN",       FctType.NoParam, 0x59),
            new OpCode ("COS",       FctType.NoParam, 0x5a),
            new OpCode ("TAN",       FctType.NoParam, 0x5b),
            new OpCode ("ASIN",      FctType.NoParam, 0x5c),
            new OpCode ("ACOS",      FctType.NoParam, 0x5d),
            new OpCode ("ATAN",      FctType.NoParam, 0x5e),
            new OpCode ("DEC",       FctType.NoParam, 0x5f),
            new OpCode ("1/X",       FctType.NoParam, 0x60),
            new OpCode ("ABS",       FctType.NoParam, 0x61),
            new OpCode ("FACT",      FctType.NoParam, 0x62),
            new OpCode ("X#0?",      FctType.NoParam, 0x63),
            new OpCode ("X>0?",      FctType.NoParam, 0x64),
            new OpCode ("LN1+X",     FctType.NoParam, 0x65),
            new OpCode ("X<0?",      FctType.NoParam, 0x66),
            new OpCode ("X=0?",      FctType.NoParam, 0x67),
            new OpCode ("INT",       FctType.NoParam, 0x68),
            new OpCode ("FRC",       FctType.NoParam, 0x69),
            new OpCode ("D-R",       FctType.NoParam, 0x6a),
            new OpCode ("R-D",       FctType.NoParam, 0x6b),
            new OpCode ("HMS",       FctType.NoParam, 0x6c),
            new OpCode ("HR",        FctType.NoParam, 0x6d),
            new OpCode ("RND",       FctType.NoParam, 0x6e),
            new OpCode ("OCT",       FctType.NoParam, 0x6f),
            new OpCode ("CLS",       FctType.NoParam, 0x70),
            new OpCode ("X<>Y",      FctType.NoParam, 0x71),
            new OpCode ("PI",        FctType.NoParam, 0x72),
            new OpCode ("CLST",      FctType.NoParam, 0x73),
            new OpCode ("R^",        FctType.NoParam, 0x74),
            new OpCode ("RDN",       FctType.NoParam, 0x75),
            new OpCode ("LASTX",     FctType.NoParam, 0x76),
            new OpCode ("CLX",       FctType.NoParam, 0x77),
            new OpCode ("X=Y?",      FctType.NoParam, 0x78),
            new OpCode ("X#Y?",      FctType.NoParam, 0x79),
            new OpCode ("SIGN",      FctType.NoParam, 0x7a),
            new OpCode ("X<=0?",     FctType.NoParam, 0x7b),
            new OpCode ("MEAN",      FctType.NoParam, 0x7c),
            new OpCode ("SDEV",      FctType.NoParam, 0x7d),
            new OpCode ("AVIEW",     FctType.NoParam, 0x7e),
            new OpCode ("CLD",       FctType.NoParam, 0x7f),
            new OpCode ("DEG",       FctType.NoParam, 0x80),
            new OpCode ("RAD",       FctType.NoParam, 0x81),
            new OpCode ("GRAD",      FctType.NoParam, 0x82),
            new OpCode ("ENTER",     FctType.NoParam, 0x83),
            new OpCode ("ENTER^",     FctType.NoParam, 0x83),
            new OpCode ("STOP",      FctType.NoParam, 0x84),
            new OpCode ("RTN",       FctType.NoParam, 0x85),
            new OpCode ("BEEP",      FctType.NoParam, 0x86),
            new OpCode ("CLA",       FctType.NoParam, 0x87),
            new OpCode ("ASHF",      FctType.NoParam, 0x88),
            new OpCode ("PSE",       FctType.NoParam, 0x89),
            new OpCode ("CLRG",      FctType.NoParam, 0x8a),
            new OpCode ("AOFF",      FctType.NoParam, 0x8b),
            new OpCode ("AON",       FctType.NoParam, 0x8c),
            new OpCode ("OFF",       FctType.NoParam, 0x8d),
            new OpCode ("PROMPT",    FctType.NoParam, 0x8e),
            new OpCode ("ADV",       FctType.NoParam, 0x8f),
            
            new OpCode ("RCL",       FctType.R_0_101_Stack, 0x90, FctType.R_0_15, 0x20),
            new OpCode ("STO",       FctType.R_0_101_Stack, 0x91, FctType.R_0_15, 0x30),
            new OpCode ("ST+",       FctType.R_0_101_Stack, 0x92),
            new OpCode ("ST-",       FctType.R_0_101_Stack, 0x93),
            new OpCode ("ST*",       FctType.R_0_101_Stack, 0x94),
            new OpCode ("ST/",       FctType.R_0_101_Stack, 0x95),
            new OpCode ("ISG",       FctType.R_0_101_Stack, 0x96),
            new OpCode ("DSE",       FctType.R_0_101_Stack, 0x97),
            new OpCode ("VIEW",      FctType.R_0_101_Stack, 0x98),
            new OpCode ("SREG",      FctType.R_0_101_Stack, 0x99),
            new OpCode ("ASTO",      FctType.R_0_101_Stack, 0x9a),
            new OpCode ("ARCL",      FctType.R_0_101_Stack, 0x9b),
            new OpCode ("x<>",       FctType.R_0_101_Stack, 0xce),

            new OpCode ("FIX",       FctType.R_0_9, 0x9c),
            new OpCode ("SCI",       FctType.R_0_9, 0x9d),
            new OpCode ("ENG",       FctType.R_0_9, 0x9e),
            new OpCode ("TONE",      FctType.R_0_9, 0x9f),

            new OpCode ("SF",        FctType.R_0_55, 0xa8),
            new OpCode ("CF",        FctType.R_0_55, 0xa9),
            new OpCode ("FS?C",      FctType.R_0_55, 0xaa),
            new OpCode ("FC?C",      FctType.R_0_55, 0xab),
            new OpCode ("FS?",       FctType.R_0_55, 0xac),
            new OpCode ("FC?",       FctType.R_0_55, 0xad),

            new OpCode ("LBL",       FctType.R_0_99_A_J_Alpha1, 0xcf, 0x00, false, FctType.R_0_14,  0x01, 0xc0),
            new OpCode ("GTO",       FctType.R_0_99_A_J_Alpha2, 0xd0, 0xae, false, FctType.R_0_14,  0xb1, 0x1d),
            new OpCode ("XEQ",       FctType.R_0_99_A_J_Alpha2, 0xe0, 0xae, true,  FctType.NoParam, 0x00, 0x1e),
            
            new OpCode ("XROM",      FctType.XRom, 0xa0),
        };

        /////////////////////////////////////////////////////////////

        class CompareMnemonic : IComparer<OpCode>
        {
            public int Compare (OpCode x, OpCode y)
            {
                return String.Compare (x.Mnemonic, y.Mnemonic, true);
            }
        }

        /////////////////////////////////////////////////////////////

        CompareMnemonic MneComparer = new CompareMnemonic ();

        /////////////////////////////////////////////////////////////

        public OpCodes ()
        {
            OpCodeList.Sort (MneComparer);
        }

        /////////////////////////////////////////////////////////////

        public bool FindMnemonic (String Mnemonic, out OpCode OpCode)
        {
            OpCode = null;

            int Index = OpCodeList.BinarySearch (new OpCode (Mnemonic, FctType.NoParam, 0), MneComparer);

            if (Index < 0)
                return false;

            OpCode = OpCodeList[Index];
            
            return true;
        }
    }

}
