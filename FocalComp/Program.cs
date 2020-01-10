using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;
using System.Windows;

namespace FocalCompiler
{
    class Program
    {
        static void Help ()
        {
            Console.WriteLine ("Usage: FocalComp <options> <input file>");
            Console.WriteLine ("Options:");
            Console.WriteLine ("   -raw: create a raw file");
            Console.WriteLine ("   -barcode: create jpg files with barcode");
            Console.WriteLine ("");
            Console.WriteLine ("");
        }

        /////////////////////////////////////////////////////////////

        static void Main (string[] args)
        {
            try
            {
                Version Ver = Assembly.GetExecutingAssembly ().GetName ().Version;

                Console.WriteLine ("HP-41 Focal Compiler v{0}.{1} (c) 2013 Michael Göricke", Ver.Major, Ver.Minor);
                Console.WriteLine ("");

                if (args.Length < 2)
                {
                    Help ();
                    return;
                }

                bool raw = false;
                bool jpg = false;
                bool barcode = false;
                bool hex = false;
                string filename = null;

                foreach (var arg in args)
                {
                    switch (arg)
                    {
                        case "-raw":
                            raw = true;
                            break;

                        case "-jpg":
                            jpg = true;
                            break;

                        case "-barcode":
                            barcode = true;
                            break;

                        case "-hex":
                            hex = true;
                            break;

                        default:
                            if (filename != null)
                            {
                                Help ();
                                return;
                            }

                            filename = arg;
                            break;
                    }
                }

                if (filename == null || (!raw && !barcode))
                {
                    Help ();
                    return;
                }


                if (raw)
                {
                    FocalComp Comp = new FocalComp ();
                    Comp.Compile (filename);
                }

                if (barcode)
                {
                    FocalBarcode Barcode = new FocalBarcode ();
                    Barcode.Compile (filename, hex);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine ("Exception occured: {0}", e.Message);
                
                if (e.StackTrace != null)
                {
                    Console.WriteLine (e.StackTrace);
                }

                Exception e2 = e.InnerException;

                while (e.InnerException != null)
                {
                    Console.WriteLine ("Innerexception: {0}", e.Message);
                    e2 = e2.InnerException;

                    if (e2.StackTrace != null)
                    {
                        Console.WriteLine (e2.StackTrace);
                    }
                }
            }
        }
    }
}
