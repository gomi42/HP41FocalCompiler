using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FocalDecompiler
{
    public class FocalDecomp
    {
        Dictionary<short, String> StackParamter;
        Dictionary<short, String> ShortLabelParamter;
        Dictionary<int, string> OpListT1; //noparam
        Dictionary<int, string> OpListT2; //one int
        Dictionary<int, string> OpListT3; //int or stack
        Dictionary<int, string> OpListT4; //int or stack
            
        void FillOpT1()
        {
            StackParamter = new Dictionary<short, string> ();

            StackParamter.Add (112, "T");
            StackParamter.Add (113, "Z");
            StackParamter.Add (114, "Y");
            StackParamter.Add (115, "X");
            StackParamter.Add (116, "L");
            StackParamter.Add (117, "M");
            StackParamter.Add (118, "N");
            StackParamter.Add (119, "O");
            StackParamter.Add (120, "P");
            StackParamter.Add (121, "Q");
            StackParamter.Add (122, "R");
            StackParamter.Add (123, "a");
            StackParamter.Add (124, "b");
            StackParamter.Add (125, "c");
            StackParamter.Add (126, "d");
            StackParamter.Add (127, "e");

            ShortLabelParamter = new Dictionary<short, string> ();

            ShortLabelParamter.Add (102, "A");
            ShortLabelParamter.Add (103, "B");
            ShortLabelParamter.Add (104, "C");
            ShortLabelParamter.Add (105, "D");
            ShortLabelParamter.Add (106, "E");
            ShortLabelParamter.Add (107, "F");
            ShortLabelParamter.Add (108, "G");
            ShortLabelParamter.Add (109, "H");
            ShortLabelParamter.Add (110, "I");
            ShortLabelParamter.Add (111, "J");
            ShortLabelParamter.Add (123, "a");
            ShortLabelParamter.Add (124, "b");
            ShortLabelParamter.Add (125, "c");
            ShortLabelParamter.Add (126, "d");
            ShortLabelParamter.Add (127, "e");
            
            
            OpListT1 = new Dictionary<int,string>();

            OpListT1.Add (0x00, "NULL"      );
            OpListT1.Add (0x1c, "CHS"       );
            OpListT1.Add (0x40, "+"         );
            OpListT1.Add (0x41, "-"         );
            OpListT1.Add (0x42, "*"         );
            OpListT1.Add (0x43, "/"         );
            OpListT1.Add (0x44, "X<Y?"      );
            OpListT1.Add (0x45, "X>Y?"      );
            OpListT1.Add (0x46, "X<=Y?"     );
            OpListT1.Add (0x47, "S+"        );
            OpListT1.Add (0x48, "S-"        );
            OpListT1.Add (0x49, "HMS+"      );
            OpListT1.Add (0x4a, "HMS-"      );
            OpListT1.Add (0x4b, "MOD"       );
            OpListT1.Add (0x4c, "%"         );
            OpListT1.Add (0x4d, "%CH"       );
            OpListT1.Add (0x4e, "P-R"       );
            OpListT1.Add (0x4f, "R-P"       );
            OpListT1.Add (0x50, "LN"        );
            OpListT1.Add (0x51, "X^2"       );
            OpListT1.Add (0x52, "SQRT"      );
            OpListT1.Add (0x53, "Y^X"       );
            OpListT1.Add (0x54, "CHS"       );
            OpListT1.Add (0x55, "E^X"       );
            OpListT1.Add (0x56, "LOG"       );
            OpListT1.Add (0x57, "10^X"      );
            OpListT1.Add (0x58, "E^X-1"     );
            OpListT1.Add (0x59, "SIN"       );
            OpListT1.Add (0x5a, "COS"       );
            OpListT1.Add (0x5b, "TAN"       );
            OpListT1.Add (0x5c, "ASIN"      );
            OpListT1.Add (0x5d, "ACOS"      );
            OpListT1.Add (0x5e, "ATAN"      );
            OpListT1.Add (0x5f, "DEC"       );
            OpListT1.Add (0x60, "1/X"       );
            OpListT1.Add (0x61, "ABS"       );
            OpListT1.Add (0x62, "FACT"      );
            OpListT1.Add (0x63, "X#0?"      );
            OpListT1.Add (0x64, "X>0?"      );
            OpListT1.Add (0x65, "LN1+X"     );
            OpListT1.Add (0x66, "X<0?"      );
            OpListT1.Add (0x67, "X=0"       );
            OpListT1.Add (0x68, "INT"       );
            OpListT1.Add (0x69, "FRC"       );
            OpListT1.Add (0x6a, "D-R"       );
            OpListT1.Add (0x6b, "R-D"       );
            OpListT1.Add (0x6c, "HMS"       );
            OpListT1.Add (0x6d, "HR"        );
            OpListT1.Add (0x6e, "RND"       );
            OpListT1.Add (0x6f, "OCT"       );
            OpListT1.Add (0x70, "CLS"       );
            OpListT1.Add (0x71, "X<>Y"      );
            OpListT1.Add (0x72, "PI"        );
            OpListT1.Add (0x73, "CLST"      );
            OpListT1.Add (0x74, "R^"        );
            OpListT1.Add (0x75, "RDN"       );
            OpListT1.Add (0x76, "LASTX"     );
            OpListT1.Add (0x77, "CLX"       );
            OpListT1.Add (0x78, "X=Y?"      );
            OpListT1.Add (0x79, "X#Y?"      );
            OpListT1.Add (0x7a, "SIGN"      );
            OpListT1.Add (0x7b, "X<=0?"     );
            OpListT1.Add (0x7c, "MEAN"      );
            OpListT1.Add (0x7d, "SDEV"      );
            OpListT1.Add (0x7e, "AVIEW"     );
            OpListT1.Add (0x7f, "CLD"       );
            OpListT1.Add (0x80, "DEG"       );
            OpListT1.Add (0x81, "RAD"       );
            OpListT1.Add (0x82, "GRAD"      );
            OpListT1.Add (0x83, "ENTER"     );
            OpListT1.Add (0x84, "STOP"      );
            OpListT1.Add (0x85, "RTN"       );
            OpListT1.Add (0x86, "BEEP"      );
            OpListT1.Add (0x87, "CLA"       );
            OpListT1.Add (0x88, "ASHF"      );
            OpListT1.Add (0x89, "PSE"       );
            OpListT1.Add (0x8a, "CLRG"      );
            OpListT1.Add (0x8b, "AOFF"      );
            OpListT1.Add (0x8c, "AON"       );
            OpListT1.Add (0x8d, "OFF"       );
            OpListT1.Add (0x8e, "PROMPT"    );
            OpListT1.Add (0x8f, "ADV");

            OpListT2 = new Dictionary<int,string>();

            OpListT2.Add (0x9c, "FIX");
            OpListT2.Add (0x9d, "SCI");
            OpListT2.Add (0x9e, "ENG");
            OpListT2.Add (0x9f, "TONE");
            OpListT2.Add (0xa8, "SF");
            OpListT2.Add (0xa9, "CF");
            OpListT2.Add (0xaa, "FS?C");
            OpListT2.Add (0xab, "FC?C");
            OpListT2.Add (0xac, "FS?");
            OpListT2.Add (0xad, "FC?");
            OpListT2.Add (0x90, "RCL");
            OpListT2.Add (0x91, "STO");
            OpListT2.Add (0x92, "ST+");
            OpListT2.Add (0x93, "ST-");
            OpListT2.Add (0x94, "ST*");
            OpListT2.Add (0x95, "ST/");
            OpListT2.Add (0x96, "ISG");
            OpListT2.Add (0x97, "DSE");
            OpListT2.Add (0x98, "VIEW");
            OpListT2.Add (0x99, "SREG");
            OpListT2.Add (0x9a, "ASTO");
            OpListT2.Add (0x9b, "ARCL");
            OpListT2.Add (0xce, "x<>");

            OpListT3 = new Dictionary<int, string> ();

            OpListT3.Add (0xd0, "GTO");
            OpListT3.Add (0xe0, "XEQ");

            OpListT4 = new Dictionary<int, string> ();

            OpListT4.Add (0x1d, "GTO");
            OpListT4.Add (0x1e, "XEQ");
        }

        public void Decompile (String InputFilename, String OutputFilename)
        {
            FileStream InFileStream;
            StreamWriter OutFileStream;

            try
            {
                InFileStream = new FileStream (InputFilename, FileMode.Open);
            }
            catch
            {
                Console.WriteLine (String.Format ("Cannot open intput file: {0}", InputFilename));
                return;
            }

            try
            {
                OutFileStream = new StreamWriter (OutputFilename, false, System.Text.Encoding.ASCII);
            }
            catch
            {
                Console.WriteLine (String.Format ("Cannot open output file: {0}", OutputFilename));
                return;
            }

            Console.WriteLine (String.Format ("Decompiling: {0}", InputFilename));

            FillOpT1 ();

            int ByteFromFile;
            byte Byte;
            string Mnemonic;
            bool HaveNextByte = false;
            int Line = 1;

            ByteFromFile = InFileStream.ReadByte ();

            while (ByteFromFile != -1)
            {
                if (ByteFromFile == 0x00)    //NULL
                {
                    ByteFromFile = InFileStream.ReadByte ();
                    continue;
                }

                if (OpListT1.TryGetValue (ByteFromFile, out Mnemonic)) //without parameter
                    OutFileStream.WriteLine (Mnemonic);
                else
                if (OpListT2.TryGetValue (ByteFromFile, out Mnemonic)) //number|stack or IND number|stack
                {
                    String Ind = String.Empty;

                    ByteFromFile = InFileStream.ReadByte ();

                    if ((ByteFromFile & 0x80) != 0)
                    {
                        ByteFromFile &= 0x7f;
                        Ind = "IND ";
                    }

                    if (ByteFromFile <= 101)
                        OutFileStream.WriteLine ("{0} {1}{2}", Mnemonic, Ind, ByteFromFile.ToString ());
                    else
                        OutFileStream.WriteLine ("{0} {1}{2}", Mnemonic, Ind, StackParamter[(short)ByteFromFile]);
                }
                else
                if ((ByteFromFile & 0xf0) == 0x20) //rcl number <= 15
                {
                    OutFileStream.WriteLine ("RCL {0}", (ByteFromFile & 0x0F).ToString ("D2"));
                }
                else
                if ((ByteFromFile & 0xf0) == 0x30) //sto number <= 15
                {
                    OutFileStream.WriteLine ("STO {0}", (ByteFromFile & 0x0F).ToString ("D2"));
                }
                else
                if ((ByteFromFile & 0xf0) == 0x00) //lbl number < 15
                {
                    OutFileStream.WriteLine ("LBL {0}", ((ByteFromFile & 0x0F) - 1).ToString ("D2"));
                }
                else
                if ((ByteFromFile & 0xf0) == 0xb0) //gto number < 15
                {
                    OutFileStream.WriteLine ("GTO {0}", ((ByteFromFile & 0x0F) - 1).ToString ("D2"));
                }
                else
                if (OpListT3.TryGetValue (ByteFromFile, out Mnemonic)) //gto, xeq [number > 15]
                {
                    ByteFromFile = InFileStream.ReadByte ();
                    ByteFromFile = InFileStream.ReadByte ();

                    if (ByteFromFile <= 101)
                        OutFileStream.WriteLine ("{0} {1}", Mnemonic, ByteFromFile.ToString ("D2"));
                    else
                        OutFileStream.WriteLine ("{0} {1}", Mnemonic, ShortLabelParamter[(short)ByteFromFile]);
                }
                else
                if (ByteFromFile == 0xcf) //lbl [number > 14]
                {
                    ByteFromFile = InFileStream.ReadByte ();

                    if (ByteFromFile <= 101)
                        OutFileStream.WriteLine ("LBL {0}", ByteFromFile.ToString ("D2"));
                    else
                        OutFileStream.WriteLine ("LBL {0}", ShortLabelParamter[(short)ByteFromFile]);
                }
                else
                if (ByteFromFile == 0xae) //gto, xeq ind ..
                {
                    ByteFromFile = InFileStream.ReadByte ();

                    if ((ByteFromFile & 0x80) == 0)
                        Mnemonic = "GTO";
                    else
                        Mnemonic = "XEQ";

                    ByteFromFile &= 0x7f;

                    if (ByteFromFile <= 101)
                        OutFileStream.WriteLine ("{0} IND {1}", Mnemonic, ByteFromFile.ToString ("D2"));
                    else
                        OutFileStream.WriteLine ("{0} IND {1}", Mnemonic, StackParamter[(short)ByteFromFile]);
                }
                else
                if ((ByteFromFile & 0xf8) == 0xa0) //xrom
                {
                    int Byte2;
                    int Module;
                    int Function;

                    Byte2 = InFileStream.ReadByte ();
                    Module = ((ByteFromFile & 0x07) << 2) | (Byte2 >> 6);
                    Function = Byte2 & 0x3f;

                    OutFileStream.WriteLine ("XROM {0},{1}", Module.ToString ("D2"), Function.ToString ("D2"));
                }
                else
                if ((ByteFromFile & 0xf0) == 0xc0) //lbl alpha
                {
                    int Len;
                    String Label = String.Empty;

                    ByteFromFile = InFileStream.ReadByte ();
                    Len = InFileStream.ReadByte ();
                    ByteFromFile = InFileStream.ReadByte ();

                    if ((Len & 0xf0) == 0xf0)
                    {
                        Len -= 0xf1;

                        while (Len-- > 0)
                        {
                            ByteFromFile = InFileStream.ReadByte ();
                            Label += (char)ByteFromFile;
                        }
                    
                        OutFileStream.WriteLine ("LBL \"{0}\"", Label);
                    }
                    else
                        OutFileStream.WriteLine ("END");
                }
                else
                if (OpListT4.TryGetValue (ByteFromFile, out Mnemonic)) //gto, xeq alpha
                {
                    int Len;
                    String Label = String.Empty;

                    Len = InFileStream.ReadByte () - 0xf0;

                    while (Len-- > 0)
                    {
                        ByteFromFile = InFileStream.ReadByte ();
                        Label += (char)ByteFromFile;
                    }

                    OutFileStream.WriteLine ("LBL \"{0}\"", Label);
                }
                else
                if ((ByteFromFile & 0xf0) == 0xf0) //alpha
                {
                    int Len;
                    String Label = String.Empty;
                    String Append = String.Empty;

                    Len = ByteFromFile & 0x0f;
                    ByteFromFile = InFileStream.ReadByte ();

                    if (ByteFromFile == 0x7f) //append
                    {
                        Append = ">";
                        ByteFromFile = InFileStream.ReadByte ();
                        Len--;
                    }

                    while (Len-- > 0)
                    {
                        Label += (char)ByteFromFile;
                        ByteFromFile = InFileStream.ReadByte ();
                    }

                    OutFileStream.WriteLine ("{0}\"{1}\"", Append, Label);
                }
                else
                if (ByteFromFile >= 0x10 && ByteFromFile <= 0x1c) //number
                {
                    do
                    {
                        if (ByteFromFile == 0x1b)
                            OutFileStream.Write ("E");
                        else
                        if (ByteFromFile == 0x1a)
                            OutFileStream.Write (".");
                        else
                        if (ByteFromFile == 0x1c)
                            OutFileStream.Write ("-");
                        else
                            OutFileStream.Write ("{0}", (char)(ByteFromFile - 0x10 + '0'));

                        ByteFromFile = InFileStream.ReadByte ();
                    }
                    while (ByteFromFile >= 0x10 && ByteFromFile <= 0x1c);

                    OutFileStream.WriteLine ();
                    HaveNextByte = true;
                }
                else
                    OutFileStream.WriteLine ("? {0}", ByteFromFile.ToString ("X2"));

                if (!HaveNextByte)
                    ByteFromFile = InFileStream.ReadByte ();

                HaveNextByte = false;
            }

            InFileStream.Close ();
            OutFileStream.Close ();
        }
    }
}
