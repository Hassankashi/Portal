using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pine.Dal.Core
{
   public class CoreMasterPageNameCoreAccessPageDetails
   {
       #region Properties

       public int MasterPageNameId { get; set; }
       public String PathSmallImage { get; set; }
       public String PathImage { get; set; }
       public String NameImage { get; set; }
       public String Username { get; set; }
      
       #endregion

        #region constructor
       public CoreMasterPageNameCoreAccessPageDetails(int masterPageNameId, String pathSmallImage, String pathImage, String nameImage, String username)
       {
           MasterPageNameId = masterPageNameId;
           PathSmallImage = pathSmallImage;
           PathImage = pathImage;
           NameImage = nameImage;
           Username = username;
       }

       public CoreMasterPageNameCoreAccessPageDetails( )
       {
       }

       #endregion

   }
}
