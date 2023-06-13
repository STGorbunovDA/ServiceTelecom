using MySql.Data.MySqlClient;
using ServiceTelecom.Infrastructure;

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
        //TODO измерить время авторизации
        readonly MySqlConnection connection = new MySqlConnection($"server=31.31.198.62;port=3306;" +
            $"username={Encryption.DecryptCipherTextToPlainText("vKGbDdqaoW8UbfKI44/flQ==")};" +
            $"password={Encryption.DecryptCipherTextToPlainText("fuB1hXCQ1pYUBw+qqevUc7uqOmtN19aQ")};" +
            $"database={Encryption.DecryptCipherTextToPlainText("vKGbDdqaoW+93a+IIGwtEvH5h0BsY+fx")};" +
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
