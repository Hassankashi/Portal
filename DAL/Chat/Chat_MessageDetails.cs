using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pine.Dal.Chat
{
   public class Chat_MessageDetails
    {
        #region Constructors (2)


        public Chat_MessageDetails(Int64 messageId, Int32? conversationId, String comment, DateTime enterdate,Guid userId, String username, Boolean isRead, Int32 domainId, Int32 languageId)
        {
          
            MessageId  =messageId;
            ConversationId = conversationId;
            Comment = comment;
            Enterdate = enterdate;
            UserId = userId;
            Username = username;
            IsRead = isRead;
            DomainId = domainId;
            LanguageId = languageId;

        }

        public Chat_MessageDetails()
        {
        }

        #endregion Constructors

        #region Properties (9)

        public Int64 MessageId { get; set; } 

        public Int32? ConversationId { get; set; }

        public String Comment { get; set; }

        public DateTime Enterdate { get; set; }

        public Guid UserId { get; set; }

        public String Username { get; set; }

        public Boolean IsRead { get; set; }

        public Int32 DomainId { get; set; }

        public Int32 LanguageId { get; set; }

        #endregion Properties
    }
    
}
