using System;
using System.Linq;

namespace Pine.Dal.Core
{

    public class CoreUserControlPaths_PageContentsDetails
    {

        #region Constructors (2)


        public CoreUserControlPaths_PageContentsDetails(String path, Int32 userControlPathId, Int32? coreParameterId)
        {
            Path = path;
            UserControlPathId = userControlPathId;
            CoreParameterId = coreParameterId;
        }



        public CoreUserControlPaths_PageContentsDetails()
        {
        }

        #endregion Constructors

        #region Properties (3)


        public String Path { get; set; }


        public Int32  UserControlPathId { get; set; }


        public Int32? CoreParameterId { get; set; }


        #endregion Properties

    }
}
