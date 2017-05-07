using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pine.Dal.Store
{
   public class Store_CategoriesDetails
    {
         #region Constructors (2)


       public Store_CategoriesDetails(Guid categoryId, String name, String icon, Int32 priority, Guid? parentCategoryId, Int32? productsCount, String username, Boolean status, Int32 domainId, Int32 languageId)
        {

             CategoryId = categoryId;
             Name     = name;
             Icon = icon;
             Priority = priority;
             ParentCategoryId = parentCategoryId;
             ProductsCount = productsCount;
            Username = username;
            Status = status;
            DomainId = domainId;
            LanguageId = languageId;

        }

        public Store_CategoriesDetails()
        {
        }

        #endregion Constructors

        #region Properties (9)

        public Guid CategoryId { get; set; }

        public String Name { get; set; }

        public String Icon { get; set; }

        public Int32 Priority { get; set; }

        public Guid? ParentCategoryId { get; set; }

        public Int32? ProductsCount { get; set; }

        public String Username { get; set; }

        public Boolean Status { get; set; }

        public Int32 DomainId { get; set; }

        public Int32 LanguageId { get; set; }

        #endregion Properties
    }
}
