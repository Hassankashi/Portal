using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System
{
    public static class CreatePagingControlExtensionMethods
    {
        public static string CreatePagingControl<T>(IList<T> blog, int page, int pageSize,Uri  url)
        {
               
            //  int cnt = blog.Count;
            Uri uri = url;
            int cntgroupPaging = 5;

            int cntPage = (blog.Count / pageSize);
            if ((blog.Count % pageSize) != 0) cntPage++;
            int groupPaging = page / cntgroupPaging;
            if ((page % cntgroupPaging) != 0) groupPaging++;

            groupPaging--;
            String text = "<ul class=\"pagination paginationD paginationD02\">";

            if (page == 1)
            {
                text += string.Format("<li><a href=\"#\" class=\"previous\">قبلی</a></li>");
            }
            else
            {
                text += string.Format("<li><a href=\"{0}\" class=\"previous\">قبلی</a></li>", uri.LocalPath + "?PageIndex=" + (page - 1));
            }

            for (int i = 1; i <= cntgroupPaging; i++)
            {
                if (((cntgroupPaging * groupPaging) + i) <= cntPage)
                {
                    string strClass = "";
                    if (page == (cntgroupPaging * groupPaging) + i) strClass = "class=\"current\"";
                    text += string.Format("<li><a href=\"{0}\" {1} >{2}</a></li>", uri.LocalPath + "?PageIndex=" + ((cntgroupPaging * groupPaging) + i), strClass, (cntgroupPaging * groupPaging) + i);
                }
            }
            if (cntPage <= 5)
            {

            }
            else
            {
                text += string.Format(" <li><a href=\"{0}\" class=\"last\">...</a></li>", uri.LocalPath + "?PageIndex=" + ((cntgroupPaging * groupPaging) + 6));
            }
            //text += string.Format("<li><a href=\"{0}\" {1} >{2}</a></li>", uri.LocalPath + "?PageIndex=" + secPage, "", secPage);
            //text += string.Format("<li><a href=\"{0}\" {1} >{2}</a></li>", uri.LocalPath + "?PageIndex=" + MidPage, "", MidPage);
            //text += string.Format("<li><a href=\"{0}\" {1} >{2}</a></li>", uri.LocalPath + "?PageIndex=" + mid1, "", mid1);
            //text += string.Format("<li><a href=\"{0}\" {1} >{2}</a></li>", uri.LocalPath + "?PageIndex=" + lastPage, "", lastPage);
            if (page == cntPage)
            {
                text += string.Format("<li><a href=\"#\" class=\"next\">بعدی</a></li>");
            }
            else
            {
                text += string.Format("<li><a href=\"{0}\" class=\"next\">بعدی</a></li>", uri.LocalPath + "?PageIndex=" + (page + 1));
            }

            text += string.Format(" <li><a href=\"{0}\" class=\"last\">آخرین</a></li>", uri.LocalPath + "?PageIndex=" + cntPage);
            text += string.Format("<li class=\"first\">صفحه {0} از {1}</li>", page, cntPage);
            text += string.Format("</ul>");
            return text;
            // LinkButton lnk = new LinkButton();
            // lnk.Click += new EventHandler(lbl_Click);
            // lnk.ID = "lnkPage" + (i + 1).ToString();
            // lnk.Text = (i + 1).ToString();
            //// GetRouteUrl(new {PageIndex=(i+1)})
            // lnk.PostBackUrl = uri.LocalPath   +"?PageIndex="+ (i + 1);
            // this.form1.Controls.Add(lnk);







        }
       
    }
}
