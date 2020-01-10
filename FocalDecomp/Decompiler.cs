using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;
using FocalXRomCodes;

namespace FocalDecompiler
{
    public class FocalDecomp
    {
        Dictionary<short, String> StackParamter;
        Dictionary<short, String> ShortLabelParamter;

        void InitParameter()
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

            ShortLabelParamter.Add (112, "T");
            ShortLabelParamter.Add (113, "Z");
            ShortLabelParamter.Add (114, "Y");
            ShortLabelParamter.Add (115, "X");
            ShortLabelParamter.Add (116, "L");
            ShortLabelParamter.Add (117, "M");
            ShortLabelParamter.Add (118, "N");
            ShortLabelParamter.Add (119, "O");
            ShortLabelParamter.Add (120, "P");
            ShortLabelParamter.Add (121, "Q");
            ShortLabelParamter.Add (122, "R");

            ShortLabelParamter.Add (123, "a");
            ShortLabelParamter.Add (124, "b");
            ShortLabelParamter.Add (125, "c");
            ShortLabelParamter.Add (126, "d");
            ShortLabelParamter.Add (127, "e");
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

            InitParameter ();

            ///////////////////////////////

            int ByteFromFile;
            string Mnemonic;
            bool HaveNextByte = false;
            OpCodes OpCodes = new FocalDecompiler.OpCodes ();
            XRomCodes XRomCodes = new XRomCodes (false);

            string exeFilename = Assembly.GetExecutingAssembly ().Location;
            XRomCodes.AddMnemonicsFromFile (Path.Combine (Path.GetDirectoryName (exeFilename), "XRomCodes.txt"));

            ByteFromFile = InFileStream.ReadByte ();

            int[] dump = new int[50];
            int dumpidx = 0;

