using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pine.Dal.Poll
{
   public class PollItemDetails
   {
       #region constructor
       public PollItemDetails()
       {
       }

       public PollItemDetails(Int32 pollItemId, Int32 pollId, String answer, Int32 vote)
       {
           PollItemId = pollItemId;
           PollId = pollId;
           Answer = answer;
           Vote = vote;
       }

#endregion 

#region Properties

       public Int32 PollItemId{ get; set; }
       public Int32 PollId { get; set; }
       public String Answer { get; set; }
       public Int32 Vote { get; set; }

       #endregion Properties
    }
    
}
