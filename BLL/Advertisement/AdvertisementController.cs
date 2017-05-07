using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using Pine.Bll.Advertisement;
using Pine.Bll.Tag;
using System.Web.UI.WebControls;


namespace Pine.Bll.Advertisement
{
    public static class AdvertisementController
    {
        //public var GetAdItemList(int id,System.Web.UI.WebControls listView)
        //{
        //    List<AdvertisementItems> list = AdvertisementItems.GetAdvertisementItemsByAdId(id);
        //    var rr = (from l in list
        //              select new
        //                         {
        //                             Title = l.Title,
        //                             AdItemId = l.AdItemId,
        //                             SmallPicture = VirtualPathUtility.ToAbsolute(l.SmallPicture),
        //                             Href =
        //                  VirtualPathUtility.ToAbsolute("~/Advertisement/AdItemView/AdItemView.aspx") + "?AdItemId=" +
        //                  l.AdItemId
        //                         }).ToList();
        //    return rr;
        //}

        public static List<Tag.Tag> GetTags(Guid Id)
        {

            return Tag.Tag.GetTagsByAdItemId(Id);

        }


        public static void Showtags(Guid Id, Label lblTag )
        {
            List<Tag.Tag> listtag = GetTags(Id);
            var rr = (from l in listtag
                      select new
                                 {
                                     Title = l.Title,
                                     TagId = l.TagId
                                 }
                     ).ToList();
            for (int i = 0; i < rr.Count; i++)
            {
                {

                    HtmlGenericControl a = new HtmlGenericControl("a");
                    a.Attributes.Add("id", "i" + 1);
                    a.InnerText = rr[i].Title;
                    //string strHref = GetRouteUrl("", new { id = "", });
                    //a.Attributes.Add("href", strHref);
                    a.Attributes.Add("href", "../AdItemUI/AdItemByTag.aspx?TagId=" + rr[i].TagId);
                    lblTag.Controls.Add(a);
                    LiteralControl space = new LiteralControl();
                    space.Text = "&nbsp;&nbsp;-&nbsp;&nbsp;";
                    lblTag.Controls.Add(space);
                   
                }

            }
        }

        public static void FillFormAdItemView(Guid id, HtmlImage img , Label lAddress, Label lCountVisit,Label lEmail,Label lDesc,Label lMobile,Label lTel,
                                               Label lTitle , Label lWebUrl , HtmlGenericControl iFrame ,Label lTag)
        {
            AdvertisementItems adItem = AdvertisementItems.GetAdvertisementItemsByAdItemId(id);
            img.Src = adItem.BigPicture;
            lAddress.Text = adItem.Address;
            lCountVisit.Text = adItem.VisitCount.ToString();
            lEmail.Text = adItem.Email;
            lDesc.Text = adItem.Description;
            lMobile.Text = adItem.Mobile;
            lTel.Text = adItem.Tel;
            lTitle.Text = adItem.Title;
            lWebUrl.Text = adItem.WebUrl;
            string gmap = adItem.GoogleMap.Replace("amp;", "");
            if (gmap != "")
            {
                iFrame.Attributes["src"] = gmap;
            }
            else
            {
                iFrame.Visible = false;
            }

            Showtags(id,lTag);
        }
           
            
        }
    }
