using System;
using System.Collections.Generic;
using System.Data;
using Pine.Dal.Store;

namespace Pine.Dal.Store  
{
    public abstract class StoreProvider : DataAccess
    {
        #region Fields (1)

        static private StoreProvider _instance; 

        #endregion Fields

        #region Constructors (1)

        /// <summary>
        /// سازنده اصلی کلاس
        /// </summary>
        protected StoreProvider()
        {
            ConnectionString = Globals.Settings.Store.ConnectionString;
            EnableCaching = Globals.Settings.Store.EnableCaching;
            CacheDuration = Globals.Settings.Store.CacheDuration;
        }

        #endregion Constructors

        #region Properties (1)

        /// <summary>
        /// Returns an instance of the provider type specified in the config file
        /// </summary>
        static public StoreProvider Instance
        {
            get
            {
                return _instance ?? (_instance = (StoreProvider)Activator.CreateInstance(
                    Type.GetType(Globals.Settings.Store.ProviderType))); 
            }
        }

        #endregion Properties

        #region CategoriesConTagGroups

        public abstract Int32 insertCategoriesConTagGroups(Store_CategoriesConTagGroupsDetails store_CategoriesConTagGroupsDetails);

        public abstract Boolean UpdateCategoriesConTagGroups(Store_CategoriesConTagGroupsDetails store_CategoriesConTagGroupsDetails);

        public abstract Boolean DeleteCategoriesConTagGroups(Guid Id);

        public abstract List<Store_CategoriesConTagGroupsDetails> GetCategoriesConTagGroupById(Guid Id);


        #region Virtual Protected Methods (2)

        protected virtual List<Store_CategoriesConTagGroupsDetails> GetStore_CategoriesConTagGroupCollectionFromDataReader(IDataReader reader)
        {
            List<Store_CategoriesConTagGroupsDetails> items = new List<Store_CategoriesConTagGroupsDetails>();
            while (reader.Read())
                items.Add(GetStore_CategoriesConTagGroupFromDataReader(reader));
            return items;
        }


        protected virtual Store_CategoriesConTagGroupsDetails GetStore_CategoriesConTagGroupFromDataReader(IDataReader reader)
        {
            return new Store_CategoriesConTagGroupsDetails
                (
                    
                     (Guid)reader["CategoryId"],
                     (Guid)reader["TagGroupId"]

                );
        }

        #endregion
         
        #endregion

        #region Categories

        public abstract Int32 insertCategories(Store_CategoriesDetails store_CategoriesDetails);

        public abstract Boolean UpdateCategories(Store_CategoriesDetails store_CategoriesDetails);

        public abstract Boolean DeleteCategories(Guid Id);

        public abstract Store_CategoriesDetails GetCategoriesById(Guid Id);

        public abstract List<Store_CategoriesDetails> GetAllCategories();
 

        public abstract List<Store_CategoriesDetails> GetCategoryByDomainAndLanguage(Int32 Domain, Int32 Language);  


        #region Virtual Protected Methods (2)

        protected virtual List<Store_CategoriesDetails> GetStore_CategoriesCollectionFromDataReader(IDataReader reader)
        {
            List<Store_CategoriesDetails> items = new List<Store_CategoriesDetails>();
            while (reader.Read())
                items.Add(GetStore_CategoriesFromDataReader(reader));
            return items;
        }


        protected virtual Store_CategoriesDetails GetStore_CategoriesFromDataReader(IDataReader reader)
        {
            return new Store_CategoriesDetails
                (

                     (Guid)reader["CategoryId"],
                      reader["Name"].ToString(),
                      reader["icon"].ToString(),
                     (Int32)reader["Priority"],
                     reader["ParentCategoryId"] as Guid?,
                      reader["ProductsCount"] as Int32?,
                       reader["Username"].ToString(),
                       (Boolean)reader["Status"],
                        (Int32)reader["DomainId"],
                         (Int32)reader["LanguageId"]

                );
        }

