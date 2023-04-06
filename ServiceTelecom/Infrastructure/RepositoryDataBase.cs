using MySql.Data.MySqlClient;
using ServiceTelecom.Infrastructure;
using System;

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
            $"username={Encryption.DecryptCipherTextToPlainText(StaticConfig.userName)};" +
            $"password={Encryption.DecryptCipherTextToPlainText(StaticConfig.password)};" +
            $"database={Encryption.DecryptCipherTextToPlainText(StaticConfig.dataBase)};" +
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
