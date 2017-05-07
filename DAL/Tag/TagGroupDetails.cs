using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pine.Dal.Tag
{
   public class TagGroupDetails
    {
#region constructor
    public TagGroupDetails()
    {
    }

    public TagGroupDetails(Guid tagGroupId, String tagGroupName, Int32 languageId, Int32 domainId)
    {
        TagGroupId = tagGroupId;
        TagGroupName = tagGroupName;
        LanguageId = languageId;
        DomainId = domainId;
    }
       #endregion

#region properties

       public Guid TagGroupId { get; set; }
       public String TagGroupName { get; set; }
       public Int32 LanguageId { get; set; }
       public Int32 DomainId { get; set; }

       #endregion
    }
}