        #endregion

        #endregion

        #region Favorite

        public abstract Int32 insertFavorite(Store_FavoriteDetails store_FavoriteDetails);

        public abstract Boolean UpdateFavorite(Store_FavoriteDetails store_FavoriteDetails);

        public abstract Boolean DeleteFavorite(Guid Id);

        public abstract List<Store_FavoriteDetails> GetFavoriteById(Guid Id);

        public abstract List<Store_FavoriteDetails> GetAllFavorite();

        #region Virtual Protected Methods (2)

        protected virtual List<Store_FavoriteDetails> GetStore_FavoriteCollectionFromDataReader(IDataReader reader)
        {
            List<Store_FavoriteDetails> items = new List<Store_FavoriteDetails>();
            while (reader.Read())
                items.Add(GetStore_FavoriteFromDataReader(reader));
            return items;
        }


        protected virtual Store_FavoriteDetails GetStore_FavoriteFromDataReader(IDataReader reader) 
        {
            return new Store_FavoriteDetails
                (

                     (Guid)reader["favoriteId"],
                     (Int32)reader["FavoriteGroupId"],
                    (Guid)reader["ProductId"],
                       (DateTime)reader["EnterDate"],
                        (Int32)reader["DomainId"],
                         (Int32)reader["LanguageId"],
                         reader["Name"].ToString()

                );
        }

        #endregion

        #endregion

        #region FavoriteGroup

        public abstract Int32 insertFavoriteGroup(Store_FavoriteGroupDetails store_FavoriteGroupDetails);

        public abstract Boolean UpdateFavoriteGroup(Store_FavoriteGroupDetails store_FavoriteGroupDetails);

        public abstract Boolean DeleteFavoriteGroup(Int32 Id);

        public abstract List<Store_FavoriteGroupDetails> GetAllFavoriteGroup(); 

        public abstract Store_FavoriteGroupDetails GetFavoriteGroupById(Int32 Id);

        #region Virtual Protected Methods (2)

        protected virtual List<Store_FavoriteGroupDetails> GetStore_FavoriteGroupCollectionFromDataReader(IDataReader reader)
        {
            List<Store_FavoriteGroupDetails> items = new List<Store_FavoriteGroupDetails>();
            while (reader.Read())
                items.Add(GetStore_FavoriteGroupFromDataReader(reader)); 
            return items;
        }


        protected virtual Store_FavoriteGroupDetails GetStore_FavoriteGroupFromDataReader(IDataReader reader)
        {
            return new Store_FavoriteGroupDetails
                (

                     (Int32)reader["FavoriteGroupId"],
                     reader["NameGroup"].ToString(), 
                        (Int32)reader["DomainId"],
                         (Int32)reader["LanguageId"]

                );
        }

        #endregion

        #endregion


        #region PriceDescriptions

        public abstract Int32 insertPriceDescriptions(Store_PriceDescriptionsDetails store_PriceDescriptionsDetails);

        public abstract Boolean UpdatePriceDescriptions(Store_PriceDescriptionsDetails store_PriceDescriptionsDetails);

        public abstract Boolean DeletePriceDescriptions(Guid Id);

        public abstract Store_PriceDescriptionsDetails GetPriceDescriptionsById(Guid Id);

        public abstract List<Store_PriceDescriptionsDetails> GetAllPriceDescriptions();

        #region Virtual Protected Methods (2)

        protected virtual List<Store_PriceDescriptionsDetails> GetStore_PriceDescriptionsCollectionFromDataReader(IDataReader reader)
        {
            List<Store_PriceDescriptionsDetails> items = new List<Store_PriceDescriptionsDetails>();
            while (reader.Read())
                items.Add(GetStore_PriceDescriptionsFromDataReader(reader));
            return items;
        }




