using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;

namespace FocalDecompiler
{
    class Program
    {
        static void Help ()
        {
            Console.WriteLine ("Usage: FocalComp <input file> [<output file>]");
            Console.WriteLine ("");
        }
        /////////////////////////////////////////////////////////////

        static void Main (string[] args)
        {
            Version Ver = Assembly.GetExecutingAssembly ().GetName ().Version;

            Console.WriteLine ("HP-41 Focal Decompiler v{0}.{1} (c) 2013 Michael Göricke", Ver.Major, Ver.Minor);
            Console.WriteLine ("");

            if (args.Length < 1)
            {
                Help ();
                return;
            }

            FocalDecomp Decomp = new FocalDecomp ();

            String OutputFilename;

            if (args.Length == 1)
                OutputFilename = Path.ChangeExtension (args[0], "txt");
            else
                OutputFilename = args[1];

            Decomp.Decompile (args[0], OutputFilename);
        }
    }
}
