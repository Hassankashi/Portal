using System;
using System.Web.Security;

namespace Pine.Bll
{
   public class BasePage : System.Web.UI.Page
   {
		#region Properties (2) 

      public string BaseUrl
      {
         get
         {
            string url = this.Request.ApplicationPath;
            if (url.EndsWith("/"))
               return url;
            else
               return url + "/";
         }
      }

      public string FullBaseUrl
      {
         get
         {
            return this.Request.Url.AbsoluteUri.Replace(
               this.Request.Url.PathAndQuery, "") + this.BaseUrl;
         }
      }

		#endregion Properties 

		#region Methods (4) 

		// Protected Methods (4) 

      protected override void InitializeCulture()
       {
      //   string culture = (HttpContext.Current.Profile as ProfileCommon).Preferences.Culture;
      //   this.Culture = culture;
      //   this.UICulture = culture;
      }

      protected override void OnLoad(EventArgs e)
      {
         // add onfocus and onblur javascripts to all input controls on the forum,
         // so that the active control has a difference appearance
         //Helpers.SetInputControlsHighlight(this, "highlight", false);
         
         base.OnLoad(e);
         //Helpers.GZipEncodePage();
      }

      protected override void OnPreInit(EventArgs e)
      {
         //string id = Globals.ThemesSelectorID;
         //if (id.Length > 0)
         //{
         //   // if this is a postback caused by the theme selector's dropdownlist, retrieve
         //   // the selected theme and use it for the current page request
         //   if (this.Request.Form["__EVENTTARGET"] == id && !string.IsNullOrEmpty(this.Request.Form[id]))
         //   {
         //      this.Theme = this.Request.Form[id];
         //      (HttpContext.Current.Profile as ProfileCommon).Preferences.Theme = this.Theme;
         //   }
         //   else
         //   {
         //      // if not a postback, or a postback caused by controls other then the theme selector,
         //      // set the page's theme with the value found in the user's profile, if present
         //      if (!string.IsNullOrEmpty((HttpContext.Current.Profile as ProfileCommon).Preferences.Theme))
         //         this.Theme = (HttpContext.Current.Profile as ProfileCommon).Preferences.Theme;
         //   }
         //}

         base.OnPreInit(e);
      }

      protected void RequestLogin()
      {
         this.Response.Redirect(FormsAuthentication.LoginUrl + 
            "?ReturnUrl=" + this.Request.Url.PathAndQuery);
      }

		#endregion Methods 
   }
}
