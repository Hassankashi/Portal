using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pine.Dal.Tag
{
   public class TagJunctionDetails
    {
#region constructor

       public  TagJunctionDetails ()
       {
       }

       public TagJunctionDetails(Guid tagId, Guid adItemId)
       {
           TagId = tagId;
           AdItemId = adItemId;
       }

       #endregion

#region Properties
       public Guid TagId { get; set; }
       public Guid AdItemId { get; set; }

       #endregion
    }
}
