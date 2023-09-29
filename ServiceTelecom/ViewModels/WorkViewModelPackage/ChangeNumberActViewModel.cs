using ServiceTelecom.Models;
using ServiceTelecom.Models.Base;
using ServiceTelecom.Repositories;
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace ServiceTelecom.ViewModels.WorkViewModelPackage
{
    internal class ChangeNumberActViewModel : ViewModelBase
    {
        WorkRadiostantionRepository _workRadiostantionRepository;
        WorkRadiostantionFullRepository _workRadiostantionFullRepository;
        RadiostationParametersRepository _radiostationParametersRepository;

        #region свойства

        string _newNumberAct;
        public string NewNumberAct
        {
            get => _newNumberAct;
            set
            {
                _newNumberAct = value;
                OnPropertyChanged(nameof(NewNumberAct));
            }
        }

        #endregion

        public ICommand ChangeNumberActRadiostationsForDocumentInDB { get; }
        public ChangeNumberActViewModel()
        {
            _workRadiostantionRepository = new WorkRadiostantionRepository();
            _workRadiostantionFullRepository = new WorkRadiostantionFullRepository();
            _radiostationParametersRepository = new RadiostationParametersRepository();
            ChangeNumberActRadiostationsForDocumentInDB =
                new ViewModelCommand(
                    ExecuteChangeNumberActRadiostationsForDocumentInDBCommand);
            StringBuilder sb = new StringBuilder();
            foreach (var item in GlobalCollection.STAFF_REGISTRATIONS_DATABASE_MODEL_COLLECTION)
            {
                if (GlobalValue.ROAD == item.RoadBase)
                {
                    sb.Append(item.NumberPrintDocumentBase);
                    sb.Append("/");
                    break;
                }     
            }
            NewNumberAct = sb.ToString().TrimEnd();
        }


        #region ChangeNumberActRadiostationForDocumentInDB

        bool CheckNewNumberAct()
        {
            if (String.IsNullOrWhiteSpace(NewNumberAct))
            {
                MessageBox.Show("Поле \"№ Акта ТО\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            if (!Regex.IsMatch(NewNumberAct,
                @"[0-9]{2,2}/([0-9]+([A-Z]?[А-Я]?)*[.\-]?[0-9]?[0-9]?[0-9]?[A-Z]?[А-Я]?)$"))
            {
                MessageBox.Show("Введите корректно поле \"№ Акта ТО\"", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            return true;
        }

        void ExecuteChangeNumberActRadiostationsForDocumentInDBCommand(object obj)
        {
            if (MessageBox.Show("Подтверждаете изменение акта?", "Внимание",
                   MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                return;
            if (!CheckNewNumberAct())
                return;

            foreach (RadiostationForDocumentsDataBaseModel item
                in GlobalCollection.RADIOSTATIONS_FOR_DOCUMENTS_MULIPLE_SELECTED_DATAGRID)
            {
                if (_radiostationParametersRepository.CheckSerialNumberInRadiostationParameters(
                    item.Road, item.SerialNumber))
                {
                    if (!_radiostationParametersRepository.ChangeNumberActForRadiostationParameters
                    (item.Road, item.SerialNumber, NewNumberAct))
                        MessageBox.Show("Ошибка изменения номера акта радиостанции " +
                            "в radiostation_parameters(таблица)", "Отмена", MessageBoxButton.OK,
                        MessageBoxImage.Error);
                }

                if (_workRadiostantionFullRepository.ChangeNumberActBySerialNumberInDBRadiostationFull(
                item.Road, item.City, item.SerialNumber, NewNumberAct)){ }
                else
                {
                    MessageBox.Show("Ошибка изменения номера акта радиостанции " +
                        "в radiostantionFull(таблице)", "Отмена", MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    break;
                }
                if (_workRadiostantionRepository.ChangeNumberActBySerialNumberInDatabase(
                    item.Road, item.City, item.SerialNumber, NewNumberAct)) { }
                else
                {
                    MessageBox.Show("Ошибка изменения номера акта радиостанции в radiostantion(таблице)",
                        "Отмена", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
                }
            }
            GlobalCollection.RADIOSTATIONS_FOR_DOCUMENTS_MULIPLE_SELECTED_DATAGRID = null;
            MessageBox.Show("Успешно", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        #endregion

    }
}
