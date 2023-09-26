using ServiceTelecom.Infrastructure;
using ServiceTelecom.Infrastructure.Interfaces;
using ServiceTelecom.Models;
using ServiceTelecom.Models.Base;
using ServiceTelecom.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using System.Windows.Input;

namespace ServiceTelecom.ViewModels.WorkViewModelPackage
{
    internal class PrintRepairViewModel : ViewModelBase, ICloseWindows
    {
        GetSetRegistryServiceTelecomSetting getSetRegistryServiceTelecomSetting;
        Print printExcel;
        WorkRadiostantionFullRepository _workRadiostantionFullRepository;
        List<RepairDataCompanyModel> repairData;

        public IList RadiostationsForDocumentsMulipleSelectedDataGrid;

        #region Свойства

        public Action Close { get; set; }

        public string PrimaryMeans { get; set; }
        public string ProductName { get; set; }
        public string Road { get; set; }
        public string City { get; set; }
        public string SerialNumber { get; set; }


        string _company;
        public string Company
        {
            get => _company;
            set
            {
                _company = value;
                OnPropertyChanged(nameof(Company));
            }
        }
        string _OKPO;
        public string OKPO
        {
            get => _OKPO;
            set
            {
                _OKPO = value;
                OnPropertyChanged(nameof(OKPO));
            }
        }
        string _BE;
        public string BE
        {
            get => _BE;
            set
            {
                _BE = value;
                OnPropertyChanged(nameof(BE));
            }
        }
        string _fullNameCompany;
        public string FullNameCompany
        {
            get => _fullNameCompany;
            set
            {
                _fullNameCompany = value;
                OnPropertyChanged(nameof(FullNameCompany));
            }
        }
        string _chiefСompanyFIO;
        public string ChiefСompanyFIO
        {
            get => _chiefСompanyFIO;
            set
            {
                _chiefСompanyFIO = value;
                OnPropertyChanged(nameof(ChiefСompanyFIO));
            }
        }
        string _chiefСompanyPost;
        public string ChiefСompanyPost
        {
            get => _chiefСompanyPost;
            set
            {
                _chiefСompanyPost = value;
                OnPropertyChanged(nameof(ChiefСompanyPost));
            }
        }
        string _chairmanСompanyFIO;
        public string ChairmanСompanyFIO
        {
            get => _chairmanСompanyFIO;
            set
            {
                _chairmanСompanyFIO = value;
                OnPropertyChanged(nameof(ChairmanСompanyFIO));
            }
        }
        string _chairmanСompanyPost;
        public string ChairmanСompanyPost
        {
            get => _chairmanСompanyPost;
            set
            {
                _chairmanСompanyPost = value;
                OnPropertyChanged(nameof(ChairmanСompanyPost));
            }
        }
        string _firstMemberCommissionFIO;
        public string FirstMemberCommissionFIO
        {
            get => _firstMemberCommissionFIO;
            set
            {
                _firstMemberCommissionFIO = value;
                OnPropertyChanged(nameof(FirstMemberCommissionFIO));
            }
        }
        string _firstMemberCommissionPost;
        public string FirstMemberCommissionPost
        {
            get => _firstMemberCommissionPost;
            set
            {
                _firstMemberCommissionPost = value;
                OnPropertyChanged(nameof(FirstMemberCommissionPost));
            }
        }
        string _secondMemberCommissionFIO;
        public string SecondMemberCommissionFIO
        {
            get => _secondMemberCommissionFIO;
            set
            {
                _secondMemberCommissionFIO = value;
                OnPropertyChanged(nameof(SecondMemberCommissionFIO));
            }
        }
        string _secondMemberCommissionPost;
        public string SecondMemberCommissionPost
        {
            get => _secondMemberCommissionPost;
            set
            {
                _secondMemberCommissionPost = value;
                OnPropertyChanged(nameof(SecondMemberCommissionPost));
            }
        }
        string _thirdMemberCommissionFIO;
        public string ThirdMemberCommissionFIO
        {
            get => _thirdMemberCommissionFIO;
            set
            {
                _thirdMemberCommissionFIO = value;
                OnPropertyChanged(nameof(ThirdMemberCommissionFIO));
            }
        }
        string _thirdMemberCommissionPost;
        public string ThirdMemberCommissionPost
        {
            get => _thirdMemberCommissionPost;
            set
            {
                _thirdMemberCommissionPost = value;
                OnPropertyChanged(nameof(ThirdMemberCommissionPost));
            }
        }
        bool _checkBoxDisableThirdVerification;
        public bool CheckBoxDisableVerificationSurname
        {
            get => _checkBoxDisableThirdVerification;
            set
            {
                _checkBoxDisableThirdVerification = value;
                OnPropertyChanged(nameof(CheckBoxDisableVerificationSurname));
            }
        }

