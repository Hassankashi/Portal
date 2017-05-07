using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace Pine.Bll.MyClasses.Folder
{
    /// <summary>
    /// Summary description for MyFolder
    /// </summary>
    public class MyFolder
    {
        public MyFolder()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static void CreateFolder(string pathName)
        {
          //  string strPathServer = HttpContext.Current.Server.MapPath(PathName);
            string directoryPath = Path.GetDirectoryName(pathName);
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
        }
        public static void DeleteFile(string pathFile)
        {
            if (File.Exists(pathFile))
            {
                File.Delete(pathFile);
            }
            
        }
    }
}