using MySql.Data.MySqlClient;
using ServiceTelecom.Models;

namespace ServiceTelecom.Repositories
{
    class RepositoryDataBase
    {
        static volatile RepositoryDataBase Class;
        static object SyncObject = new object();
        public static RepositoryDataBase GetInstance
        {
            get
            {
                if (Class == null)
                    lock (SyncObject)
                    {
                        if (Class == null)
                            Class = new RepositoryDataBase();
                    }
                return Class;
            }
        }
        readonly MySqlConnection connection = new MySqlConnection(
            $"server={UserModelStatic.SERVER};" +
            $"port={UserModelStatic.PORT};" +
            $"username={UserModelStatic.USERNAME};" +
            $"password={UserModelStatic.PASSWORD};" +
            $"database={UserModelStatic.DATABASE};" +
            $"charset=utf8");

        public MySqlConnection GetConnection()
        {
            return connection;
        }

        public void OpenConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();
        }

        public void CloseConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();
        }
    }
}
