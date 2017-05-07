using System;
using System.Linq;

namespace Pine.Dal.Core
{

    public class CoreMasterPageNamesCorePagesDetails
    {

        #region Constructors (2)


        public CoreMasterPageNamesCorePagesDetails(Int32 masterPageNameId, Int32 pageId, String themeName, String path, String pathSmallImage, String nameImage)
        {
            MasterPageNameId = masterPageNameId;
            PageId = pageId;
            ThemeName = themeName;
            Path = path;
            PathSmallImage = pathSmallImage;
            NameImage = nameImage;
        }



        public CoreMasterPageNamesCorePagesDetails()
        {
        }

        #endregion Constructors

        #region Properties (3)

        public Int32 MasterPageNameId { get; set; }

        public Int32 PageId { get; set; }


        public String ThemeName { get; set; }


        public String Path { get; set; }

        public String PathSmallImage { get; set; }

        public String NameImage { get; set; }

        #endregion Properties

    }
}