        protected virtual Store_PriceDescriptionsDetails GetStore_PriceDescriptionsFromDataReader(IDataReader reader)
        {
            return new Store_PriceDescriptionsDetails
                (

                     (Guid)reader["PriceDescriptionId"],


                     reader["Name"].ToString(),

                     (Int32)reader["Priority"],
                      reader["RoleName"].ToString(),
                      (Boolean)reader["Status"],
                        (Int32)reader["DomainId"],
                         (Int32)reader["LanguageId"]

                );
        }


        #endregion


        #endregion

        #region Prices

        public abstract Int32 insertPrices(Store_PricesDetails store_PricesDetails);

        public abstract Boolean UpdatePrices(Store_PricesDetails store_PricesDetails);

        public abstract Boolean DeletePrices(Guid Id);

        public abstract Store_PricesDetails GetPricesById(Guid Id);

        public abstract List<Store_PricesDetails> GetAllPrices();

        #region Virtual Protected Methods (2)

        protected virtual List<Store_PricesDetails> GetStore__PricesCollectionFromDataReader(IDataReader reader)
        {
            List<Store_PricesDetails> items = new List<Store_PricesDetails>();
            while (reader.Read())
                items.Add(GetStore__PricesFromDataReader(reader));
            return items;
        }




        protected virtual Store_PricesDetails GetStore__PricesFromDataReader(IDataReader reader) 
        {
            return new Store_PricesDetails
                (

                     (Guid)reader["PriceId"],
                     reader["ProductId"] as Guid?,
                      reader["PriceDescriptionId"] as Guid?,
                      (Decimal)reader["Price"],
                     (DateTime)reader["EnterDate"],
                      (Boolean)reader["Status"],
                        (Int32)reader["DomainId"],
                         (Int32)reader["LanguageId"]
                         , reader["NamePriceDes"].ToString()
                         , reader["NameProduct"].ToString() 

                );
        }


        #endregion


        #endregion


        #region ProductsConCategories


        public abstract Int32 insertProductsConCategories(Store_ProductsConCategoriesDetails store_ProductsConCategoriesDetails);

        public abstract Boolean UpdateProductsConCategories(Store_ProductsConCategoriesDetails store_ProductsConCategoriesDetails);

        public abstract Boolean DeleteProductsConCategories(Guid Id, Guid ProductId); 

        public abstract List<Store_ProductsConCategoriesDetails> GetProductsConCategoriesById(Guid Id);

        public abstract List<Store_ProductsConCategoriesDetails> GetProductsConCategoriesByIdAndProductId(Guid ProductId);

        public abstract Store_ProductsConCategoriesDetails GetProductsConCategoriesByCategoryIdAndProductId(Guid Category,Guid ProductId);


        #region Virtual Protected Methods (2)

        protected virtual List<Store_ProductsConCategoriesDetails> GetStore__ProductsConCategoriesCollectionFromDataReader(IDataReader reader)
        {
            List<Store_ProductsConCategoriesDetails> items = new List<Store_ProductsConCategoriesDetails>();
            while (reader.Read())
                items.Add(GetStore__ProductsConCategoriesFromDataReader(reader));
            return items;
        }




        protected virtual Store_ProductsConCategoriesDetails GetStore__ProductsConCategoriesFromDataReader(IDataReader reader)
        {
            return new Store_ProductsConCategoriesDetails
                (

                     (Guid)reader["CategoryId"],
                    (Guid)reader["ProductId"]
                );
        }


        #endregion

        #endregion

        #region ProductsConTags
         
        public abstract Int32 insertProductsConTags(Store_ProductsConTagsDetails store_ProductsConTagsDetails);

        public abstract Boolean UpdateProductsConTags(Store_ProductsConTagsDetails store_ProductsConTagsDetails);

        public abstract Boolean DeleteProductsConTags(Guid Id);

        public abstract List<Store_ProductsConTagsDetails> GetProductsConTagsById(Guid Id);

        #region Virtual Protected Methods (2)

