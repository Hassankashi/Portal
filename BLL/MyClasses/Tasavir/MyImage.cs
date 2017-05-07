using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Drawing;

namespace Pine.Bll.MyClasses.Tasavir 
{
    /// <summary>
    /// Summary description for MyImage
    /// </summary>
    public class MyImage
    {
        public MyImage()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        public Image ResizeImage(Image imgToResize, Size size)
        {
            Bitmap b = new Bitmap(size.Width, size.Height);
            Graphics g = Graphics.FromImage(b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.DrawImage(imgToResize, 0, 0, size.Width, size.Height);
            g.Dispose();
            return b;
        }

        public Image CropImage(Image img, float x, float y, Size size)
        {
            Rectangle cropRect = new Rectangle((int)x, (int)y, size.Width, size.Height);
            Bitmap target = new Bitmap(size.Width, size.Height);

            using (Graphics g = Graphics.FromImage(target))
            {
                g.DrawImage(img, new Rectangle(0, 0, target.Width, target.Height),
                                cropRect,
                                GraphicsUnit.Pixel);
            }
            return target;
        }

        public static void EncodeParametr(Int64 valueCompressed, out ImageCodecInfo myImageCodecInfo, out EncoderParameters myEncoderParameters)
        {
            Encoder myEncoder;
            EncoderParameter myEncoderParameter;
            myImageCodecInfo = GetEncoderInfo("image/jpeg");
            myEncoder = Encoder.Quality;
            myEncoderParameters = new EncoderParameters(1);
            myEncoderParameter = new EncoderParameter(myEncoder, valueCompressed);
            myEncoderParameters.Param[0] = myEncoderParameter;
        }
        //  -----------------imagecomperesor-----------------
        private static ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }



    }
}