        #endregion

        public ICommand AddInRegistryInformationCompany { get; }
        public ICommand ContinuePrintRepair { get; }
        public ICommand CloseWindowCommand { get; }

        public PrintRepairViewModel()
        {
            _workRadiostantionFullRepository = new WorkRadiostantionFullRepository();
            getSetRegistryServiceTelecomSetting = new GetSetRegistryServiceTelecomSetting();
            repairData = new List<RepairDataCompanyModel>();

            CloseWindowCommand =
                new ViewModelCommand(ExecuteCloseWindowCommand);
            printExcel = new Print();
            AddInRegistryInformationCompany =
                new ViewModelCommand(ExecuteAddInRegistryInformationCompanyCommand);
            ContinuePrintRepair =
                new ViewModelCommand(ExecuteContinuePrintRepairCommand);

            GetRoadCitySerialNumberCompany();

            GetLegalCharacteristicsCompany();

            //Для печати отдельно в потоке
            RadiostationsForDocumentsMulipleSelectedDataGrid
                = GlobalCollection.RADIOSTATIONS_FOR_DOCUMENTS_MULIPLE_SELECTED_DATAGRID;

            GetProductNameInDataBase();
            GetPrimaryMeansInDataBase();
        }

        #region GetLegalCharacteristicsCompany

        void GetLegalCharacteristicsCompany()
        {
            repairData = getSetRegistryServiceTelecomSetting.GetRepairData(Company);

            foreach (var item in repairData)
            {
                OKPO = item.OKPO;
                BE = item.BE;
                FullNameCompany = item.FullNameCompany;
                ChiefСompanyFIO = item.ChiefСompanyFIO;
                ChiefСompanyPost = item.ChiefСompanyPost;
                ChairmanСompanyFIO = item.ChairmanСompanyFIO;
                ChairmanСompanyPost = item.ChairmanСompanyPost;
                FirstMemberCommissionFIO = item.FirstMemberCommissionFIO;
                FirstMemberCommissionPost = item.FirstMemberCommissionPost;
                SecondMemberCommissionFIO = item.SecondMemberCommissionFIO;
                SecondMemberCommissionPost = item.SecondMemberCommissionPost;
                ThirdMemberCommissionFIO = item.ThirdMemberCommissionFIO;
                ThirdMemberCommissionPost = item.ThirdMemberCommissionPost;
            }
        }

        #endregion

        #region GetRoadCitySerialNumberCompany

        void GetRoadCitySerialNumberCompany()
        {
            foreach (RadiostationForDocumentsDataBaseModel item
               in GlobalCollection.RADIOSTATIONS_FOR_DOCUMENTS_MULIPLE_SELECTED_DATAGRID)
            {
                Road = item.Road;
                City = item.City;
                SerialNumber = item.SerialNumber;
                Company = item.Company;
            }
        }

        #endregion

        #region CloseWindowCommand

        void ExecuteCloseWindowCommand(object obj)
        {
            Close?.Invoke();
        }

        #endregion

        #region GetProductNameInDataBase

        void GetProductNameInDataBase()
        {
            ProductName = _workRadiostantionFullRepository.
                GetProductNameInDataBaseForRepair(
                SerialNumber,
                City,
                Road);
        }