        protected virtual List<Store_ProductsConTagsDetails> GetStore__ProductsConTagsCollectionFromDataReader(IDataReader reader)
        {
            List<Store_ProductsConTagsDetails> items = new List<Store_ProductsConTagsDetails>();
            while (reader.Read())
                items.Add(GetStore__ProductsConTagsFromDataReader(reader)); 
            return items;
        }




        protected virtual Store_ProductsConTagsDetails GetStore__ProductsConTagsFromDataReader(IDataReader reader)
        {
            return new Store_ProductsConTagsDetails
                (

                     (Guid)reader["TagId"],
                    (Guid)reader["ProductId"]
                ); 
        }


        #endregion

        #endregion

        #region Products

        public abstract Guid insertProducts(Store_ProductsDetails store_ProductsDetails);

        public abstract Boolean UpdateProducts(Store_ProductsDetails store_ProductsDetails);

        public abstract Boolean DeleteProducts(Guid Id);

        public abstract Store_ProductsDetails GetProductsById(Guid Id);

        public abstract List<Store_ProductsDetails> GetAllProducts();

     

        public abstract List<Store_ProductsDetails> GetProductByCategory(Guid category);

        #region Virtual Protected Methods (2)

        protected virtual List<Store_ProductsDetails> GetStore_ProductsCollectionFromDataReader(IDataReader reader)
        {
            List<Store_ProductsDetails> items = new List<Store_ProductsDetails>();
            while (reader.Read())
                items.Add(GetStore_ProductsFromDataReader(reader)); 
            return items;
        }


        protected virtual Store_ProductsDetails GetStore_ProductsFromDataReader(IDataReader reader)
        {
            return new Store_ProductsDetails
                (

                     (Guid)reader["ProductId"],
                      reader["Name"].ToString(),
                      reader["Description"].ToString(),
                       reader["MainImage"].ToString(),
                        reader["Condition"].ToString(),
                         reader["Score"] as Byte?,
                         (Boolean)reader["Status"],
                     (DateTime)reader["EnterDate"],
                     reader["LastUpdateDate"] as DateTime?,  
                       reader["Username"].ToString(),
                        (Int32)reader["DomainId"],
                         (Int32)reader["LanguageId"]

                );
        }

        #endregion

        #endregion


        #region Setting

        public abstract Int32 insertSetting(Store_SettingDetails store_SettingDetails);

        public abstract Boolean UpdateSetting(Store_SettingDetails store_SettingDetails);

        public abstract Boolean DeleteSetting(Guid Id);

        public abstract List<Store_SettingDetails> GetSettingById(Guid Id);
        #region Virtual Protected Methods (2)

        protected virtual List<Store_SettingDetails> GetStore_SettingCollectionFromDataReader(IDataReader reader)
        {
            List<Store_SettingDetails> items = new List<Store_SettingDetails>();
            while (reader.Read())
                items.Add(GetStore_SettingFromDataReader(reader));
            return items;
        }


        protected virtual Store_SettingDetails GetStore_SettingFromDataReader(IDataReader reader)
        {
            return new Store_SettingDetails
                (

                     (Guid)reader["SettingId"],
                      reader["Parameter"].ToString(),
                      reader["Value1"].ToString(),
                       reader["Value2"].ToString(),
                        reader["Value3"].ToString(),
                         reader["Value4"].ToString(),
                         reader["Value5"].ToString(),
                           (Int32)reader["DomainId"],
                         (Int32)reader["LanguageId"]

                  
                );
        }

        #endregion

        #endregion


        #region SpecificationGroups

        public abstract Int32 insertSpecificationGroups(Store_SpecificationGroupsDetails store_SpecificationGroupsDetails);

        public abstract Boolean UpdateSpecificationGroups(Store_SpecificationGroupsDetails store_SpecificationGroupsDetails);

        public abstract Boolean DeleteSpecificationGroups(Guid Id);

        public abstract Store_SpecificationGroupsDetails GetSpecificationGroupsById(Guid Id);

        public abstract List<Store_SpecificationGroupsDetails> GetAllSpecificationGroups(); 

