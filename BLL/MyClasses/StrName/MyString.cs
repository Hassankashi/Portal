using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pine.Bll.MyClasses.StrName
{
    /// <summary>
    /// Summary description for MyString
    /// </summary>
    public class MyString
    {
        public MyString()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static string CombineRandeTofileName(string fileName)
        {
            Random random = new Random();
            int numrand = random.Next(99999);
            string strExtension = System.IO.Path.GetExtension(fileName);
            string strNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(fileName);
            string strName = strNameWithoutExtension + numrand + strExtension;
            return strName;
        }
    }
}