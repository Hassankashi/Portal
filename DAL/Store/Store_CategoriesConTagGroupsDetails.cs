using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pine.Dal.Store
{
   public class Store_CategoriesConTagGroupsDetails
    {

        #region Constructors (2)


       public Store_CategoriesConTagGroupsDetails(Guid categoryId, Guid tagGroupId)
        {

            CategoryId = categoryId;
            TagGroupId = tagGroupId;


        }

      public Store_CategoriesConTagGroupsDetails()
        {
        }

        #endregion Constructors

        #region Properties (9)

        public Guid CategoryId { get; set; }

        public Guid TagGroupId { get; set; }



        #endregion Properties
    }
}