        #region Virtual Protected Methods (2)

        protected virtual List<Store_SpecificationGroupsDetails> GetStore_SpecificationGroupsCollectionFromDataReader(IDataReader reader)
        {
            List<Store_SpecificationGroupsDetails> items = new List<Store_SpecificationGroupsDetails>();
            while (reader.Read())
                items.Add(GetStore_SpecificationGroupsFromDataReader(reader)); 
            return items;
        }


        protected virtual Store_SpecificationGroupsDetails GetStore_SpecificationGroupsFromDataReader(IDataReader reader)
        {
            return new Store_SpecificationGroupsDetails
                (

                     (Guid)reader["SpecificationGroupId"],
                      reader["Name"].ToString(),
                           (Int32)reader["DomainId"],
                         (Int32)reader["LanguageId"]


                );
        }

        #endregion

        #endregion


        #region SpecificationTexts
        public abstract Int32 insertSpecificationTexts(Store_SpecificationTextsDetails store_SpecificationTextsDetails);

        public abstract Boolean UpdateSpecificationTexts(Store_SpecificationTextsDetails store_SpecificationTextsDetails);

        public abstract Boolean DeleteSpecificationTexts(Guid Id);

        public abstract Store_SpecificationTextsDetails GetSpecificationTextsById(Guid Id);

        public abstract List<Store_SpecificationTextsDetails> GetAllSpecificationTexts();

        public abstract List<Store_SpecificationTextsDetails> GetSpecificationTextsByGroups(Guid groupId);

        public abstract List<Store_SpecificationTextsDetails> GetSpecificationTextsBySpecificationTextIdAndSpecificationTitleId(Guid specificationTextId, Guid specificationTitleId);

        #region Virtual Protected Methods (2)

        protected virtual List<Store_SpecificationTextsDetails> GetStore_SpecificationTextsCollectionFromDataReader(IDataReader reader)
        {
            List<Store_SpecificationTextsDetails> items = new List<Store_SpecificationTextsDetails>();
            while (reader.Read())
                items.Add(GetStore_SpecificationTextsFromDataReader(reader));
            return items;
        }


        protected virtual Store_SpecificationTextsDetails GetStore_SpecificationTextsFromDataReader(IDataReader reader)
        {
            return new Store_SpecificationTextsDetails
                (

                     (Guid)reader["SpecificationTextId"],
                       (Guid)reader["SpecificationTitleId"], 
                       (Guid)reader[""],
                      reader["Text"].ToString(),
                       reader["Description"].ToString(), 
                           (Int32)reader["DomainId"],
                         (Int32)reader["LanguageId"],
                         reader["Name"].ToString(),
                         reader[""].ToString()
                        


                );
        }

        #endregion
        #endregion


        #region SpecificationTitles


        public abstract Int32 insertSpecificationTitles(Store_SpecificationTitlesDetails store_SpecificationTitlesDetails);

        public abstract Boolean UpdateSpecificationTitles(Store_SpecificationTitlesDetails store_SpecificationTitlesDetails);

        public abstract Boolean DeleteSpecificationTitles(Guid Id);

        public abstract List<Store_SpecificationTitlesDetails> GetSpecificationTitlesBySpecificationGroupId(Guid specificationGroupId);   

        public abstract Store_SpecificationTitlesDetails GetSpecificationTitlesById(Guid id);

        public abstract List<Store_SpecificationTitlesDetails> GetAllSpecificationTitles();

        #region Virtual Protected Methods (2)

        protected virtual List<Store_SpecificationTitlesDetails> GetStore_SpecificationTitlesCollectionFromDataReader(IDataReader reader)
        {
            List<Store_SpecificationTitlesDetails> items = new List<Store_SpecificationTitlesDetails>();
            while (reader.Read())
                items.Add(GetStore_SpecificationTitlesFromDataReader(reader));
            return items;
        }


