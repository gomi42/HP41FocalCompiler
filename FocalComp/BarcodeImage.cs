using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace FocalCompiler
{
    class BarcodeImage
    {
        private const int PrintAtDpi = 300;
        private const int WpfDpi = 96;

        private const int ImageWidthPx = 2121;
        private const int ImageHeightPx = 3000;

        private const double DpiToWpf = (double)PrintAtDpi / (double)WpfDpi;

        private const int ImageHeightWpf = (int)(ImageHeightPx / DpiToWpf) + 1;
        private const int ImageWidthWpf = (int)(ImageWidthPx / DpiToWpf) + 1;

        private const double TopBorder = 10;
        private const double LeftBorder = 10;
        private const double ZeroBarWidth = 1.8;
        private const double OneBarWidth = 2 * ZeroBarWidth;
        private double GapBarWidth = ZeroBarWidth;
        private const double BarHeight = 33;

        /////////////////////////////////////////////////////////////

        DateTime printDate;
        DrawingVisual drawingVisual;
        DrawingContext drawingContext;
        double currentY;
        int currentPage = 1;

        /////////////////////////////////////////////////////////////

        public string ImageBaseFilename
        {
            set;
            get;
        }

        /////////////////////////////////////////////////////////////

        public string PrintFilename
        {
            set;
            get;
        }

        /////////////////////////////////////////////////////////////

        public BarcodeImage ()
        {
            printDate = DateTime.Now;
        }

        /////////////////////////////////////////////////////////////

        private void InitImage ()
        {
            currentY = TopBorder;

            drawingVisual = new DrawingVisual ();
            drawingContext = drawingVisual.RenderOpen ();
            drawingContext.DrawRectangle (Brushes.White, null, new Rect (0, 0, ImageWidthWpf, ImageHeightWpf));

            string s = string.Format ("Page {0}  {1}  {2}", currentPage, printDate, PrintFilename);
            FormattedText text = new FormattedText(s,
                    CultureInfo.InvariantCulture,
                    FlowDirection.LeftToRight,
                    new Typeface ("Arial"),
                    12,
                    Brushes.Black);

            drawingContext.DrawText (text, new System.Windows.Point (LeftBorder, currentY));
            currentY += (int)(text.Height * 2);
        }

        /////////////////////////////////////////////////////////////

        public void Save ()
        {
            if (drawingVisual == null)
            {
                return;
            }

            drawingContext.Close ();

            RenderTargetBitmap targetBitmap = new RenderTargetBitmap (ImageWidthPx, ImageHeightPx, PrintAtDpi, PrintAtDpi, PixelFormats.Default);
            targetBitmap.Render (drawingVisual);
            targetBitmap.Freeze ();

            JpegBitmapEncoder enc = new JpegBitmapEncoder ();
            enc.QualityLevel = 80;
            enc.Frames.Add (BitmapFrame.Create (targetBitmap));

            string filename = ImageBaseFilename + "-" + currentPage.ToString () + ".jpg";
            FileStream fs = new FileStream (filename, FileMode.Create);
            enc.Save (fs);
            fs.Flush ();
            fs.Close ();
        }

        /////////////////////////////////////////////////////////////

        private double AddZeroBar (double x)
        {
            drawingContext.DrawRectangle (Brushes.Black, null, new Rect (x, currentY, ZeroBarWidth, BarHeight));

            return ZeroBarWidth + GapBarWidth;
        }

        /////////////////////////////////////////////////////////////

        private double AddOneBar (double x)
        {
            drawingContext.DrawRectangle (Brushes.Black, null, new Rect (x, currentY, OneBarWidth, BarHeight));

            return OneBarWidth + GapBarWidth;
        }

        /////////////////////////////////////////////////////////////

        public void AddBarcode (byte[] barcode, int barcodeLen, int currentRow, int fromLine, int toLine)
        {
            if (drawingVisual == null)
            {
                InitImage ();
            }

            string s = string.Format ("Row {0} ({1} - {2})", currentRow, fromLine, toLine);
            FormattedText text = new FormattedText (s,
                    CultureInfo.InvariantCulture,
                    FlowDirection.LeftToRight,
                    //new Typeface (new FontFamily ("Arial"), FontStyles.Normal, FontWeights.Normal, new FontStretch ()),
                    new Typeface ("Arial"),
                    12,
                    Brushes.Black);

            drawingContext.DrawText (text, new System.Windows.Point (LeftBorder, currentY));
            currentY += text.Height;

            double x = LeftBorder;

            x += AddZeroBar (x);
            x += AddZeroBar (x);

            for (int i = 0; i < barcodeLen; i++)
            {
                byte b = barcode[i];

                for (int j = 0; j < 8; j++)
                {
                    if ((b & 0x80) == 0x80)
                    {
                        x += AddOneBar (x);
                    }
                    else
                    {
                        x += AddZeroBar (x);
                    }

                    b <<= 1;
                }
            }

            x += AddOneBar (x);
            x += AddZeroBar (x);

            currentY += BarHeight;

            if (currentY + text.Height + BarHeight > ImageHeightWpf - TopBorder)
            {
                Save ();
                drawingVisual = null;
                currentPage++;
            }
        }
    }
}
