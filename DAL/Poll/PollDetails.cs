using System;
using System.Linq;

namespace Pine.Dal.Poll
{
    /// <summary>
    /// کلاسی برای نگهداری منو
    /// </summary>
    public class PollDetails
    {
        #region Constructors (1)

        public PollDetails(Int32 pollId, String pollName, Boolean isActive, DateTime enterDate, Int32 pollNameMenuId, Int32 languageId, Int32 domainId)
        {
            PollId = pollId;
            PollName = pollName;
            IsActive = isActive;
            EnterDate = enterDate;
            PollNameMenuId = pollNameMenuId;
            LanguageId = languageId;
            DomainId = domainId;
        }

        /// <summary>
        /// سازنده پیش فرض کلاس جزئیات منو
        /// </summary>
        public PollDetails() { }

        #endregion Constructors

        #region Properties (7)

        public Int32 PollId { get; set; }
        public String PollName { get; set; }
        public Boolean IsActive { get; set; }
        public DateTime EnterDate { get; set; }
        public Int32 PollNameMenuId { get; set; }
        public Int32 LanguageId { get; set; }
        public Int32 DomainId { get; set; }

        #endregion

    
    }
}

