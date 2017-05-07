using System;
using System.Collections.Generic;
using System.Data;
using Pine.Dal.Poll;

namespace Pine.Dal.Poll
{
    public abstract class PollProvider : DataAccess
    {
        #region Fields (1)

        static private PollProvider _instance;

        #endregion Fields

        #region Constructors (1)

        /// <summary>
        /// سازنده اصلی کلاس
        /// </summary>
        protected PollProvider()
        {
            ConnectionString = Globals.Settings.Poll.ConnectionString;
            EnableCaching = Globals.Settings.Poll.EnableCaching;
            CacheDuration = Globals.Settings.Poll.CacheDuration;
        }

        #endregion Constructors

        #region Properties (1)

        static public PollProvider Instance
        {
            get
            {
                return _instance ?? (_instance = (PollProvider)Activator.CreateInstance(
                    Type.GetType(Globals.Settings.Poll.ProviderType)));
            }
        }

        #endregion Properties

        #region Poll (1)
      
       public abstract PollDetails GetPollByActive(bool active);
       public abstract PollDetails GetPollByPollId(Int32 id);
       public abstract List<PollDetails> GetPollByDomainId(Int32 domainId, Int32 languageId);
       public abstract Int32 InsertPoll(PollDetails pollDetails);

       public abstract Boolean UpdatePoll(PollDetails pollDetails);
        #endregion

        #region Virtual Protected Methods (2)

        protected virtual List<PollDetails> GetPollCollectionFromDataReader(IDataReader reader)
        {
            List<PollDetails> items = new List<PollDetails>();
            while (reader.Read())
                items.Add(GetPollFromDataReader(reader));
            return items;
        }


        protected virtual PollDetails GetPollFromDataReader(IDataReader reader)
        {
            return new PollDetails
                (
                    (Int32)reader["PollId"],
                    (String)reader["PollName"],
                    (bool)reader["IsActive"],
                    (DateTime)reader["EnterDate"],
                    (Int32)reader["PollNameMenuId"],
                    (Int32)reader["LanguageId"],
                    (Int32)reader["DomainId"]
                );
        }


        #endregion

        #region PollItem
        public abstract List<PollItemDetails> GetPollItemByPollId(Int32 pollId);
        public abstract PollItemDetails GetPollItemByPollItemId(Int32 pollItemId);
        public abstract Int32 InsertPollItem(PollItemDetails pollItemDetails);

        public abstract Boolean UpdatePollItem(PollItemDetails pollItemDetails);

        public abstract Boolean DeletePollItem(Int32 pollItemId);

        protected virtual List<PollItemDetails> GetPollItemCollectionFromDataReader(IDataReader reader)
        {
            List<PollItemDetails> items = new List<PollItemDetails>();
            while (reader.Read())
                items.Add(GetPollItemFromDataReader(reader));
            return items;
        }


        protected virtual PollItemDetails GetPollItemFromDataReader(IDataReader reader)
        {
            return new PollItemDetails
                (
                    (Int32)reader["PollItemId"],
                    (Int32)reader["PollId"],
                    (String)reader["Answer"],
                    (Int32)reader["Vote"]
                );
        }
#endregion
    }
}
