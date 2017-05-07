using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pine.Dal.Chat
{
   public class Chat_ResponderDetails
    {

         #region Constructors (2)


       public Chat_ResponderDetails(Int32 responderId, Int32? partId, String userName, Guid? userId, Int32 domainId, Int32 language) 
        {
            ResponderId = responderId;  
            PartId = partId;
            UserName = userName;
            UserId = userId;
            DomainId = domainId;
            Language = language;

        }

        public Chat_ResponderDetails()
        {
        }

        #endregion Constructors

        #region Properties (6)

        public Int32 ResponderId { get; set; }

        public String UserName { get; set; }

        public Int32? PartId { get; set; }

        public Guid? UserId { get; set; } 
       

        public Int32 DomainId { get; set; }

        public Int32 Language { get; set; } 

        #endregion Properties

    }
}