        protected virtual Store_SpecificationTitlesDetails GetStore_SpecificationTitlesFromDataReader(IDataReader reader)
        {
            return new Store_SpecificationTitlesDetails
                (

                     (Guid)reader["SpecificationTitleId"],
                       (Guid)reader["SpecificationGroupId"],
                      reader["Name"].ToString(), 
                       reader["Description"].ToString(),
                           (Int32)reader["DomainId"],
                         (Int32)reader["LanguageId"]


                );
        }

        #endregion


        #endregion


        #region TabDescriptions

        public abstract Int32 insertTabDescriptions(Store_TabDescriptionsDetails store_TabDescriptionsDetails);

        public abstract Boolean UpdateTabDescriptions(Store_TabDescriptionsDetails store_TabDescriptionsDetails);

        public abstract Boolean DeleteTabDescriptions(Guid Id);

        public abstract List<Store_TabDescriptionsDetails> GetTabDescriptionsById(Guid Id);

        #region Virtual Protected Methods (2)

        protected virtual List<Store_TabDescriptionsDetails> GetStore_TabDescriptionsCollectionFromDataReader(IDataReader reader)
        {
            List<Store_TabDescriptionsDetails> items = new List<Store_TabDescriptionsDetails>();
            while (reader.Read())
                items.Add(GetStore_TabDescriptionsFromDataReader(reader));
            return items;
        }


        protected virtual Store_TabDescriptionsDetails GetStore_TabDescriptionsFromDataReader(IDataReader reader)
        {
            return new Store_TabDescriptionsDetails
                (

                     (Guid)reader["TabDescriptionId"],
                       (Guid)reader["ProductId"],
                      reader["Name"].ToString(),
                       reader["Description"].ToString(),
                           (Int32)reader["DomainId"],
                         (Int32)reader["LanguageId"]


                );
        }

        #endregion


        #endregion


        #region TagGroups


        public abstract Int32 insertTagGroups(Store_TagGroupsDetails store_TagGroupsDetails);

        public abstract Boolean UpdateTagGroups(Store_TagGroupsDetails store_TagGroupsDetails);

        public abstract Boolean DeleteTagGroups(Guid Id);

        public abstract List<Store_TagGroupsDetails> GetTagGroupsById(Guid Id);

        #region Virtual Protected Methods (2)

        protected virtual List<Store_TagGroupsDetails> GetStore_TagGroupsCollectionFromDataReader(IDataReader reader)
        {
            List<Store_TagGroupsDetails> items = new List<Store_TagGroupsDetails>();
            while (reader.Read())
                items.Add(GetStore_TagGroupsFromDataReader(reader));
            return items;
        }


        protected virtual Store_TagGroupsDetails GetStore_TagGroupsFromDataReader(IDataReader reader)
        {
            return new Store_TagGroupsDetails
                (

                     (Guid)reader["TagGroupId"],
                      reader["Name"].ToString(),
                       reader["Description"].ToString(),
                           (Int32)reader["DomainId"],
                         (Int32)reader["LanguageId"]


                );
        }

        #endregion

        #endregion

        #region Tags
        public abstract Int32 insertTags(Store_TagsDetails store_TagsDetails);

        public abstract Boolean UpdateTags(Store_TagsDetails store_TagsDetails);

        public abstract Boolean DeleteTags(Guid Id);

        public abstract List<Store_TagsDetails> GetTagsById(Guid Id);


        #region Virtual Protected Methods (2)

        protected virtual List<Store_TagsDetails> GetStore_TagsCollectionFromDataReader(IDataReader reader)
        {
            List<Store_TagsDetails> items = new List<Store_TagsDetails>();
            while (reader.Read())
                items.Add(GetStore_TagsFromDataReader(reader));
            return items;
        } 


        protected virtual Store_TagsDetails GetStore_TagsFromDataReader(IDataReader reader)
        {
            return new Store_TagsDetails
                (

                     (Guid)reader["TagId"],
                      (Guid)reader["TagGroupId"],  
                      reader["Name"].ToString(),
                           (Int32)reader["DomainId"],
                         (Int32)reader["LanguageId"]


                );
        }

