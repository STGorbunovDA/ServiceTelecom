﻿using ServiceTelecom.Models;
using ServiceTelecom.Repositories;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace ServiceTelecom.ViewModels.WorkViewModelPackage
{
    internal class ChangeNumberActViewModel : ViewModelBase
    {
        WorkRadiostantionRepository _workRepositoryRadiostantion;
        WorkRadiostantionFullRepository _workRepositoryRadiostantionFull;

        #region свойства

        private string _newNumberAct;
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
            _workRepositoryRadiostantion = new WorkRadiostantionRepository();
            _workRepositoryRadiostantionFull = new WorkRadiostantionFullRepository();
            ChangeNumberActRadiostationsForDocumentInDB =
                new ViewModelCommand(
                    ExecuteChangeNumberActRadiostationsForDocumentInDBCommand);
            foreach (var item in
                        UserModelStatic.STAFF_REGISTRATIONS_DATABASE_MODEL_COLLECTION)
                NewNumberAct = item.NumberPrintDocumentBase + "/";
        }


        #region ChangeNumberActRadiostationForDocumentInDB

        private void ExecuteChangeNumberActRadiostationsForDocumentInDBCommand(object obj)
        {
            if (MessageBox.Show("Подтверждаете изменение акта?", "Внимание",
                   MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                return;
            if (String.IsNullOrWhiteSpace(NewNumberAct))
            {
                MessageBox.Show("Поле \"№ Акта ТО\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (!Regex.IsMatch(NewNumberAct,
                @"[0-9]{2,2}/([0-9]+([A-Z]?[А-Я]?)*[.\-]?[0-9]?[0-9]?[0-9]?[A-Z]?[А-Я]?)$"))
            {
                MessageBox.Show("Введите корректно поле \"№ Акта ТО\"", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            foreach (RadiostationForDocumentsDataBaseModel item 
                in UserModelStatic.RADIOSTATIONS_FOR_DOCUMENTS_MULIPLE_SELECTED_DATAGRID)
            {
                if (_workRepositoryRadiostantionFull.
                ChangeNumberActBySerialNumberInDBRadiostationFull(
                item.Road, item.City, item.SerialNumber, NewNumberAct))
                { }
                else
                {
                    MessageBox.Show("Ошибка изменения номера акта радиостанции " +
                        "в radiostantionFull(таблице)", "Отмена", MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    break;
                }
                if (_workRepositoryRadiostantion.
                    ChangeNumberActBySerialNumberInDatabase(
                    item.Road, item.City, item.SerialNumber, NewNumberAct))
                { }
                else
                {
                    MessageBox.Show("Ошибка изменения номера акта радиостанции",
                        "Отмена", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
                }         
            }
            UserModelStatic.RADIOSTATIONS_FOR_DOCUMENTS_MULIPLE_SELECTED_DATAGRID = null;
            MessageBox.Show("Успешно", "Информация",
                        MessageBoxButton.OK, MessageBoxImage.Information);
        }

        #endregion

    }
}
