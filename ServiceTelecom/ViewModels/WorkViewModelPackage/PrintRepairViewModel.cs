using ServiceTelecom.Infrastructure;
using ServiceTelecom.Infrastructure.Interfaces;
using ServiceTelecom.Models;
using ServiceTelecom.Repositories;
using System;
using System.Collections;
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
        private WorkRadiostantionFullRepository _workRepositoryRadiostantionFull;

        public IList RadiostationsForDocumentsMulipleSelectedDataGrid;

        #region Свойства

        public Action Close { get; set; }

        private string PrimaryMeans { get; set; } 
        public string ProductName { get; set; }
        public string Road { get; set; }
        public string City { get; set; }
        public string SerialNumber { get; set; }


        private string _company;
        public string Company
        {
            get => _company;
            set
            {
                _company = value;
                OnPropertyChanged(nameof(Company));
            }
        }

        private bool _continue;
        public bool Continue
        {
            get => _continue;
            set
            {
                _continue = value;
                OnPropertyChanged(nameof(Continue));
            }
        }

        private string _OKPO;
        public string OKPO
        {
            get => _OKPO;
            set
            {
                _OKPO = value;
                OnPropertyChanged(nameof(OKPO));
            }
        }

        private string _BE;
        public string BE
        {
            get => _BE;
            set
            {
                _BE = value;
                OnPropertyChanged(nameof(BE));
            }
        }

        private string _fullNameCompany;
        public string FullNameCompany
        {
            get => _fullNameCompany;
            set
            {
                _fullNameCompany = value;
                OnPropertyChanged(nameof(FullNameCompany));
            }
        }

        private string _chiefСompanyFIO;
        public string ChiefСompanyFIO
        {
            get => _chiefСompanyFIO;
            set
            {
                _chiefСompanyFIO = value;
                OnPropertyChanged(nameof(ChiefСompanyFIO));
            }
        }

        private string _chiefСompanyPost;
        public string ChiefСompanyPost
        {
            get => _chiefСompanyPost;
            set
            {
                _chiefСompanyPost = value;
                OnPropertyChanged(nameof(ChiefСompanyPost));
            }
        }

        private string _chairmanСompanyFIO;
        public string ChairmanСompanyFIO
        {
            get => _chairmanСompanyFIO;
            set
            {
                _chairmanСompanyFIO = value;
                OnPropertyChanged(nameof(ChairmanСompanyFIO));
            }
        }

        private string _chairmanСompanyPost;
        public string ChairmanСompanyPost
        {
            get => _chairmanСompanyPost;
            set
            {
                _chairmanСompanyPost = value;
                OnPropertyChanged(nameof(ChairmanСompanyPost));
            }
        }

        private string _firstMemberCommissionFIO;
        public string FirstMemberCommissionFIO
        {
            get => _firstMemberCommissionFIO;
            set
            {
                _firstMemberCommissionFIO = value;
                OnPropertyChanged(nameof(FirstMemberCommissionFIO));
            }
        }

        private string _firstMemberCommissionPost;
        public string FirstMemberCommissionPost
        {
            get => _firstMemberCommissionPost;
            set
            {
                _firstMemberCommissionPost = value;
                OnPropertyChanged(nameof(FirstMemberCommissionPost));
            }
        }

        private string _secondMemberCommissionFIO;
        public string SecondMemberCommissionFIO
        {
            get => _secondMemberCommissionFIO;
            set
            {
                _secondMemberCommissionFIO = value;
                OnPropertyChanged(nameof(SecondMemberCommissionFIO));
            }
        }

        private string _secondMemberCommissionPost;
        public string SecondMemberCommissionPost
        {
            get => _secondMemberCommissionPost;
            set
            {
                _secondMemberCommissionPost = value;
                OnPropertyChanged(nameof(SecondMemberCommissionPost));
            }
        }

        private string _thirdMemberCommissionFIO;
        public string ThirdMemberCommissionFIO
        {
            get => _thirdMemberCommissionFIO;
            set
            {
                _thirdMemberCommissionFIO = value;
                OnPropertyChanged(nameof(ThirdMemberCommissionFIO));
            }
        }

        private string _thirdMemberCommissionPost;
        public string ThirdMemberCommissionPost
        {
            get => _thirdMemberCommissionPost;
            set
            {
                _thirdMemberCommissionPost = value;
                OnPropertyChanged(nameof(ThirdMemberCommissionPost));
            }
        }

        private bool _checkBoxDisableThirdVerification;
        public bool CheckBoxDisableThirdVerification
        {
            get => _checkBoxDisableThirdVerification;
            set
            {
                _checkBoxDisableThirdVerification = value;
                OnPropertyChanged(nameof(CheckBoxDisableThirdVerification));
            }
        }

        #endregion

        public ICommand AddInRegistryInformationCompany { get; }
        public ICommand ContinuePrintRepair { get; }
        public ICommand CloseWindowCommand { get; }

        public PrintRepairViewModel()
        {
            _workRepositoryRadiostantionFull = new WorkRadiostantionFullRepository();
            getSetRegistryServiceTelecomSetting = new GetSetRegistryServiceTelecomSetting();
            CloseWindowCommand =
                new ViewModelCommand(ExecuteCloseWindowCommand);
            printExcel = new Print();
            AddInRegistryInformationCompany =
                new ViewModelCommand(ExecuteAddInRegistryInformationCompanyCommand);
            ContinuePrintRepair =
                new ViewModelCommand(ExecuteContinuePrintRepairCommand);
            if (UserModelStatic.RADIOSTATIONS_FOR_DOCUMENTS_MULIPLE_SELECTED_DATAGRID == null)
                return;
            foreach (RadiostationForDocumentsDataBaseModel item
                in UserModelStatic.RADIOSTATIONS_FOR_DOCUMENTS_MULIPLE_SELECTED_DATAGRID)
            {
                Road = item.Road;
                City= item.City;
                SerialNumber = item.SerialNumber;
                Company = item.Company;
            }
            RadiostationsForDocumentsMulipleSelectedDataGrid 
                = UserModelStatic.RADIOSTATIONS_FOR_DOCUMENTS_MULIPLE_SELECTED_DATAGRID;
            GetProductNameInDataBase();
            GetPrimaryMeansInDataBase();
        }

        #region CloseWindowCommand

        private void ExecuteCloseWindowCommand(object obj)
        {
            Close?.Invoke();
        }

        #endregion

        #region GetProductNameInDataBase

        private void GetProductNameInDataBase()
        {
            ProductName = _workRepositoryRadiostantionFull.
                GetProductNameInDataBaseForRepair(
                SerialNumber,
                City,
                Road);
        }


        #endregion

        #region GetPrimaryMeansInDataBase

        private void GetPrimaryMeansInDataBase()
        {
            PrimaryMeans = _workRepositoryRadiostantionFull.
                GetPrimaryMeansInDataBaseForRepair(
                SerialNumber,
                City,
                Road);
        }

        #endregion

        #region ContinuePrintRepair

        private void ExecuteContinuePrintRepairCommand(object obj)
        {
            #region проверка на пустоту

            if (String.IsNullOrWhiteSpace(OKPO))
            {
                MessageBox.Show(
                    "Вы не заполнили поле \"ОКПО\"!", "Отмена",
                     MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (String.IsNullOrWhiteSpace(BE))
            {
                MessageBox.Show(
                    "Вы не заполнили поле \"БЕ\"!", "Отмена",
                     MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (String.IsNullOrWhiteSpace(FullNameCompany))
            {
                MessageBox.Show(
                    "Вы не заполнили поле \"Полное наименование предприятия\"!", 
                    "Отмена", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (String.IsNullOrWhiteSpace(ChiefСompanyFIO))
            {
                MessageBox.Show(
                    "Вы не заполнили поле \"Руководитель ФИО\"!", 
                    "Отмена", MessageBoxButton.OK, MessageBoxImage.Error);
                return;

            }
            if (String.IsNullOrWhiteSpace(ChiefСompanyPost))
            {
                MessageBox.Show(
                    "Вы не заполнили поле \"Руководитель Должность\"!", 
                    "Отмена", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (String.IsNullOrWhiteSpace(ChairmanСompanyFIO))
            {
                MessageBox.Show(
                    "Вы не заполнили поле \"Председатель ФИО\"!", 
                    "Отмена", MessageBoxButton.OK, MessageBoxImage.Error);
                return;

            }
            if (String.IsNullOrWhiteSpace(ChairmanСompanyPost))
            {
                MessageBox.Show(
                    "Вы не заполнили поле \"Председатель Должность\"!", 
                    "Отмена", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (String.IsNullOrWhiteSpace(FirstMemberCommissionFIO))
            {
                MessageBox.Show(
                    "Вы не заполнили поле \"1 представитель комиссии ФИО\"!", 
                    "Отмена", MessageBoxButton.OK, MessageBoxImage.Error);
                return;

            }
            if (String.IsNullOrWhiteSpace(FirstMemberCommissionPost))
            {
                MessageBox.Show(
                    "Вы не заполнили поле \"1 представитель комиссии Должность\"!", 
                    "Отмена", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (String.IsNullOrWhiteSpace(SecondMemberCommissionFIO))
            {
                MessageBox.Show(
                    "Вы не заполнили поле \"2 представитель комиссии ФИО\"!", 
                    "Отмена", MessageBoxButton.OK, MessageBoxImage.Error);
                return;

            }
            if (String.IsNullOrWhiteSpace(SecondMemberCommissionPost))
            {
                MessageBox.Show(
                     "Вы не заполнили поле \"2 представитель комиссии Должность\"!", 
                     "Отмена", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!CheckBoxDisableThirdVerification)
            {
                if (String.IsNullOrWhiteSpace(ThirdMemberCommissionFIO))
                {
                    MessageBox.Show(
                        "Вы не заполнили поле \"3 представитель комиссии ФИО\"!", 
                        "Отмена", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;

                }
                if (String.IsNullOrWhiteSpace(ThirdMemberCommissionPost))
                {
                    MessageBox.Show(
                         "Вы не заполнили поле \"3 представитель комиссии Должность\"!", 
                         "Отмена", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }

            #endregion

            #region Regex

            if (!Regex.IsMatch(OKPO, @"^[0-9]{8,}$"))
            {
                if (MessageBox.Show("Поле \"ОКПО\" введено " +
                    "некорректно. Желаете продолжить?", "Внимание",
                     MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                    return;
            }
            if (!Regex.IsMatch(BE, @"^[0-9]{4,}$"))
            {
                if (MessageBox.Show("Поле \"БЕ\" введено " +
                   "некорректно. Желаете продолжить?", "Внимание",
                    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                    return;
            }
            if (!Regex.IsMatch(ChiefСompanyFIO,
                @"^[А-ЯЁ][а-яё]*(([\s]+[А-Я][\.]+[А-Я]+[\.])$)"))
            {
                if (MessageBox.Show("Поле \"Руководитель ФИО\" введено " +
               "некорректно. Желаете продолжить?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                    return;
            }
            if (!Regex.IsMatch(ChairmanСompanyFIO,
                @"^[А-ЯЁ][а-яё]*(([\s]+[А-Я][\.]+[А-Я]+[\.])$)"))
            {
                if (MessageBox.Show("Поле \"Руководитель ФИО\" введено " +
               "некорректно. Желаете продолжить?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                    return;
            }
            if (!Regex.IsMatch(FirstMemberCommissionFIO,
                @"^[А-ЯЁ][а-яё]*(([\s]+[А-Я][\.]+[А-Я]+[\.])$)"))
            {
                if (MessageBox.Show("Поле \"Руководитель ФИО\" введено " +
               "некорректно. Желаете продолжить?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                    return;
            }
            if (!Regex.IsMatch(SecondMemberCommissionFIO,
                @"^[А-ЯЁ][а-яё]*(([\s]+[А-Я][\.]+[А-Я]+[\.])$)"))
            {
                if (MessageBox.Show("Поле \"Руководитель ФИО\" введено " +
               "некорректно. Желаете продолжить?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                    return;
            }
            if (!CheckBoxDisableThirdVerification)
            {
                if (!Regex.IsMatch(ThirdMemberCommissionFIO,
                @"^[А-ЯЁ][а-яё]*(([\s]+[А-Я][\.]+[А-Я]+[\.])$)"))
                {
                    if (MessageBox.Show("Поле \"Руководитель ФИО\" введено " +
                   "некорректно. Желаете продолжить?", "Внимание",
                    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                        return;
                }
            }

            #endregion      

            if(!CheckBoxDisableThirdVerification)
            {
                MessageBox.Show(
                         "Вы не заполнили поля: \"3 представитель комиссии ФИО " +
                         "и 3 представитель комиссии Должность\"!", "Отмена",
                          MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if(CheckBoxDisableThirdVerification && Continue)
            {
                new Thread(() =>
                {
                    printExcel.PrintExcelNumberActRepair(
                        Company, OKPO, BE, FullNameCompany, 
                        ChiefСompanyFIO, ChiefСompanyPost,
                        ChairmanСompanyFIO, ChairmanСompanyPost, 
                        FirstMemberCommissionFIO, FirstMemberCommissionPost, 
                        SecondMemberCommissionFIO,SecondMemberCommissionPost, 
                        ThirdMemberCommissionFIO, ThirdMemberCommissionPost, 
                        PrimaryMeans, ProductName, 
                        RadiostationsForDocumentsMulipleSelectedDataGrid);
                })
                { IsBackground = true }.Start();
                Close?.Invoke();
            }
        }

        #endregion

        #region AddInRegistryInformationCompany

        private void ExecuteAddInRegistryInformationCompanyCommand(object obj)
        {
            #region проверка на пустоту

            if (String.IsNullOrWhiteSpace(OKPO))
            {
                MessageBox.Show(
                    "Вы не заполнили поле \"ОКПО\"!", "Отмена",
                     MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (String.IsNullOrWhiteSpace(BE))
            {
                MessageBox.Show(
                    "Вы не заполнили поле \"БЕ\"!", "Отмена",
                     MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (String.IsNullOrWhiteSpace(FullNameCompany))
            {
                MessageBox.Show(
                    "Вы не заполнили поле \"Полное наименование предприятия\"!", 
                    "Отмена", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (String.IsNullOrWhiteSpace(ChiefСompanyFIO))
            {
                MessageBox.Show(
                    "Вы не заполнили поле \"Руководитель ФИО\"!", 
                    "Отмена", MessageBoxButton.OK, MessageBoxImage.Error);
                return;

            }
            if (String.IsNullOrWhiteSpace(ChiefСompanyPost))
            {
                MessageBox.Show(
                    "Вы не заполнили поле \"Руководитель Должность\"!", 
                    "Отмена", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (String.IsNullOrWhiteSpace(ChairmanСompanyFIO))
            {
                MessageBox.Show(
                    "Вы не заполнили поле \"Председатель ФИО\"!", 
                    "Отмена", MessageBoxButton.OK, MessageBoxImage.Error);
                return;

            }
            if (String.IsNullOrWhiteSpace(ChairmanСompanyPost))
            {
                MessageBox.Show(
                    "Вы не заполнили поле \"Председатель Должность\"!", 
                    "Отмена", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (String.IsNullOrWhiteSpace(FirstMemberCommissionFIO))
            {
                MessageBox.Show(
                    "Вы не заполнили поле \"1 представитель комиссии ФИО\"!", 
                    "Отмена", MessageBoxButton.OK, MessageBoxImage.Error);
                return;

            }
            if (String.IsNullOrWhiteSpace(FirstMemberCommissionPost))
            {
                MessageBox.Show(
                    "Вы не заполнили поле \"1 представитель комиссии Должность\"!", 
                    "Отмена", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (String.IsNullOrWhiteSpace(SecondMemberCommissionFIO))
            {
                MessageBox.Show(
                    "Вы не заполнили поле \"2 представитель комиссии ФИО\"!", 
                    "Отмена", MessageBoxButton.OK, MessageBoxImage.Error);
                return;

            }
            if (String.IsNullOrWhiteSpace(SecondMemberCommissionPost))
            {
                MessageBox.Show(
                     "Вы не заполнили поле \"2 представитель комиссии Должность\"!", 
                     "Отмена", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            //На случай третьего председателя комиссии
            if (!CheckBoxDisableThirdVerification)
            {
                if (String.IsNullOrWhiteSpace(ThirdMemberCommissionFIO))
                {
                    MessageBox.Show(
                        "Вы не заполнили поле \"3 представитель комиссии ФИО\"!", 
                        "Отмена", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;

                }
                if (String.IsNullOrWhiteSpace(ThirdMemberCommissionPost))
                {
                    MessageBox.Show(
                         "Вы не заполнили поле \"3 представитель комиссии Должность\"!", 
                         "Отмена", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }

            #endregion

            #region Regex

            if (!Regex.IsMatch(OKPO, @"^[0-9]{8,}$"))
            {
                if (MessageBox.Show("Поле \"ОКПО\" введено " +
                    "некорректно. Желаете продолжить?", "Внимание",
                     MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                    return;
            }
            if (!Regex.IsMatch(BE, @"^[0-9]{4,}$"))
            {
                if (MessageBox.Show("Поле \"БЕ\" введено " +
                   "некорректно. Желаете продолжить?", "Внимание",
                    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                    return;
            }
            if (!Regex.IsMatch(ChiefСompanyFIO,
                @"^[А-ЯЁ][а-яё]*(([\s]+[А-Я][\.]+[А-Я]+[\.])$)"))
            {
                if (MessageBox.Show("Поле \"Руководитель ФИО\" введено " +
               "некорректно. Желаете продолжить?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                    return;
            }
            if (!Regex.IsMatch(ChairmanСompanyFIO,
                @"^[А-ЯЁ][а-яё]*(([\s]+[А-Я][\.]+[А-Я]+[\.])$)"))
            {
                if (MessageBox.Show("Поле \"Руководитель ФИО\" введено " +
               "некорректно. Желаете продолжить?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                    return;
            }
            if (!Regex.IsMatch(FirstMemberCommissionFIO,
                @"^[А-ЯЁ][а-яё]*(([\s]+[А-Я][\.]+[А-Я]+[\.])$)"))
            {
                if (MessageBox.Show("Поле \"Руководитель ФИО\" введено " +
               "некорректно. Желаете продолжить?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                    return;
            }
            if (!Regex.IsMatch(SecondMemberCommissionFIO,
                @"^[А-ЯЁ][а-яё]*(([\s]+[А-Я][\.]+[А-Я]+[\.])$)"))
            {
                if (MessageBox.Show("Поле \"Руководитель ФИО\" введено " +
               "некорректно. Желаете продолжить?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                    return;
            }
            if (!CheckBoxDisableThirdVerification)
            {
                if (!Regex.IsMatch(ThirdMemberCommissionFIO,
                @"^[А-ЯЁ][а-яё]*(([\s]+[А-Я][\.]+[А-Я]+[\.])$)"))
                {
                    if (MessageBox.Show("Поле \"Руководитель ФИО\" введено " +
                   "некорректно. Желаете продолжить?", "Внимание",
                    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                        return;
                }
            }

            #endregion      

            Continue = getSetRegistryServiceTelecomSetting.SetRepairData(
                Company, OKPO, BE, FullNameCompany, ChiefСompanyFIO, ChiefСompanyPost,
                ChairmanСompanyFIO, ChairmanСompanyPost, FirstMemberCommissionFIO,
                FirstMemberCommissionPost, SecondMemberCommissionFIO,
                SecondMemberCommissionPost, ThirdMemberCommissionFIO, 
                ThirdMemberCommissionPost);
        }

        #endregion
    }
}