        #endregion

        #region GetPrimaryMeansInDataBase

        void GetPrimaryMeansInDataBase()
        {
            PrimaryMeans = _workRadiostantionFullRepository.
                GetPrimaryMeansInDataBaseForRepair(
                SerialNumber,
                City,
                Road);
        }

        #endregion

        #region CheckValue

        bool CheckBaseValueIsNullOrWhiteSpace()
        {
            if (String.IsNullOrWhiteSpace(OKPO))
            {
                MessageBox.Show(
                    "Вы не заполнили поле \"ОКПО\"!", "Отмена",
                     MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (String.IsNullOrWhiteSpace(BE))
            {
                MessageBox.Show(
                    "Вы не заполнили поле \"БЕ\"!", "Отмена",
                     MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (String.IsNullOrWhiteSpace(FullNameCompany))
            {
                MessageBox.Show(
                    "Вы не заполнили поле \"Полное наименование предприятия\"!",
                    "Отмена", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }

        bool CheckBaseValueRegex()
        {
            if (!Regex.IsMatch(OKPO, @"^[0-9]{8,}$"))
            {
                if (MessageBox.Show("Поле \"ОКПО\" введено " +
                    "некорректно. Желаете продолжить?", "Внимание",
                     MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                    return false;
            }
            if (!Regex.IsMatch(BE, @"^[0-9]{4,}$"))
            {
                if (MessageBox.Show("Поле \"БЕ\" введено " +
                   "некорректно. Желаете продолжить?", "Внимание",
                    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                    return false;
            }
            return true;
        }

        bool CheckValueIsNullOrWhiteSpace()
        {
            if (String.IsNullOrWhiteSpace(ChiefСompanyFIO))
            {
                MessageBox.Show(
                    "Вы не заполнили поле \"Руководитель ФИО\"!",
                    "Отмена", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;

            }
            if (String.IsNullOrWhiteSpace(ChiefСompanyPost))
            {
                MessageBox.Show(
                    "Вы не заполнили поле \"Руководитель Должность\"!",
                    "Отмена", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (String.IsNullOrWhiteSpace(ChairmanСompanyFIO))
            {
                MessageBox.Show(
                    "Вы не заполнили поле \"Председатель ФИО\"!",
                    "Отмена", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;

            }
            if (String.IsNullOrWhiteSpace(ChairmanСompanyPost))
            {
                MessageBox.Show(
                    "Вы не заполнили поле \"Председатель Должность\"!",
                    "Отмена", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (String.IsNullOrWhiteSpace(FirstMemberCommissionFIO))
            {
                MessageBox.Show(
                    "Вы не заполнили поле \"1 представитель комиссии ФИО\"!",
                    "Отмена", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;

            }
            if (String.IsNullOrWhiteSpace(FirstMemberCommissionPost))
            {
                MessageBox.Show(
                    "Вы не заполнили поле \"1 представитель комиссии Должность\"!",
                    "Отмена", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (String.IsNullOrWhiteSpace(SecondMemberCommissionFIO))
            {
                MessageBox.Show(
                    "Вы не заполнили поле \"2 представитель комиссии ФИО\"!",
                    "Отмена", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;

            }
            if (String.IsNullOrWhiteSpace(SecondMemberCommissionPost))
            {
                MessageBox.Show(
                     "Вы не заполнили поле \"2 представитель комиссии Должность\"!",
                     "Отмена", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (String.IsNullOrWhiteSpace(ThirdMemberCommissionFIO))
            {
                MessageBox.Show(
                    "Вы не заполнили поле \"3 представитель комиссии ФИО\"!",
                    "Отмена", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;

            }
            if (String.IsNullOrWhiteSpace(ThirdMemberCommissionPost))
            {
                MessageBox.Show(
                     "Вы не заполнили поле \"3 представитель комиссии Должность\"!",
                     "Отмена", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }

        bool CheckValueRegex()
        {
            if (!Regex.IsMatch(ChiefСompanyFIO,
                @"^[А-ЯЁ][а-яё]*(([\s]+[А-Я][\.]+[А-Я]+[\.])$)"))
            {
                if (MessageBox.Show("Поле \"Руководитель ФИО\" введено " +
               "некорректно. Желаете продолжить?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                    return false;
            }
            if (!Regex.IsMatch(ChairmanСompanyFIO,
                @"^[А-ЯЁ][а-яё]*(([\s]+[А-Я][\.]+[А-Я]+[\.])$)"))
            {
                if (MessageBox.Show("Поле \"Руководитель ФИО\" введено " +
               "некорректно. Желаете продолжить?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                    return false;
            }
            if (!Regex.IsMatch(FirstMemberCommissionFIO,
                @"^[А-ЯЁ][а-яё]*(([\s]+[А-Я][\.]+[А-Я]+[\.])$)"))
            {
                if (MessageBox.Show("Поле \"Руководитель ФИО\" введено " +
               "некорректно. Желаете продолжить?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                    return false;
            }
            if (!Regex.IsMatch(SecondMemberCommissionFIO,
                @"^[А-ЯЁ][а-яё]*(([\s]+[А-Я][\.]+[А-Я]+[\.])$)"))
            {
                if (MessageBox.Show("Поле \"Руководитель ФИО\" введено " +
               "некорректно. Желаете продолжить?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                    return false;
            }
            if (!Regex.IsMatch(ThirdMemberCommissionFIO,
                @"^[А-ЯЁ][а-яё]*(([\s]+[А-Я][\.]+[А-Я]+[\.])$)"))
            {
                if (MessageBox.Show("Поле \"Руководитель ФИО\" введено " +
               "некорректно. Желаете продолжить?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                    return false;
            }

            return true;
        }

        #endregion

        #region ContinuePrintRepair

        void ExecuteContinuePrintRepairCommand(object obj)
        {
            if (!CheckBaseValueIsNullOrWhiteSpace())
                return;
            if (!CheckBaseValueRegex())
                return;

            if (!CheckBoxDisableVerificationSurname)
            {
                if (!CheckValueIsNullOrWhiteSpace())
                    return;
                if (!CheckValueRegex())
                    return;
            }

            new Thread(() =>
            {
                printExcel.PrintExcelNumberActRepair(
                    Company, OKPO, BE, FullNameCompany,
                    ChiefСompanyFIO, ChiefСompanyPost,
                    ChairmanСompanyFIO, ChairmanСompanyPost,
                    FirstMemberCommissionFIO, FirstMemberCommissionPost,
                    SecondMemberCommissionFIO, SecondMemberCommissionPost,
                    ThirdMemberCommissionFIO, ThirdMemberCommissionPost,
                    PrimaryMeans, ProductName, RadiostationsForDocumentsMulipleSelectedDataGrid);
            })
            { IsBackground = true }.Start();
            Close?.Invoke();
        }

        #endregion

        #region AddInRegistryInformationCompany

        void ExecuteAddInRegistryInformationCompanyCommand(object obj)
        {

            if (!CheckBaseValueIsNullOrWhiteSpace())
                return;
            if (!CheckBaseValueRegex())
                return;
            if (!CheckBoxDisableVerificationSurname)
            {
                if (!CheckValueIsNullOrWhiteSpace())
                    return;
                if (!CheckValueRegex())
                    return;
            }

            if (!getSetRegistryServiceTelecomSetting.SetRepairData(
                Company, OKPO, BE, FullNameCompany, ChiefСompanyFIO, ChiefСompanyPost,
                ChairmanСompanyFIO, ChairmanСompanyPost, FirstMemberCommissionFIO,
                FirstMemberCommissionPost, SecondMemberCommissionFIO,
                SecondMemberCommissionPost, ThirdMemberCommissionFIO,
                ThirdMemberCommissionPost))
            {
                MessageBox.Show($"Ошибка записи в реестр!", "Отмена",
                     MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        #endregion
    }
}
