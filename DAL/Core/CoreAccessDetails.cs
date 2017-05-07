using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pine.Dal.Core
{
  public  class CoreAccessDetails
    {
        #region Constructor
        public CoreAccessDetails()
        { 
        }

        public CoreAccessDetails(Int32 accessId, Int32 userControlPathId, String userName, Boolean useManager, Int32 languageId, Int32 domainId)
        {
            AccessId = accessId;
            UserControlPathId = userControlPathId;
            UserName = userName;
            UseManager = useManager;
            LanguageId = languageId;
            DomainId = domainId;
        }
        #endregion

        #region Properties
        public Int32 AccessId { get; set; }
        public Int32 UserControlPathId { get; set; }
        public String UserName { get; set; }
        public Boolean UseManager { get; set; }
        public Int32 LanguageId { get; set; }
        public Int32 DomainId { get; set; }
        #endregion


        
    }
}
