using System;
using System.IO;
using System.Reflection;
using System.Windows;

namespace FocalCompiler
{
    class FocalComp
    {
        public void Compile (String InputFilename)
        {
            /////////////////////////////
            StreamReader InFileStream;
            FileStream OutFileStream;

            try
            {
                InFileStream = new StreamReader (InputFilename, System.Text.Encoding.ASCII);
            }
            catch
            {
                Console.WriteLine (String.Format ("Cannot open input file: {0}", InputFilename));
                return;
            }

            String OutFileName = Path.ChangeExtension (InputFilename, ".raw");

            try
            {
                OutFileStream = new FileStream (OutFileName, FileMode.Create);
            }
            catch
            {
                Console.WriteLine (String.Format ("Cannot open output file: {0}", OutFileName));
                return;
            }

            Console.WriteLine (String.Format ("Compiling: {0}", InputFilename));

            /////////////////////////////

            Compiler Comp = new Compiler ();
            string exeFilename = Assembly.GetExecutingAssembly().Location;
            Comp.SetXromFile(Path.Combine(Path.GetDirectoryName(exeFilename), "XRomCodes.txt"));

            int OutcodeLength;
            byte[] OutCode = new byte[20];

            int Errors = 0;
            int LineNr = 1;

            String Line = InFileStream.ReadLine ();

            while (Line != null)
            {
                OutcodeLength = 0;
                String ErrorMsg;

                if (Comp.Compile (Line, ref OutcodeLength, ref OutCode, out ErrorMsg))
                {
                    Console.WriteLine (String.Format ("Error line {0}: {1}", LineNr.ToString (), ErrorMsg));
                    Errors++;
                }

                if (Errors == 0)
                {
                    for (int i = 0; i < OutcodeLength; i++)
                    {
                        OutFileStream.WriteByte (OutCode[i]);
                    }
                }

                LineNr++;
                Line = InFileStream.ReadLine ();
            }

            InFileStream.Close ();
            OutFileStream.Close ();

            if (Errors > 0)
                File.Delete (OutFileName);

            Console.WriteLine (String.Format ("{0} Error(s)", Errors.ToString ()));
        }
    }
}