        #endregion

        #endregion

        #region UserScores 

        public abstract Int32 insertUserScores(Store_UserScoresDetails store_UserScoresDetails);

        public abstract Boolean UpdateUserScores(Store_UserScoresDetails store_UserScoresDetails);

        public abstract Boolean DeleteUserScores(Guid Id);

        public abstract List<Store_UserScoresDetails> GetUserScoresById(Guid Id);  

         #region Virtual Protected Methods (2)

        protected virtual List<Store_UserScoresDetails> GetStore_UserScoresCollectionFromDataReader(IDataReader reader)
        {
            List<Store_UserScoresDetails> items = new List<Store_UserScoresDetails>();
            while (reader.Read())
                items.Add(GetStore_UserScoresFromDataReader(reader));
            return items;
        }


        protected virtual Store_UserScoresDetails GetStore_UserScoresFromDataReader(IDataReader reader)
        {
            return new Store_UserScoresDetails
                (

                     (Guid)reader["UserScoreId"],
                      (Guid)reader["UserScoreTitleId"],
                      reader["Username"].ToString(),
                       (Byte)reader["Score"],
                           (Int32)reader["DomainId"],
                         (Int32)reader["LanguageId"]


                );
        }

        #endregion
        #endregion

        #region UserScoreTitles

        public abstract Int32 insertUserScoreTitles(Store_UserScoreTitlesDetails store_UserScoreTitlesDetails);

        public abstract Boolean UpdateUserScoreTitles(Store_UserScoreTitlesDetails store_UserScoreTitlesDetails);

        public abstract Boolean DeleteUserScoreTitles(Guid Id);

        public abstract List<Store_UserScoreTitlesDetails> GetUserScoreTitlesById(Guid Id);


        #region Virtual Protected Methods (2)

        protected virtual List<Store_UserScoreTitlesDetails> GetStore_UserScoreTitlesCollectionFromDataReader(IDataReader reader)
        {
            List<Store_UserScoreTitlesDetails> items = new List<Store_UserScoreTitlesDetails>();
            while (reader.Read())
                items.Add(GetStore_UserScoreTitlesFromDataReader(reader)); 
            return items;
        }

         
        protected virtual Store_UserScoreTitlesDetails GetStore_UserScoreTitlesFromDataReader(IDataReader reader)
        {
            return new Store_UserScoreTitlesDetails
                (

                     (Guid)reader["UserScoreTitleId"],
                      (Guid)reader["ProductId"],
                      reader["Name"].ToString(),
                        reader["Description"].ToString(),
                           (Int32)reader["DomainId"],
                         (Int32)reader["LanguageId"]


                );
        }

        #endregion

        #endregion

        #region Store_ProductsConSpecificationText

        public abstract Int32 InsertProductsConSpecificationText(Store_ProductsConSpecificationTextsDetails store_ProductsConSpecificationTexts);

        public abstract Boolean DeleteProductsConSpecificationTextByProductId( Guid productId);

        public abstract Boolean DeleteProductsConSpecificationTextByspecificationTextId(Guid specificationTextId);

        public abstract List<Store_ProductsConSpecificationTextsDetails> GetProductsConSpecificationTextByProductId(Guid productId);

        public abstract List<Store_ProductsConSpecificationTextsDetails> GetAllProductsConSpecificationText();

        #region Virtual Protected Methods (2)

        protected virtual List<Store_ProductsConSpecificationTextsDetails> GetStore__ProductsConSpecificationTextCollectionFromDataReader(IDataReader reader)
        {
            List<Store_ProductsConSpecificationTextsDetails> items = new List<Store_ProductsConSpecificationTextsDetails>();
            while (reader.Read())
                items.Add(GetStore__ProductsConSpecificationTextFromDataReader(reader));
            return items;
        }




