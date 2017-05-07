using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pine.Dal.Store;
using Pine.Dal;

namespace Pine.Bll.Store
{
  public  class Store_TabModules: BaseStore
    {
         #region Constructors (2)



       public Store_TabModules(Int32 idModule, String name, String description, String userControlAddress, Boolean isActive, Int32 domainId,Int32 languageId )
       {
           IdModule = idModule;
           Name = name;
           Description = description;
           UserControlAddress = userControlAddress;
           IsActive = isActive;
          DomainId= domainId ;
          LanguageId = languageId;


       }

       public Store_TabModules()
        {
            CacheDuration = Settings.CacheDuration;
            MasterCacheKey = "Store";
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

        #region  Methods
       public Int32 InsertTabModules()
       {
           return InsertTabModules( IdModule,Name, Description, UserControlAddress, IsActive, DomainId , LanguageId);
       }

       private Int32 InsertTabModules(Int32 idModule, String name, String description, String userControlAddress, Boolean isActive, Int32 domainId, Int32 languageId)
       {
           Store_TabModulesDetails Store_TabModules = new Store_TabModulesDetails(idModule, name, description, userControlAddress, isActive, domainId, languageId);
           Int32 ret = SiteProvider.Store.InsertTabModules(Store_TabModules);
           if (Settings.EnableCaching & ret > 0)
               InvalidateCache();
           return ret;
       }

       public bool DeleteTabModules(Int32 id)
       {


           Boolean ret = SiteProvider.Store.DeleteTabModules(id);
           if (Settings.EnableCaching & ret)
               InvalidateCache();
           return ret;
       }


       //    /// <summary>
       //    /// تبدیل داده های لایه دیتا به داده های لایه تجاری 
       //    /// </summary>
       //    /// <param name="records">رکوردهای ورودی حاوی داده های لایه دیتا</param>
       //    /// <returns></returns>
       private static List<Store_TabModules> GetStore_Store_TabModulesCollectionFromOrderDal(List<Store_TabModulesDetails> records)
       {
           List<Store_TabModules> items = new List<Store_TabModules>();
           foreach (Store_TabModulesDetails item in records)
               items.Add(GetStore_Store_TabModulesFromOrderDal(item));
           return items;
       }

       /// <summary>
       /// تبدیل داده لایه دیتا به داده لایه تجاری
       /// </summary>
       /// <param name="record">رکورد ورودی حاوی داده لایه دیتا</param>
       /// <returns></returns>
       private static Store_TabModules GetStore_Store_TabModulesFromOrderDal(Store_TabModulesDetails record)
       {
           if (record != null)
               return new Store_TabModules(record.IdModule,record.Name,record.Description,record.UserControlAddress,record.IsActive,record.DomainId,record.LanguageId);
           return null;
       }

        #endregion

    }
}
