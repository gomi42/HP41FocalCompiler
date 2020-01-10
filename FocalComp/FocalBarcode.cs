using System;
using System.IO;
using System.Windows.Media;

namespace FocalCompiler
{
    class FocalBarcode
    {
        const int NumHeaderBytesPerLine = 3;
        const int MaxBytesPerLine = 13;
        
        /////////////////////////////

        StreamWriter outFileStream;
        String outFilename;
        int checksum;
        int currentRow;

        int outcodeLength;
        byte[] outCode = new byte[20];
        byte[] barcodeBuf = new byte[MaxBytesPerLine];
        int barcodeBufIndex = 0;
        int trailing = 0;

        int errors = 0;
        int lineNr = 1;
        int destLineNr = 1;
        int destFromLine = 1;

        Compiler compiler;
        BarcodeImage image;

        bool genHex;

        public void Compile (String InputFilename, bool hex)
        {
            genHex = hex;

            /////////////////////////////

            StreamReader inFileStream;

            try
            {
                inFileStream = new StreamReader (InputFilename, System.Text.Encoding.ASCII);
            }
            catch
            {
                Console.WriteLine (String.Format ("Cannot open input file: {0}", InputFilename));
                return;
            }

            if (hex)
            {
                outFilename = Path.ChangeExtension (InputFilename, ".hex");

                try
                {
                    outFileStream = new StreamWriter (outFilename, false, System.Text.Encoding.ASCII);
                }
                catch
                {
                    Console.WriteLine (String.Format ("Cannot open output file: {0}", outFilename));
                    return;
                }
            }

            Console.WriteLine (String.Format ("Barcoding: {0}", InputFilename));

            /////////////////////////////

            image = new BarcodeImage ();
            image.ImageBaseFilename = Path.Combine (Path.GetDirectoryName (InputFilename), Path.GetFileNameWithoutExtension (InputFilename));
            image.PrintFilename = Path.GetFileName (InputFilename);

            compiler = new Compiler ();

            /////////////////////////////

            String Line = inFileStream.ReadLine ();

            while (Line != null)
            {
                String ErrorMsg;
                outcodeLength = 0;

                if (compiler.Compile (Line, ref outcodeLength, ref outCode, out ErrorMsg))
                {
                    Console.WriteLine (String.Format ("Error line {0}: {1}", lineNr.ToString (), ErrorMsg));
                    errors++;
                }

                if (errors == 0)
                {
                    AddToBarcode (outcodeLength, outCode);
                }

                lineNr++;
                Line = inFileStream.ReadLine ();
            }

            if (errors == 0)
            {
                if (!compiler.IsEndDetected)
                {
                    compiler.CompileEnd (ref outcodeLength, ref outCode);
                    AddToBarcode (outcodeLength, outCode);
                }

                if (barcodeBufIndex > 0)
                {
                    OutputBarcode (barcodeBuf, barcodeBufIndex, 0, trailing, currentRow + 1, destFromLine, lineNr);
                }
            }

            inFileStream.Close ();

            if (hex)
            {
                outFileStream.Close ();

                if (errors > 0)
                    File.Delete (outFilename);
            }

            Console.WriteLine (String.Format ("{0} Error(s)", errors.ToString ()));

            image.Save();
        }

        /////////////////////////////////////////////////////////////

        private void AddToBarcode (int outcodeLength, byte[] OutCode)
        {
            if (outcodeLength > 0)
            {
                for (int i = 0; i < outcodeLength; i++)
                {
                    barcodeBuf[barcodeBufIndex] = OutCode[i];
                    barcodeBufIndex++;

                    if (barcodeBufIndex == MaxBytesPerLine)
                    {
                        int leading = 0;
                        int newTrailing = 0;
                        int newFromLine = destLineNr + 1;

                        if (outcodeLength != i + 1)
                        {
                            leading = i + 1;
                            newTrailing = outcodeLength - leading;
                            newFromLine = destLineNr;
                        }

                        OutputBarcode (barcodeBuf, MaxBytesPerLine, leading, trailing, currentRow + 1, destFromLine, destLineNr);
                        trailing = newTrailing;
                        barcodeBufIndex = 0;
                        destFromLine = newFromLine;
                    }
                }

                destLineNr++;
            }
        }

        /////////////////////////////////////////////////////////////

        int CalcChecksum (byte[] bytes, int bufLen, int lastCheck)
        {
            int check = lastCheck;

            for (int i = 0; i < bufLen; i++)
            {
                check += bytes[i];

                if (check > 0xFF)
                {
                    check -= 0xFF;
                }
            }

            return check;
        }

        /////////////////////////////////////////////////////////////

        private void GenOneBarcode (byte[] barcodeBuf, int barcodeLength, int leading, int trailing,
                                      out byte[] barcodeOut, out int barcodeOutLen)
        {
            byte[] barcode = new byte[MaxBytesPerLine + NumHeaderBytesPerLine];
            int destIndex = NumHeaderBytesPerLine;

            barcode[0] = (byte)checksum;
            barcode[1] = (byte)((0x01 << 4) | (currentRow % 16));
            currentRow++;
            barcode[2] = (byte)((trailing << 4) | leading);

            for (int i = 0; i < barcodeLength; i++)
            {
                barcode[destIndex++] = barcodeBuf[i];
            }

            checksum = CalcChecksum (barcode, barcodeLength + NumHeaderBytesPerLine, 0);
            barcode[0] = (byte)checksum;

            barcodeOut = barcode;
            barcodeOutLen = barcodeLength + 3;
        }

        /////////////////////////////////////////////////////////////

        private void DumpBarcode (byte[] barcode, int barcodeLen, int currentRow, int fromLine, int toLine)
        {
            string res = string.Empty;

            for (int i = 0; i < barcodeLen; i++)
            {
                res += barcode[i].ToString ("X2") + " ";
            }

            outFileStream.WriteLine (string.Format ("Row {0} ({1} - {2})", currentRow, fromLine, toLine));
            outFileStream.WriteLine (res);

        }

        /////////////////////////////////////////////////////////////

        private void OutputBarcode (byte[] barcodeBuf, int barcodeLength, int leading, int trailing, int currentRow, int fromLine, int toLine)
        {
            byte[] barcode;
            int barcodeLen;

            GenOneBarcode (barcodeBuf, barcodeLength, leading, trailing, out barcode, out barcodeLen);
            image.AddBarcode(barcode, barcodeLen, currentRow, fromLine, toLine);

            if (genHex)
            {
                DumpBarcode (barcode, barcodeLen, currentRow, fromLine, toLine);
            }
        }
    }
}
