using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pine.Dal.Tag
{
   public class TagDetails
    {
#region constructor
       public TagDetails(Guid tagId, String title, Guid tagGroupId)
       {
           TagId = tagId;
           Title = title;
           TagGroupId = tagGroupId;
       }

  public TagDetails()
  {
  }
       #endregion

#region Properties

  public Guid TagId { get; set; }
  public String Title { get; set; }
  public Guid TagGroupId { get; set; }
       #endregion
    }
}
