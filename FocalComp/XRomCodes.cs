// The build of FocalDecomp automatically copies this file from FocalComp
// Only modify the file in FocalComp!

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace FocalXRomCodes
{
    public class XRomCode
    {
        public String Mnemonic;
        public short    Rom;
        public short    Function;

        public XRomCode (String Mnemonic, short Rom, short Function)
        {
            this.Mnemonic = Mnemonic;
            this.Rom      = Rom;
            this.Function = Function;
        }
    }

    /////////////////////////////////////////////////////////////

    public class XRomCodes
    {
        List<XRomCode> XRomCodeList = new List<XRomCode>
        {
            //Extended I/O
            //-X_MASS_1A
            new XRomCode ("COPYFL",   23, 1),
            new XRomCode ("DIRX",     23, 2),
            new XRomCode ("FLLENG",   23, 3),
            new XRomCode ("FLTYPE",   23, 4),
            new XRomCode ("MCOPY",    23, 5),
            new XRomCode ("MCOPYPV",  23, 6),
            new XRomCode ("MVERIFY",  23, 7),
            
            //-X_EXT_FCN
            new XRomCode ("ALENGIO",  23, 9),
            new XRomCode ("ANUNDEL",  23, 10),
            new XRomCode ("ATOXL",    23, 11),
            new XRomCode ("ATOXR",    23, 12),
            new XRomCode ("ATOXX",    23, 13),
            new XRomCode ("XTOAL",    23, 14),
            new XRomCode ("XTOAR",    23, 15),
            new XRomCode ("X<>FIO",   23, 16),
            new XRomCode ("YTOAX",    23, 17),
            
            //-X_CTRL_FNS
            new XRomCode ("AID",      23, 19),
            new XRomCode ("CLRDEV",   23, 20),
            new XRomCode ("CLRLOOP",  23, 21),
            new XRomCode ("DEVL",     23, 22),
            new XRomCode ("DEVT",     23, 23),
            new XRomCode ("FINDAID",  23, 24),
            new XRomCode ("ID",       23, 25),
            new XRomCode ("INAC",     23, 26),
            new XRomCode ("INACL",    23, 27),
            new XRomCode ("INAE",     23, 28),
            new XRomCode ("INAN",     23, 29),
            new XRomCode ("INXB",     23, 30),
            new XRomCode ("INP",      23, 31),
            new XRomCode ("LOCK",     23, 32),
            new XRomCode ("NLOOP",    23, 33),
            new XRomCode ("NOTREM",   23, 34),
            new XRomCode ("OUTAC",    23, 35),
            new XRomCode ("OUTACL",   23, 36),
            new XRomCode ("OUTAE",    23, 37),
            new XRomCode ("OUTAN",    23, 38),
            new XRomCode ("OUTXB",    23, 39),
            new XRomCode ("OUTP",     23, 40),
            new XRomCode ("POLL",     23, 41),
            new XRomCode ("POLLD",    23, 42),
            new XRomCode ("POLLE",    23, 43),
            new XRomCode ("POLLUNC",  23, 44),
            new XRomCode ("RCLSEL",   23, 45),
            new XRomCode ("SRQ?",     23, 46),
            new XRomCode ("STAT",     23, 47),
            new XRomCode ("XFER",     23, 48),
            new XRomCode ("XFERC",    23, 49),
            new XRomCode ("XREFCL",   23, 50),
            new XRomCode ("XFERE",    23, 51),
            new XRomCode ("XFERN",    23, 52),
            
            //-ADV_CTL_FN
            new XRomCode ("ADROFF",   23, 54),
            new XRomCode ("ADRON",    23, 55),
            new XRomCode ("DDL",      23, 56),
            new XRomCode ("DDT",      23, 57),
            new XRomCode ("LAD",      23, 58),
            new XRomCode ("SEND",     23, 59),
            new XRomCode ("TAD",      23, 60),
            new XRomCode ("UNL",      23, 61),
            new XRomCode ("UNT",      23, 62),

            //EXT-Functions
            //-EXT_FCN_1B
            new XRomCode ("ALENG",    25, 1),
            new XRomCode ("ANUM",     25, 2),
            new XRomCode ("APPCHR",   25, 3),
            new XRomCode ("APPREC",   25, 4),
            new XRomCode ("ARCLREC",  25, 5),
            new XRomCode ("AROT",     25, 6),
            new XRomCode ("ATOX",     25, 7),
            new XRomCode ("CLFL",     25, 8),
            new XRomCode ("CLKEYS",   25, 9),
            new XRomCode ("CRFLAS",   25, 10),
            new XRomCode ("CRFLD",    25, 11),
            new XRomCode ("DELCHR",   25, 12),
            new XRomCode ("DELREC",   25, 13),
            new XRomCode ("EMDIR",    25, 14),
            new XRomCode ("FLSIZE",   25, 15),
            new XRomCode ("GETAS",    25, 16),
            new XRomCode ("GETKEY",   25, 17),
            new XRomCode ("GETP",     25, 18),
            new XRomCode ("GETR",     25, 19),
            new XRomCode ("GETREC",   25, 20),
            new XRomCode ("GETRX",    25, 21),
            new XRomCode ("GETSUB",   25, 22),
            new XRomCode ("GETX",     25, 23),
            new XRomCode ("INSCHR",   25, 24),
            new XRomCode ("INSREC",   25, 25),
            new XRomCode ("PASN",     25, 26),
            new XRomCode ("PCLPS",    25, 27),
            new XRomCode ("POSA",     25, 28),
            new XRomCode ("POSFL",    25, 29),
            new XRomCode ("PSIZE",    25, 30),
            new XRomCode ("PURFL",    25, 31),
            new XRomCode ("RCLFLAG",  25, 32),
            new XRomCode ("RCLPT",    25, 33),
            new XRomCode ("RCLPTA",   25, 34),
            new XRomCode ("REGMOVE",  25, 35),
            new XRomCode ("REGSWAP",  25, 36),
            new XRomCode ("SAVEAS",   25, 37),
            new XRomCode ("SAVEP",    25, 38),
            new XRomCode ("SAVER",    25, 39),
            new XRomCode ("SAVERX",   25, 40),
            new XRomCode ("SAVEX",    25, 41),
            new XRomCode ("SEEKPT",   25, 42),
            new XRomCode ("SEEKPTA",  25, 43),
            new XRomCode ("SIZE?",    25, 44),
            new XRomCode ("STOFLAG",  25, 45),
            new XRomCode ("X<>F",     25, 46),
            new XRomCode ("XTOA",     25, 47),
            
            //-CX EXT-Functions
            new XRomCode ("ASROOM",   25, 49),
            new XRomCode ("CLRGX",    25, 50),
            new XRomCode ("ED",       25, 51),
            new XRomCode ("EMDIRX",   25, 52),
            new XRomCode ("EMROOM",   25, 53),
            new XRomCode ("GETKEYX",  25, 54),
            new XRomCode ("RESZFL",   25, 55),
            new XRomCode ("SREG?",    25, 56),
            new XRomCode ("X=NN?",    25, 57),
            new XRomCode ("X#NN?",    25, 58),
            new XRomCode ("X<NN?",    25, 59),
            new XRomCode ("X<=NN?",   25, 60),
            new XRomCode ("X>NN?",    25, 61),
            new XRomCode ("X>=NN?",   25, 62),

            //Time
            //-TIME 2C
            new XRomCode ("ADATE",    26, 1),
            new XRomCode ("ALMCAT",   26, 2),
            new XRomCode ("ALMNOW",   26, 3),
            new XRomCode ("ATIME",    26, 4),
            new XRomCode ("ATIME24",  26, 5),
            new XRomCode ("CLK12",    26, 6),
            new XRomCode ("CLK24",    26, 7),
            new XRomCode ("CLKT",     26, 8),
            new XRomCode ("CLKTD",    26, 9),
            new XRomCode ("CLOCK",    26, 10),
            new XRomCode ("CORRECT",  26, 11),
            new XRomCode ("DATE",     26, 12),
            new XRomCode ("DATE+",    26, 13),
            new XRomCode ("DDAYS",    26, 14),
            new XRomCode ("DMY",      26, 15),
            new XRomCode ("DOW",      26, 16),
            new XRomCode ("MDY",      26, 17),
            new XRomCode ("RCLAF",    26, 18),
            new XRomCode ("RCLSW",    26, 19),
            new XRomCode ("RUNSW",    26, 20),
            new XRomCode ("SETAF",    26, 21),
            new XRomCode ("SETDATE",  26, 22),
            new XRomCode ("SETIME",   26, 23),
            new XRomCode ("SETSW",    26, 24),
            new XRomCode ("STOPSW",   26, 25),
            new XRomCode ("SW",       26, 26),
            new XRomCode ("T+X",      26, 27),
            new XRomCode ("TIME",     26, 28),
            new XRomCode ("XYZALM",   26, 29),

            //-CX TIME
            new XRomCode ("CLALMA",   26, 31),
            new XRomCode ("CLALMX",   26, 32),
            new XRomCode ("CLRALMS",  26, 33),
            new XRomCode ("RCLALM",   26, 34),
            new XRomCode ("SWPT",     26, 35),

            //HP-IL Mass storage functions
            new XRomCode ("CREATE",   28, 1),
            new XRomCode ("DIR",      28, 2),
            //gap
            new XRomCode ("PURGE",    28, 4),
            new XRomCode ("READA",    28, 5),
            new XRomCode ("READK",    28, 6),
            new XRomCode ("READP",    28, 7),
            new XRomCode ("READR",    28, 8),
            new XRomCode ("READRX",   28, 9),
            new XRomCode ("READS",    28, 10),
            new XRomCode ("READSUB",  28, 11),
            new XRomCode ("RENAME",   28, 12),
            new XRomCode ("SEC",      28, 13),
            new XRomCode ("SEEKR",    28, 14),
            new XRomCode ("UNSEC",    28, 15),
            new XRomCode ("VERIFY",   28, 16),
            new XRomCode ("WRTA",     28, 17),
            new XRomCode ("WRTK",     28, 18),
            new XRomCode ("WRTP",     28, 19),
            new XRomCode ("WRTPV",    28, 20),
            new XRomCode ("WRTR",     28, 21),
            new XRomCode ("WRTRX",    28, 22),
            new XRomCode ("WRTS",     28, 23),
            new XRomCode ("ZERO",     28, 24),
            
            //HP-IL Control Functions
            new XRomCode ("AUTOIO",   28, 27),
            new XRomCode ("FINDIO",   28, 28),
            new XRomCode ("INA",      28, 29),
            new XRomCode ("IND",      28, 30),
            new XRomCode ("INSTAT",   28, 31),
            new XRomCode ("LISTEN",   28, 32),
            new XRomCode ("LOCAL",    28, 33),
            new XRomCode ("MANIO",    28, 34),
            new XRomCode ("OUTA",     28, 35),
            new XRomCode ("PWRDN",    28, 36),
            new XRomCode ("PWRUP",    28, 37),
            new XRomCode ("REMOTE",   28, 38),
            new XRomCode ("SELECT",   28, 39),
            new XRomCode ("STOPIO",   28, 40),
            new XRomCode ("TRIGGER",  28, 41),
            
            //wand
            new XRomCode ("WNDDTA",  27, 1),
            new XRomCode ("WNDDTX",  27, 2),
            new XRomCode ("WNDLNK",  27, 3),
            new XRomCode ("WNDSUB",  27, 4),
            new XRomCode ("WNDSCN",  27, 5),
            new XRomCode ("WNDTST",  27, 6),
                
            //-HP 41Z	1	1
            new XRomCode ("W^1/Z",	1,	2),
            new XRomCode ("W^Z",	1,	3),
            new XRomCode ("X^1/Z",	1,	4),
            new XRomCode ("X^Z",	1,	5),
            new XRomCode ("Z+",	    1,	6),
            new XRomCode ("Z-", 	1,	7),
            new XRomCode ("Z*", 	1,	8),
            new XRomCode ("Z/", 	1,	9),
            new XRomCode ("Z^1/X",	1,	10),
            new XRomCode ("Z^2",	1,	11),
            new XRomCode ("Z^3", 	1,	12),
            new XRomCode ("Z^X", 	1,	13),
            new XRomCode ("Z=0?",	1,	14),
            new XRomCode ("Z=I?",	1,	15),
            new XRomCode ("Z=W?",	1,	16),
            new XRomCode ("Z=WR?",	1,	17),
            new XRomCode ("Z#0?",	1,	18),
            new XRomCode ("Z#W?",	1,	19),
            new XRomCode ("ZACOS",	1,	20),
            new XRomCode ("ZALOGm",	1,	21),
            new XRomCode ("ZASIN",	1,	22),
            new XRomCode ("ZATAN",	1,	23),
            new XRomCode ("ZCOS",	1,	24),
            new XRomCode ("ZEXP",	1,	25),
            new XRomCode ("ZHACOS",	1,	26),
            new XRomCode ("ZHASIN",	1,	27),
            new XRomCode ("ZHATAN",	1,	28),
            new XRomCode ("ZHCOS",	1,	29),
            new XRomCode ("ZHSIN",	1,	30),
            new XRomCode ("ZHTAN",	1,	31),
            new XRomCode ("ZIMAG?",	1,	32),
            new XRomCode ("ZIN?",	1,	33),
            new XRomCode ("ZINT?",	1,	34),
            new XRomCode ("ZINV",	1,	35),
            new XRomCode ("ZLN",	1,	36),
            new XRomCode ("ZLOG",	1,	37),
            new XRomCode ("ZNEG",	1,	38),
            new XRomCode ("ZOUT?",	1,	39),
            new XRomCode ("ZPI*",	1,	40),
            new XRomCode ("ZREAL?",	1,	41),
            new XRomCode ("ZRND",	1,	42),
            new XRomCode ("ZSIN",	1,	43),
            new XRomCode ("ZSQRT",	1,	44),
            new XRomCode ("ZTAN",	1,	45),
            new XRomCode ("ZUNIT?",	1,	46),
            new XRomCode ("-ZSTACK",1,	47),
            new XRomCode ("CLZ",	1,	48),
            new XRomCode ("CLZST",	1,	49),
            new XRomCode ("LASTZ",	1,	50),
            new XRomCode ("ZAVIEW",	1,	51),
            new XRomCode ("ZENTER^",1,	52),
            new XRomCode ("Z<>",  	1,	53),
            new XRomCode ("Z<>ST", 	1,	54),
            new XRomCode ("ZTRP",	1,	55),
            new XRomCode ("Z<>W",	1,	56),
            new XRomCode ("ZIMAG^",	1,	57),
            new XRomCode ("ZRCL", 	1,	58),
            new XRomCode ("ZRDN",	1,	59),
            new XRomCode ("ZREAL^",	1,	60),
            new XRomCode ("ZRPL^",	1,	61),
            new XRomCode ("ZRUP",	1,	62),
            new XRomCode ("ZSTO",	1,	63),
            new XRomCode ("ZVIEW", 	1,	64),

            new XRomCode ("^IM/AG",	4,	1),
            new XRomCode ("1/Z",	4,	2),
            new XRomCode ("e^Z",	4,	3),
            new XRomCode ("EIZ/IZ",	4,	4),
            new XRomCode ("NXTACS",	4,	5),
            new XRomCode ("NXTASN",	4,	6),
            new XRomCode ("NXTATN",	4,	7),
            new XRomCode ("NXTLN",	4,	8),
            new XRomCode ("NXTRTN",	4,	9),
            new XRomCode ("SQRTZ",	4,	10),
            new XRomCode ("Z*I",	4,	11),
            new XRomCode ("ZCHSX",	4,	12),
            new XRomCode ("ZGEU",	4,	13),
            new XRomCode ("ZK?YN",	4,	14),
            new XRomCode ("ZKBRD", 	4,	15),
            new XRomCode ("ZST+", 	4,	16),
            new XRomCode ("ZST-", 	4,	17),
            new XRomCode ("ZST*", 	4,	18),
            new XRomCode ("ZST/", 	4,	19),
            new XRomCode ("ZWLOG",	4,	20),
            new XRomCode ("-ZVECTOR",4,	21),
            new XRomCode ("POLAR",	4,	22),
            new XRomCode ("RECT",	4,	23),
            new XRomCode ("ZARG",	4,	24),
            new XRomCode ("ZCONJ",	4,	25),
            new XRomCode ("ZMOD",	4,	26),
            new XRomCode ("ZNORM",	4,	27),
            new XRomCode ("ZPOL",	4,	28),
            new XRomCode ("ZREC",	4,	29),
            new XRomCode ("ZSIGN",	4,	30),
            new XRomCode ("ZWANG",	4,	31),
            new XRomCode ("ZWCROSS",4,	32),
            new XRomCode ("ZWDET",	4,	33),
            new XRomCode ("ZWDIST",	4,	34),
            new XRomCode ("ZWDOT",	4,	35),
            new XRomCode ("ZWLINE",	4,	36),

            //-HL ZMATH	4	37
            new XRomCode ("ZAWL",	4,	38),
            new XRomCode ("ZBS#",	4,	39),
            new XRomCode ("ZCI",	4,	40),
            new XRomCode ("ZCRT",	4,	41),
            new XRomCode ("ZEI",	4,	42),
            new XRomCode ("ZERF",	4,	43),
            new XRomCode ("ZGAMMA",	4,	44),
            new XRomCode ("ZHCI",	4,	45),
            new XRomCode ("ZHGF",	4,	46),
            new XRomCode ("ZHSI",	4,	47),
            new XRomCode ("ZIBS",	4,	48),
            new XRomCode ("ZJBS",	4,	49),
            new XRomCode ("ZKBS",	4,	50),
            new XRomCode ("ZLI2",	4,	51),
            new XRomCode ("ZLIN",	4,	52),
            new XRomCode ("ZLNG",	4,	53),
            new XRomCode ("ZLRCH",	4,	54),
            new XRomCode ("ZPROOT",	4,	55),
            new XRomCode ("ZPSI",	4,	56),
            new XRomCode ("ZQRT",	4,  57),
            new XRomCode ("ZSHK1",	4,	58),
            new XRomCode ("ZSHK2",	4,	59),
            new XRomCode ("ZSI",	4,	60),
            new XRomCode ("ZSOLVE",	4,	61),
            new XRomCode ("ZWL",	4,	62),
            new XRomCode ("ZYBS",	4,	63),
            new XRomCode ("ZZETA",	4,	64),

            //-SNDMTH 2X2	3	0
            new XRomCode ("2^X-1",	3,	1),
            new XRomCode ("S1/N",	3,	2),
            new XRomCode ("SDGT",	3,	3),
            new XRomCode ("SN^X",	3,	4),
            new XRomCode ("AINT",	3,	5),
            new XRomCode ("ATAN2",	3,	6),
            new XRomCode ("BS>D",	3,	7),
            new XRomCode ("CBRT",	3,	8),
            new XRomCode ("CEIL",	3,	9),
            new XRomCode ("CHSYX",	3,	10),
            new XRomCode ("CROOT",	3,	11),
            new XRomCode ("CVIETA",	3,	12),
            new XRomCode ("D>BS",	3,	13),
            new XRomCode ("D>H",	3,	14),
            new XRomCode ("E3/E+",	3,	15),
            new XRomCode ("FLOOR",	3,	16),
            new XRomCode ("GMSLVR",	3,	17),
            new XRomCode ("GEU",	3,	18),
            new XRomCode ("H>D",	3,	19),
            new XRomCode ("HMS*",	3,	20),
            new XRomCode ("HMS/",	3,	21),
            new XRomCode ("LOGYX",	3,	22),
            new XRomCode ("MKEYS",	3,	23),
            new XRomCode ("P>R",	3,	24),
            new XRomCode ("QREM",	3,	25),
            new XRomCode ("QROOT",	3,	26),
            new XRomCode ("QROUT",	3,	27),
            new XRomCode ("R>P",	3,	28),
            new XRomCode ("R>S",	3,	29),
            new XRomCode ("S>R",	3,	30),
            new XRomCode ("STLINE",	3,	31),
            new XRomCode ("T>BS", 	3,	32),
            new XRomCode ("VMANT",	3,	33),
            new XRomCode ("X^3",	3,	34),
            new XRomCode ("X=1?",	3,	35),
            new XRomCode ("X=YR?",	3,	36),
            new XRomCode ("X>=0?",	3,	37),
            new XRomCode ("X>=Y?",	3,	38),
            new XRomCode ("Y^1/X",	3,	39),
            new XRomCode ("Y^^X",	3,	40),
            new XRomCode ("YX^",	3,	41),
            new XRomCode ("-FRC",	3,	42),
            new XRomCode ("D>F",	3,	43),
            new XRomCode ("F+", 	3,	44),
            new XRomCode ("F-",	    3,	45),
            new XRomCode ("F*",	    3,	46),
            new XRomCode ("F/", 	3,	47),
            new XRomCode ("FRC?",	3,	48),
            new XRomCode ("INT?",	3,	49),
            new XRomCode ("-HYP",	3,	50),
            new XRomCode ("HACOS",	3,	51),
            new XRomCode ("HASIN",	3,	52),
            new XRomCode ("HATAN",	3,	53),
            new XRomCode ("HCOS",	3,	54),
            new XRomCode ("HSIN",	3,	55),
            new XRomCode ("HTAN",	3,	56),
            new XRomCode ("-RCL",	3,	57),
            new XRomCode ("AIRCL", 	3,	58),
            new XRomCode ("RCL^", 	3,	59),
            new XRomCode ("RCL+", 	3,	60),
            new XRomCode ("RCL-",	3,	61),
            new XRomCode ("RCL*", 	3,	62),
            new XRomCode ("RCL/", 	3,	63),

            //-HL MATH	2	0
            new XRomCode ("1/GMF",	2,	1),
            new XRomCode ("SFL",	2,	2),
            new XRomCode ("SFL$",	2,	3),
            new XRomCode ("SFL#", 	2,	4),
            new XRomCode ("BETA",	2,	5),
            new XRomCode ("CHBAP",	2,	6),
            new XRomCode ("CI",	    2,	7),
            new XRomCode ("DHT",	2,	8),
            new XRomCode ("EI", 	2,	9),
            new XRomCode ("ENX",	2,	10),
            new XRomCode ("ERF",	2,	11),
            new XRomCode ("FFOUR",	2,	12),
            new XRomCode ("FINTG",	2,	13),
            new XRomCode ("FLOOP",	2,	14),
            new XRomCode ("FROOT",	2,	15),
            new XRomCode ("GAMMA",	2,	16),
            new XRomCode ("HCI",	2,	17),
            new XRomCode ("HGF+",	2,	18),
            new XRomCode ("HSI",	2,	19),
            new XRomCode ("IBS",	2,	20),
            new XRomCode ("ICBT",	2,	21),
            new XRomCode ("ICGM",	2,	22),
            new XRomCode ("IERF",	2,	23),
            new XRomCode ("IGMMA",	2,	24),
            new XRomCode ("JBS",	2,	25),
            new XRomCode ("KBS",	2,	26),
            new XRomCode ("LINX",	2,	27),
            new XRomCode ("LNGM",	2,	28),
            new XRomCode ("LOBACH",	2,	29),
            new XRomCode ("PSI",	2,	30),
            new XRomCode ("PSIN",	2,	31),
            new XRomCode ("SI", 	2,	32),
            new XRomCode ("SJBS",	2,	33),
            new XRomCode ("SYBS",	2,	34),
            new XRomCode ("TAYLOR",	2,	35),
            new XRomCode ("WL0",	2,	36),
            new XRomCode ("YBS",	2,	37),
            new XRomCode ("ZETA",	2,	38),
            new XRomCode ("ZETAX",	2,	39),
            new XRomCode ("ZOUT",	2,	40),
            new XRomCode ("-PB/STs",2,	41),
            new XRomCode ("%T", 	2,	42),
            new XRomCode ("CORR",	2,	43),
            new XRomCode ("COV",	2,	44),
            new XRomCode ("CRVF",	2,	45),
            new XRomCode ("CURVE",	2,	46),
            new XRomCode ("EVEN?",	2,	47),
            new XRomCode ("GCD",	2,	48),
            new XRomCode ("LCM",	2,	49),
            new XRomCode ("LR", 	2,	50),
            new XRomCode ("LRY",	2,	51),
            new XRomCode ("NCR",	2,	52),
            new XRomCode ("NPR",	2,	53),
            new XRomCode ("ODD?",	2,	54),
            new XRomCode ("PDF",	2,	55),
            new XRomCode ("PFCT",	2,	56),
            new XRomCode ("PRIME?",	2,	57),
            new XRomCode ("RAND",	2,	58),
            new XRomCode ("RGMAX",	2,	59),
            new XRomCode ("RGSORT",	2,	60),
            new XRomCode ("SEEDT",	2,	61),
            new XRomCode ("ST<>S",	2,	62),
            new XRomCode ("STSORT",	2,	63)
        };

        /////////////////////////////////////////////////////////////

        class CompareMnemonic : IComparer<XRomCode>
        {
            public int Compare (XRomCode x, XRomCode y)
            {
                return String.Compare (x.Mnemonic, y.Mnemonic, true);
            }
        }

        /////////////////////////////////////////////////////////////

        class CompareRomFct : IComparer<XRomCode>
        {
            public int Compare (XRomCode x, XRomCode y)
            {
                if (x.Rom == y.Rom)
                    return x.Function.CompareTo (y.Function);

                return x.Rom.CompareTo (y.Rom);
            }
        }

        /////////////////////////////////////////////////////////////

        IComparer<XRomCode> MneComparer = new CompareMnemonic ();

        /////////////////////////////////////////////////////////////

        public XRomCodes (bool sortMne)
        {
            if (sortMne)
            {
                MneComparer = new CompareMnemonic ();
            }
            else
            {
                MneComparer = new CompareRomFct ();
            }

            XRomCodeList.Sort (MneComparer);
        }

        /////////////////////////////////////////////////////////////

        public bool FindMnemonic (String Mnemonic, out XRomCode OpCode)
        {
            OpCode = null;

            int Index = XRomCodeList.BinarySearch (new XRomCode (Mnemonic, 0, 0), MneComparer);

            if (Index < 0)
                return false;

            OpCode = XRomCodeList[Index];
            
            return true;
        }

        /////////////////////////////////////////////////////////////

        public bool FindFunction (int Module, int Function, out XRomCode OpCode)
        {
            OpCode = null;

            int Index = XRomCodeList.BinarySearch (new XRomCode (String.Empty, (short)Module, (short)Function), MneComparer);

            if (Index < 0)
                return false;

            OpCode = XRomCodeList[Index];

            return true;
        }

        /////////////////////////////////////////////////////////////

        public void AddMnemonicsFromFile (string filename)
        {
            const int RegexIdxAll = 0;
            const int RegexIdxEmpty = 1;
            const int RegexIdxComment = 2;
            const int RegexIdxXRomDefinition = 3;
            const int RegexIdxFctNameQuoted = 6;
            const int RegexIdxFctName = 7;
            const int RegexIdxXRomNr = 8;
            const int RegexIdxFctNr = 9;

            try
            {
                StreamReader xromStream = new StreamReader (filename, System.Text.Encoding.ASCII);
                int lineNr = 0;
                Regex Parser = new Regex (@"(^\s*$)|(\s*;)|(\s*((""(.+)"")|(.+))\s*,\s*(\d+)\s*,\s*(\d+)\s*(;|$))", RegexOptions.IgnoreCase);

                string line = xromStream.ReadLine();

                while (line != null)
                {
                    Match match = Parser.Match (line);
                    line = xromStream.ReadLine();
                    lineNr++;

                    if (match.Groups[RegexIdxComment].Success)
                    {
                        //comment, do nothing
                    }
                    else if (match.Groups[RegexIdxEmpty].Success)
                    {
                        //empty line, do nothing
                    }
                    else if (match.Groups[RegexIdxXRomDefinition].Success)
                    {
                        string fctName;

                        if (match.Groups[RegexIdxFctNameQuoted].Success)
                        {
                            fctName = match.Groups[RegexIdxFctNameQuoted].Value;
                        }
                        else
                        {
                            fctName = match.Groups[RegexIdxFctName].Value;
                        }

                        string rom = match.Groups[RegexIdxXRomNr].Value;
                        string fct = match.Groups[RegexIdxFctNr].Value;

                        int romInt;

                        if (fctName.Length > 7)
                        {
                            Console.WriteLine ("Error in XRom file line {0}: wrong ROM name format", lineNr);
                            continue;
                        }

                        if (!int.TryParse (rom, out romInt))
                        {
                            Console.WriteLine ("Error in XRom file line {0}: wrong ROM number format", lineNr);
                            continue;
                        }

                        if (romInt < 0 || romInt >= 32)
                        {
                            Console.WriteLine ("Error in XRom file line {0}: ROM number out of range", lineNr);
                            continue;
                        }

                        int fctInt;

                        if (!int.TryParse (fct, out fctInt))
                        {
                            Console.WriteLine ("Error in XRom file line {0}: wrong function number format", lineNr);
                            continue;
                        }

                        if (fctInt < 0 || fctInt >= 64)
                        {
                            Console.WriteLine ("Error in XRom file line {0}: function number out of range", lineNr);
                            continue;
                        }

                        var newXrom = new XRomCode (fctName, (short)romInt, (short)fctInt);
                        XRomCodeList.Add (newXrom);
                    }
                    else
                    {
                        Console.WriteLine ("Error in XRom file line {0}: syntax error", lineNr);
                    }
                }

                xromStream.Close ();

                XRomCodeList.Sort (MneComparer);
            }
            catch(Exception e)
            {
            }
        }
    }
}