            try
            {
                while (ByteFromFile != -1)
                {
                    dumpidx = 0;
                    dump[dumpidx++] = ByteFromFile;

                    OpCodes.OpCode OpCode = OpCodes.GetOpCodeInfo (ByteFromFile);

                    switch (OpCode.FctType)
                    {
                        case FocalDecompiler.OpCodes.FctType.Null:
                            break;

                        case FocalDecompiler.OpCodes.FctType.NoParam:
                            OutFileStream.WriteLine (OpCode.Mnemonic);
                            break;

                        case FocalDecompiler.OpCodes.FctType.R_0_9:
                            {
                                String Ind = String.Empty;

                                ByteFromFile = InFileStream.ReadByte ();
                                dump[dumpidx++] = ByteFromFile;

                                if ((ByteFromFile & 0x80) != 0)
                                {
                                    ByteFromFile &= 0x7f;
                                    Ind = "IND ";
                                }

                                if (ByteFromFile <= 101)
                                    OutFileStream.WriteLine ("{0,-4} {1}{2}", OpCode.Mnemonic, Ind, ByteFromFile.ToString ("D1"));
                                else
                                    OutFileStream.WriteLine ("{0,-4} {1}{2}", OpCode.Mnemonic, Ind, StackParamter[(short)ByteFromFile]);

                                break;
                            }

                        case FocalDecompiler.OpCodes.FctType.R_0_55:
                        case FocalDecompiler.OpCodes.FctType.R_0_101_Stack:
                            {
                                String Ind = String.Empty;

                                ByteFromFile = InFileStream.ReadByte ();
                                dump[dumpidx++] = ByteFromFile;

                                if ((ByteFromFile & 0x80) != 0)
                                {
                                    ByteFromFile &= 0x7f;
                                    Ind = "IND ";
                                }

                                if (ByteFromFile <= 101)
                                    OutFileStream.WriteLine ("{0,-4} {1}{2}", OpCode.Mnemonic, Ind, ByteFromFile.ToString ("D2"));
                                else
                                    OutFileStream.WriteLine ("{0,-4} {1}{2}", OpCode.Mnemonic, Ind, StackParamter[(short)ByteFromFile]);

                                break;
                            }

                        case FocalDecompiler.OpCodes.FctType.R_0_15:
                            OutFileStream.WriteLine ("{0,-4} {1}", OpCode.Mnemonic, (ByteFromFile & 0x0F).ToString ("D2"));
                            break;

                        case FocalDecompiler.OpCodes.FctType.R_0_14:
                            OutFileStream.WriteLine ("{0,-4} {1}", OpCode.Mnemonic, ((ByteFromFile & 0x0F) - 1).ToString ("D2"));
                            break;

                        case FocalDecompiler.OpCodes.FctType.GTO_0_14:
                            OutFileStream.WriteLine ("{0,-4} {1}", OpCode.Mnemonic, ((ByteFromFile & 0x0F) - 1).ToString ("D2"));
                            ByteFromFile = InFileStream.ReadByte ();
                            break;

                        case FocalDecompiler.OpCodes.FctType.R_0_99_A_J:
                            ByteFromFile = InFileStream.ReadByte ();
                            dump[dumpidx++] = ByteFromFile;
                            ByteFromFile = InFileStream.ReadByte ();
                            dump[dumpidx++] = ByteFromFile;

                            ByteFromFile &= 0x7F;

                            if (ByteFromFile <= 101)
                                OutFileStream.WriteLine ("{0,-4} {1}", OpCode.Mnemonic, ByteFromFile.ToString ("D2"));
                            else
                                OutFileStream.WriteLine ("{0,-4} {1}", OpCode.Mnemonic, ShortLabelParamter[(short)ByteFromFile]);

                            break;

                        case FocalDecompiler.OpCodes.FctType.LBL_0_99_A_J:
                            ByteFromFile = InFileStream.ReadByte ();
                            dump[dumpidx++] = ByteFromFile;

                            if (ByteFromFile <= 101)
                                OutFileStream.WriteLine ("{0,-4} {1}", OpCode.Mnemonic, ByteFromFile.ToString ("D2"));
                            else
                                OutFileStream.WriteLine ("{0,-4} {1}", OpCode.Mnemonic, ShortLabelParamter[(short)ByteFromFile]);

                            break;

                        case FocalDecompiler.OpCodes.FctType.GTO_XEQ_Ind:
                            ByteFromFile = InFileStream.ReadByte ();
                            dump[dumpidx++] = ByteFromFile;

                            if ((ByteFromFile & 0x80) == 0)
                                Mnemonic = "GTO";
                            else
                                Mnemonic = "XEQ";

                            ByteFromFile &= 0x7f;

                            if (ByteFromFile <= 101)
                                OutFileStream.WriteLine ("{0,-4} IND {1}", Mnemonic, ByteFromFile.ToString ("D2"));
                            else
                                OutFileStream.WriteLine ("{0,-4} IND {1}", Mnemonic, StackParamter[(short)ByteFromFile]);

                            break;

                        case FocalDecompiler.OpCodes.FctType.XRom:
                            {
                                int Byte2;
                                int Module;
                                int Function;
                                XRomCode XRomCode;

                                Byte2 = InFileStream.ReadByte ();
                                dump[dumpidx++] = ByteFromFile;
                                Module = ((ByteFromFile & 0x07) << 2) | (Byte2 >> 6);
                                Function = Byte2 & 0x3f;

                                if (XRomCodes.FindFunction (Module, Function, out XRomCode))
                                    OutFileStream.WriteLine ("{0}", XRomCode.Mnemonic);
                                else
                                    OutFileStream.WriteLine ("{0,-4} {1},{2}", OpCode.Mnemonic, Module.ToString ("D2"), Function.ToString ("D2"));
                                break;
                            }

                        case FocalDecompiler.OpCodes.FctType.LabelAlpha:
                            {
                                int Len;
                                String Label = String.Empty;

                                ByteFromFile = InFileStream.ReadByte ();
                                dump[dumpidx++] = ByteFromFile;
                                Len = InFileStream.ReadByte ();
                                dump[dumpidx++] = ByteFromFile;
                                ByteFromFile = InFileStream.ReadByte ();
                                dump[dumpidx++] = ByteFromFile;

                                if ((Len & 0xf0) != 0)
                                {
                                    Len -= 0xf1;

                                    while (Len-- > 0)
                                    {
                                        ByteFromFile = InFileStream.ReadByte ();
                                        dump[dumpidx++] = ByteFromFile;
                                        Label += (char)ByteFromFile;
                                    }

                                    OutFileStream.WriteLine ("{0,-4} \"{1}\"", OpCode.Mnemonic, Label);
                                }
                                else
                                    OutFileStream.WriteLine ("END");

                                break;
                            }

                        case FocalDecompiler.OpCodes.FctType.GTO_XEQ_Alpha:
                            {
                                int Len;
                                String Label = String.Empty;

                                Len = InFileStream.ReadByte () - 0xf0;
                                dump[dumpidx++] = ByteFromFile;

                                while (Len-- > 0)
                                {
                                    ByteFromFile = InFileStream.ReadByte ();
                                    dump[dumpidx++] = ByteFromFile;
                                    Label += (char)ByteFromFile;
                                }

                                OutFileStream.WriteLine ("{0,-4} \"{1}\"", OpCode.Mnemonic, Label);
                                break;
                            }

                        case FocalDecompiler.OpCodes.FctType.Alpha:
                            {
                                int Len;
                                String Label = String.Empty;
                                String Append = String.Empty;

                                Len = ByteFromFile & 0x0f;
                                ByteFromFile = InFileStream.ReadByte ();
                                dump[dumpidx++] = ByteFromFile;

                                if (ByteFromFile == 0x7f) //append
                                {
                                    Append = ">";
                                    ByteFromFile = InFileStream.ReadByte ();
                                    dump[dumpidx++] = ByteFromFile;
                                    Len--;
                                }

                                while (Len-- > 0)
                                {
                                    Label += (char)ByteFromFile;
                                    ByteFromFile = InFileStream.ReadByte ();
                                    dump[dumpidx++] = ByteFromFile;
                                }

                                OutFileStream.WriteLine ("{0}\"{1}\"", Append, Label);
                                HaveNextByte = true;
                                break;
                            }

                        case FocalDecompiler.OpCodes.FctType.Number:
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
                                dump[dumpidx++] = ByteFromFile;
                                OpCode = OpCodes.GetOpCodeInfo (ByteFromFile);
                            }
                            while (OpCode.FctType == FocalDecompiler.OpCodes.FctType.Number);

                            OutFileStream.WriteLine ();
                            HaveNextByte = true;
                            break;

                        default:
                            OutFileStream.WriteLine ("? {0}", ByteFromFile.ToString ("X2"));
                            break;
                    }

                    if (!HaveNextByte)
                    {
                        ByteFromFile = InFileStream.ReadByte ();
                        dump[dumpidx++] = ByteFromFile;
                    }

                    HaveNextByte = false;
                }
            }
            catch(Exception e)
            {
                Console.Write ("Exception caught on statement: ");

                for (int i = 0; i < dumpidx; i++)
                {
                    Console.Write ("{0} ", dump[i]);
                }

                Console.WriteLine ();
            }


            InFileStream.Close ();
            OutFileStream.Close ();
        }
    }
}