        protected virtual Store_ProductsConSpecificationTextsDetails GetStore__ProductsConSpecificationTextFromDataReader(IDataReader reader)
        {
            return new Store_ProductsConSpecificationTextsDetails
                (

                     (Guid)reader["ProductId"],
                    (Guid)reader["SpecificationTextId"],
                    (String)reader["Description"]
                );
        }


        #endregion
        #endregion

        #region Store_Specification

        public abstract List<Store_SpecificationDetails> GetSpecificationJoin(Guid productId);
        #region Virtual Protected Methods (2)

        protected virtual List<Store_SpecificationDetails> GetStore__SpecificationCollectionFromDataReader(IDataReader reader)
        {
            List<Store_SpecificationDetails> items = new List<Store_SpecificationDetails>();
            while (reader.Read())
                items.Add(GetStore__SpecificationFromDataReader(reader));
            return items;
        }




        protected virtual Store_SpecificationDetails GetStore__SpecificationFromDataReader(IDataReader reader)
        {
            return new Store_SpecificationDetails
                (

                     (String)reader["Name"],
                    (String)reader["Text"],
                    (String)reader["Description"]
                );
        }


        #endregion 
        #endregion



        #region  ProductsConModules

        public abstract Int32 InsertProductsConModules(Store_ProductsConModulesDetails store_ProductsConModulesDetails);

       // public abstract Boolean UpdateProductsConModules(Store_UserScoresDetails store_UserScoresDetails);

        public abstract Boolean DeleteProductsConModules(Guid productId);

     //   public abstract List<Store_UserScoresDetails> GetUserScoresById(Guid Id);  

        #region Virtual Protected Methods (2)

        protected virtual List<Store_ProductsConModulesDetails> GetStore_ProductsConModulesCollectionFromDataReader(IDataReader reader)
        {
            List<Store_ProductsConModulesDetails> items = new List<Store_ProductsConModulesDetails>();
            while (reader.Read())
                items.Add(GetStore_ProductsConModulesFromDataReader(reader));
            return items;
        }


        protected virtual Store_ProductsConModulesDetails GetStore_ProductsConModulesFromDataReader(IDataReader reader)
        {
            return new Store_ProductsConModulesDetails
                (

                 (Guid)reader["ProductId"],
                 (Int32)reader["IdModule"],
                      reader["Description"].ToString(),
                      reader["Value1"].ToString(),
                       reader["Value2"].ToString(),
                        reader["Value3"].ToString(),
                         reader["Value4"].ToString(),
                         reader["Value5"].ToString()
                );
        }

        #endregion

        #endregion

      
        
        #region  Store_TabModules

        public abstract Int32 InsertTabModules(Store_TabModulesDetails store_TabModulesDetails);

        // public abstract Boolean UpdateProductsConModules(Store_UserScoresDetails store_UserScoresDetails);

        public abstract Boolean DeleteTabModules(Int32 idModule);

        //   public abstract List<Store_UserScoresDetails> GetUserScoresById(Guid Id);  

        #region Virtual Protected Methods (2)

        protected virtual List<Store_TabModulesDetails> GetStore_TabModulesCollectionFromDataReader(IDataReader reader)
        {
            List<Store_TabModulesDetails> items = new List<Store_TabModulesDetails>();
            while (reader.Read())
                items.Add(GetStore_TabModulesFromDataReader(reader));
            return items;
        }


        protected virtual Store_TabModulesDetails GetStore_TabModulesFromDataReader(IDataReader reader)
        {
            return new Store_TabModulesDetails
                (

                     
                     (Int32)reader["IdModule"],
                      reader["Name"].ToString(),
                      reader["Description"].ToString(),
                       reader["UserControlAddress"].ToString(),
                        (Boolean)reader["IsActive"],
                         (Int32)reader["DomainId"],
                        (Int32)reader["LanguageId"]



                );
        }

        #endregion

        #endregion


    }
       
}
