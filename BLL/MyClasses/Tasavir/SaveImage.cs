using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Drawing.Imaging;
using Pine.Bll.MyClasses.Tasavir;

namespace Pine.Bll.MyClasses.Tasavir 
{
    /// <summary>
    /// Summary description for SaveImage
    /// </summary>
    public class Saveimage :MyImage
    {
        public Saveimage()
        {

        }

        public void SaveImage(string imagePath, System.IO.Stream myStream)
        {
            System.Drawing.Image image = System.Drawing.Image.FromStream(myStream);
            string strServerPath = HttpContext.Current.Server.MapPath(imagePath);
            Pine.Bll.MyClasses.Folder.MyFolder.CreateFolder(strServerPath);
            image.Save(strServerPath);
        }

        public void SaveImage(string imagePath, System.IO.Stream myStream, Int64  valueCompressed)
        {
            ImageCodecInfo myImageCodecInfo;
            EncoderParameters myEncoderParameters;
            EncodeParametr(valueCompressed, out myImageCodecInfo, out myEncoderParameters);
            System.Drawing.Image image = System.Drawing.Image.FromStream(myStream);
            string strServerPath = HttpContext.Current.Server.MapPath(imagePath);
            Pine.Bll.MyClasses.Folder.MyFolder.CreateFolder(strServerPath);
            image.Save(strServerPath, myImageCodecInfo, myEncoderParameters);
        }

        public void SaveImage(string imagePath, System.IO.Stream myStream, Int64 valueCompressed, System.Drawing.Size setSize)
        {
            ImageCodecInfo myImageCodecInfo;
            EncoderParameters myEncoderParameters;
            EncodeParametr(valueCompressed, out myImageCodecInfo, out myEncoderParameters);
            System.Drawing.Image image = System.Drawing.Image.FromStream(myStream);
            image = ResizeImage(image, setSize);
            string strServerPath=  HttpContext.Current.Server.MapPath(imagePath);
            Pine.Bll.MyClasses.Folder.MyFolder.CreateFolder(strServerPath);
            image.Save(strServerPath, myImageCodecInfo, myEncoderParameters);
        }

        public void SaveImageSquare(string imagePath, System.IO.Stream myStream, Int64 valueCompressed)
        {
            ImageCodecInfo myImageCodecInfo;
            EncoderParameters myEncoderParameters;
            EncodeParametr(valueCompressed, out myImageCodecInfo, out myEncoderParameters);
            System.Drawing.Image image = System.Drawing.Image.FromStream(myStream);
            float x,y;
            Size setSize = new Size();
            if (image.Width > image.Height)
            {
             x=   (image.Width - image.Height) / 2;
             y = 0;
             setSize.Width = image.Height;
             setSize.Height = image.Height;
                    
            }
            else
            {
                y = (image.Height - image.Width) / 2;
                x = 0;
                setSize.Width = image.Width;
                setSize.Height = image.Width;
            }
            image = CropImage(image, x, y, setSize);
            string strServerPath = HttpContext.Current.Server.MapPath(imagePath);
            Pine.Bll.MyClasses.Folder.MyFolder.CreateFolder(strServerPath);
            image.Save(strServerPath, myImageCodecInfo, myEncoderParameters);
        }

        public void SaveImageSquare(string imagePath, System.IO.Stream myStream, Int64 valueCompressed, System.Drawing.Size size)
        {
            ImageCodecInfo myImageCodecInfo;
            EncoderParameters myEncoderParameters;
            EncodeParametr(valueCompressed, out myImageCodecInfo, out myEncoderParameters);
            System.Drawing.Image image = System.Drawing.Image.FromStream(myStream);
            float x, y;
            Size setSize = new Size();
            //if (image.Width > image.Height)
            //{
                if (size.Width > size.Height)
                {
                    int   height= (int)(((float)image.Width / (float)size.Width) * size.Height);
                    x = 0;
                    y = (image.Height- height) / 2;
                    setSize.Width = image.Width;
                    setSize.Height = height;
                }
                else
                {
                    int width = (int)(((float)image.Height / (float)size.Height) * size.Width);
                    x =(image.Width- width)/2;
                    y = 0;
                    setSize.Width = width;
                    setSize.Height = image.Height;
                }
            //}
            //else
            //{
            //    if (size.Width > size.Height)
            //    {
            //        int ff = 0;
            //        int width = (int)(((float)image.Height / (float)size.Height) * size.Width);
            //        x = (image.Width - width) / 2;
            //        y = 0;
            //        setSize.Width = width;
            //        setSize.Height = image.Height;
            //    }
            //    else
            //    {
            //        int width = (int)(((float)image.Height / (float)size.Height) * size.Width);
            //        x = (image.Width - width) / 2;
            //        y = 0;
            //        setSize.Width = width;
            //        setSize.Height = image.Height;
            //    }
            //    //y = (image.Height - image.Width) / 2;
            //    //x = 0;
            //    //setSize.Width = image.Width;
            //    //setSize.Height = image.Height - (int)y;
            //}
            image = CropImage(image, x, y, setSize);

            image = ResizeImage(image, size);
            string strServerPath = HttpContext.Current.Server.MapPath(imagePath);
            Pine.Bll.MyClasses.Folder.MyFolder.CreateFolder(strServerPath);
            image.Save(strServerPath, myImageCodecInfo, myEncoderParameters);
        }
    }
}