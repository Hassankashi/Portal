using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pine.Dal.Store
{
   public class Store_TabModulesDetails
   {
       #region Constructors (2)



       public Store_TabModulesDetails(Int32 idModule, String name, String description, String userControlAddress, Boolean isActive, Int32 domainId,Int32 languageId )
       {
           IdModule = idModule;
           Name = name;
           Description = description;
           UserControlAddress = userControlAddress;
           IsActive = isActive;
          DomainId= domainId ;
          LanguageId = languageId;


       }

       public Store_TabModulesDetails()
        {
        }
       #endregion

       #region Properties (8)

       public Int32 IdModule { get; set; }

       public String Name { get; set; }

       public String Description { get; set; }

       public String UserControlAddress { get; set; }

       public Boolean IsActive { get; set; }

       public Int32 DomainId { get; set; }

       public Int32 LanguageId { get; set; }

      

       #endregion

   }
}
