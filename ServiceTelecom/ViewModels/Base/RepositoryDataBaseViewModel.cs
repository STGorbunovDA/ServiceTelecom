using ServiceTelecom.Infrastructure;
using ServiceTelecom.Models;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace ServiceTelecom.ViewModels.Base
{
    internal class RepositoryDataBaseViewModel : ViewModelBase
    {
        List<RepositoryDataBaseModel> listRepositoryDataBaseModel;
        GetSetRegistryServiceTelecomSetting getSetRegistry;

        #region Свойства

        private string _server;
        public string Server
        {
            get => _server;
            set
            {
                _server = value;
                OnPropertyChanged(nameof(Server));
            }
        }

        private string _port;
        public string Port
        {
            get => _port;
            set
            {
                _port = value;
                OnPropertyChanged(nameof(Port));
            }
        }

        private string _codeWord;
        public string CodeWord
        {
            get => _codeWord;
            set
            {
                _codeWord = value;
                OnPropertyChanged(nameof(CodeWord));
            }
        }

        private string _username;
        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        private string _database;
        public string Database
        {
            get => _database;
            set
            {
                _database = value;
                OnPropertyChanged(nameof(Database));
            }
        }

        #endregion

        public ICommand RecordingData { get; }

        public RepositoryDataBaseViewModel()
        {
            getSetRegistry = new GetSetRegistryServiceTelecomSetting();
            RecordingData = new ViewModelCommand(ExecuteRecordingDataCommand);

            listRepositoryDataBaseModel = new List<RepositoryDataBaseModel>();
            listRepositoryDataBaseModel = getSetRegistry.GetRegistryForRepositoryDataBase();

            if (listRepositoryDataBaseModel.Count != 0)
                foreach (var item in listRepositoryDataBaseModel)
                {
                    Server = item.Server;
                    Port = item.Port;
                    Username = item.Username;
                    Password = item.Password;
                    Database = item.Database;
                    CodeWord = item.CodeWord;
                }
        }


        #region RecordingData

        private void ExecuteRecordingDataCommand(object obj)
        {
            if (String.IsNullOrWhiteSpace(Server))
            {
                MessageBox.Show("Поле \"Server\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (String.IsNullOrWhiteSpace(Port))
            {
                MessageBox.Show("Поле \"Port\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (String.IsNullOrWhiteSpace(Username))
            {
                MessageBox.Show("Поле \"Username\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (String.IsNullOrWhiteSpace(Password))
            {
                MessageBox.Show("Поле \"Password\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (String.IsNullOrWhiteSpace(Database))
            {
                MessageBox.Show("Поле \"Database\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (String.IsNullOrWhiteSpace(CodeWord))
            {
                MessageBox.Show("Поле \"CodeWord\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if (getSetRegistry.SetRegistryForRepositoryDataBaseAndCodeWord(
                Server, Port, Username, Password, Database, CodeWord))
                MessageBox.Show("Успешно", "Информация",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show($"Ошибка добавления параметров",
                         "Отмена", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        #endregion
    }
}
