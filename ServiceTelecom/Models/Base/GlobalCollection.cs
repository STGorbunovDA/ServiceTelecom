using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ServiceTelecom.Models.Base
{
    public static class GlobalCollection
    {
        //static volatile GlobalCollection Class;
        //static object SyncObject = new object();
        //public static GlobalCollection GetInstance
        //{
        //    get
        //    {
        //        if (Class == null)
        //            lock (SyncObject)
        //            {
        //                if (Class == null)
        //                    Class = new GlobalCollection();
        //            }
        //        return Class;
        //    }
        //}

        public static IList RADIOSTATIONS_FOR_DOCUMENTS_MULIPLE_SELECTED_DATAGRID;
        public static IList PARAMETERS_RADIOSTATION_FOR_ADD_RADIOSTATION_PARAMETERS_VIEW;
        public static IList PARAMETERS_RADIOSTATION_GENERAL;

        public static ObservableCollection<StaffRegistrationDataBaseModel> STAFF_REGISTRATIONS_DATABASE_MODEL_COLLECTION { get; set; }

        public static List<RepositoryDataBaseModel> LIST_REPOSITORY_DATABASE;

        static GlobalCollection()
        {
            STAFF_REGISTRATIONS_DATABASE_MODEL_COLLECTION = new ObservableCollection<StaffRegistrationDataBaseModel>();
            LIST_REPOSITORY_DATABASE = new List<RepositoryDataBaseModel>();
        }
    }
}
