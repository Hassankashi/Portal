using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pine.Dal.Chat
{
  public  class Chat_ConversationDetails
    {
    #region Constructors (2)


        public Chat_ConversationDetails(Int32 conversationId, Guid senderId, Guid receiverId, Int32? partId,Int16? flag,Int32 domainId,Int32 languageId)
        {
            ConversationId = conversationId;
            SenderId = senderId;
            ReceiverId = receiverId;
            PartId = partId;
            Flag = flag;
            DomainId = domainId;
            LanguageId = languageId;

        }

        public Chat_ConversationDetails()
        {
        }

        #endregion Constructors

        #region Properties (7)

        public  Int32 ConversationId{ get; set; }

        public Guid SenderId { get; set; } 

        public Guid ReceiverId { get; set; }

        public Int32? PartId { get; set; }

        public Int16? Flag { get; set; }

        public Int32 DomainId { get; set; }

        public Int32 LanguageId { get; set; }

        #endregion Properties
    }
}
