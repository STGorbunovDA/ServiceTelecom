using ServiceTelecom.Models;
using ServiceTelecom.Repositories;
using ServiceTelecom.Repositories.Base;
using ServiceTelecom.View.Base;
using System;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace ServiceTelecom.ViewModels.WorkViewModelPackage
{
    internal class ChangeRadiostationForDocumentInDataBaseViewModel : ViewModelBase
    {
        private WorkRepositoryRadiostantion _workRepositoryRadiostantion;
        private WorkRepositoryRadiostantionFull _workRepositoryRadiostantionFull;

        AddModelRadiostantionView addModelRadiostantion = null;
        private ModelDataBaseRepository _modelDataBase;
        public ObservableCollection<ModelRadiostantionDataBaseModel> ModelCollections { get; set; }

        public ObservableCollection<RadiostationForDocumentsDataBaseModel> RadiostationForDocumentsCollection { get; set; }

        #region свойства

        private string _road;
        public string Road
        {
            get => _road;
            set
            {
                _road = value;
                OnPropertyChanged(nameof(Road));
            }
        }
        private string _numberAct;
        public string NumberAct
        {
            get => _numberAct;
            set
            {
                _numberAct = value;
                OnPropertyChanged(nameof(NumberAct));
            }
        }
        private string _dateMaintenance;
        public string DateMaintenance
        {
            get => _dateMaintenance;
            set
            {
                _dateMaintenance = value;
                OnPropertyChanged(nameof(DateMaintenance));
            }
        }
        private string _representative;
        public string Representative
        {
            get => _representative;
            set
            {
                _representative = value;
                OnPropertyChanged(nameof(Representative));
            }
        }
        private string _numberIdentification;
        public string NumberIdentification
        {
            get => _numberIdentification;
            set
            {
                _numberIdentification = value;
                OnPropertyChanged(nameof(NumberIdentification));
            }
        }
        private string _dateOfIssuanceOfTheCertificate;
        public string DateOfIssuanceOfTheCertificate
        {
            get => _dateOfIssuanceOfTheCertificate;
            set
            {
                _dateOfIssuanceOfTheCertificate = value;
                OnPropertyChanged(nameof(DateOfIssuanceOfTheCertificate));
            }
        }
        private string _phoneNumber;
        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                _phoneNumber = value;
                OnPropertyChanged(nameof(PhoneNumber));
            }
        }
        private string _post;
        public string Post
        {
            get => _post;
            set
            {
                _post = value;
                OnPropertyChanged(nameof(Post));
            }
        }
        private string _comment;
        public string Comment
        {
            get => _comment;
            set
            {
                _comment = value;
                OnPropertyChanged(nameof(Comment));
            }
        }
        private string _city;
        public string City
        {
            get => _city;
            set
            {
                _city = value;
                OnPropertyChanged(nameof(City));
            }
        }
        private string _location;
        public string Location
        {
            get => _location;
            set
            {
                _location = value;
                OnPropertyChanged(nameof(Location));
            }
        }
        private string _poligon;
        public string Poligon
        {
            get => _poligon;
            set
            {
                _poligon = value;
                OnPropertyChanged(nameof(Poligon));
            }
        }
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
        private string _model;
        public string Model
        {
            get => _model;
            set
            {
                _model = value;
                OnPropertyChanged(nameof(Model));
            }
        }
        private string _serialNumber;
        public string SerialNumber
        {
            get => _serialNumber;
            set
            {
                _serialNumber = value;
                OnPropertyChanged(nameof(SerialNumber));
            }
        }
        private string _inventoryNumber;
        public string InventoryNumber
        {
            get => _inventoryNumber;
            set
            {
                _inventoryNumber = value;
                OnPropertyChanged(nameof(InventoryNumber));
            }
        }
        private string _networkNumber;
        public string NetworkNumber
        {
            get => _networkNumber;
            set
            {
                _networkNumber = value;
                OnPropertyChanged(nameof(NetworkNumber));
            }
        }

        private string _price;
        public string Price
        {
            get => _price;
            set
            {
                _price = value;
                OnPropertyChanged(nameof(Price));
            }
        }
        private bool _checkBoxRemontViewModel;
        public bool CheckBoxRemontViewModel
        {
            get => _checkBoxRemontViewModel;
            set
            {
                _checkBoxRemontViewModel = value;
                OnPropertyChanged(nameof(CheckBoxRemontViewModel));
            }
        }
        private string _battery;
        public string Battery
        {
            get => _battery;
            set
            {
                _battery = value;
                OnPropertyChanged(nameof(Battery));
            }
        }
        private bool _checkBoxManipulatorViewModel;
        public bool CheckBoxManipulatorViewModel
        {
            get => _checkBoxManipulatorViewModel;
            set
            {
                _checkBoxManipulatorViewModel = value;
                OnPropertyChanged(nameof(CheckBoxManipulatorViewModel));
            }
        }

        private bool _checkBoxAntennaViewModel;
        public bool CheckBoxAntennaViewModel
        {

            get => _checkBoxAntennaViewModel;
            set
            {
                _checkBoxAntennaViewModel = value;
                OnPropertyChanged(nameof(CheckBoxAntennaViewModel));
            }
        }

        private bool _checkBoxChargerViewModel;
        public bool CheckBoxChargerViewModel
        {
            get => _checkBoxChargerViewModel;
            set
            {
                _checkBoxChargerViewModel = value;
                OnPropertyChanged(nameof(CheckBoxChargerViewModel));
            }
        }


        private bool _сheckBoxPriceViewModel;
        public bool CheckBoxPriceViewModel
        {
            get => _сheckBoxPriceViewModel;
            set
            {
                if (value == true)
                    Price = UserModelStatic.priceAnalog;
                else Price = UserModelStatic.priceDigital;
                _сheckBoxPriceViewModel = value;
                OnPropertyChanged(nameof(CheckBoxPriceViewModel));
            }
        }

        private string Manipulator { get; set; }
        private string Antenna { get; set; }
        private string Charger { get; set; }
        private string Remont { get; set; }

        private string _decommissionNumberAct;
        public string DecommissionNumberAct
        {
            get => _decommissionNumberAct;
            set
            {
                _decommissionNumberAct = value;
                OnPropertyChanged(nameof(DecommissionNumberAct));
            }
        }

        #endregion


        private int _theIndexModelChoiceCollection;
        public int TheIndexModelChoiceCollection
        {
            get => _theIndexModelChoiceCollection;
            set
            {
                _theIndexModelChoiceCollection = value;
                OnPropertyChanged(nameof(TheIndexModelChoiceCollection));
            }
        }

        public ICommand ChangeNumberActBySerialNumberFromTheDatabase { get; }
        public ICommand AddModelDataBase { get; }
        public ICommand ChangeDecommissionNumberActBySerialNumberFromTheDatabase { get; }
        public ICommand ChangeRadiostationForDocumentInDataBase { get; }
        public ICommand SearchBySerialNumberForFeaturesAdditionsFromTheDatabase { get; }
        public ICommand SearchBySerialNumberForFeaturesAdditionsRepresentativeFromTheDatabase { get; }
        public ICommand ChangeByNumberActRepresentativeForDocumentInDataBase { get; }

        public ChangeRadiostationForDocumentInDataBaseViewModel()
        {
            _workRepositoryRadiostantion = new WorkRepositoryRadiostantion();
            _workRepositoryRadiostantionFull = new WorkRepositoryRadiostantionFull();
            _modelDataBase = new ModelDataBaseRepository();
            RadiostationForDocumentsCollection =
                new ObservableCollection<RadiostationForDocumentsDataBaseModel>();
            ModelCollections = new ObservableCollection<ModelRadiostantionDataBaseModel>();
            AddModelDataBase = new ViewModelCommand(ExecuteAddModelDataBaseCommand);
            ChangeNumberActBySerialNumberFromTheDatabase = new ViewModelCommand(ExecuteChangeNumberActBySerialNumberFromTheDatabaseCommand);
            ChangeDecommissionNumberActBySerialNumberFromTheDatabase = new ViewModelCommand(ExecuteChangeDecommissionNumberActBySerialNumberFromTheDatabaseCommand);
            ChangeRadiostationForDocumentInDataBase = new ViewModelCommand(ExecuteChangeRadiostationForDocumentInDataBaseCommand);
            SearchBySerialNumberForFeaturesAdditionsFromTheDatabase =
                    new ViewModelCommand(ExecuteSearchBySerialNumberForFeaturesAdditionsFromTheDatabaseCommand);
            SearchBySerialNumberForFeaturesAdditionsRepresentativeFromTheDatabase =
                new ViewModelCommand(ExecuteSearchBySerialNumberForFeaturesAdditionsRepresentativeFromTheDatabaseCommand);
            ChangeByNumberActRepresentativeForDocumentInDataBase =
                new ViewModelCommand(ExecuteChangeByNumberActRepresentativeForDocumentInDataBaseCommand);
        }



        #region ChangeByNumberActRepresentativeForDocumentInDataBase

        private void ExecuteChangeByNumberActRepresentativeForDocumentInDataBaseCommand(object obj)
        {
            if (!String.IsNullOrWhiteSpace(DecommissionNumberAct))
            {
                MessageBox.Show($"У радиостанции \"{SerialNumber}\" есть списание {DecommissionNumberAct}", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (MessageBox.Show("Подтверждаете изменение?", "Внимание",
                    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                return;

            #region проверка контролов Representative

            if (String.IsNullOrWhiteSpace(NumberAct))
            {
                MessageBox.Show("Поле \"Номер акта\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (!Regex.IsMatch(NumberAct, @"[0-9]{2,2}/([0-9]+([A-Z]?[А-Я]?)*[.\-]?[0-9]?[0-9]?[0-9]?[A-Z]?[А-Я]?)$"))
            {
                MessageBox.Show("Введите корректно поле \"№ Акта ТО\"", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if (!Regex.IsMatch(DateOfIssuanceOfTheCertificate, @"^[0-9]{2,2}[.][0-9]{2,2}[.][2][0][0-9]{2,2}$"))
            {
                MessageBox.Show("Введите корректно поле \"Дата ТО\"", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            string dateOfIssuanceOfTheCertificateDataBase = Convert.ToDateTime(DateOfIssuanceOfTheCertificate).ToString("yyyy-MM-dd");

            if (String.IsNullOrWhiteSpace(Representative))
            {
                MessageBox.Show("Поле \"Представитель ФИО\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (!Representative.Contains("-"))
            {
                if (!Regex.IsMatch(Representative, @"^[А-ЯЁ][а-яё]*(([\s]+[А-Я][\.]+[А-Я]+[\.])$)"))
                {
                    MessageBox.Show("Введите корректно поле \"Представитель ФИО\" пример Иванов И.И.", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
            }
            if (Representative.Contains("-"))
            {
                if (!Regex.IsMatch(Representative, @"^[А-ЯЁ][а-яё]*(([\-][А-Я][а-яё]*[\s]+[А-Я]+[\.]+[А-Я]+[\.])$)"))
                {
                    MessageBox.Show("Введите корректно поле \"Представитель ФИО\" пример Иванова-Сидорова Я.И.", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
            }
            if (String.IsNullOrWhiteSpace(NumberIdentification))
            {
                MessageBox.Show("Поле \"№ Удостоверения\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (!Regex.IsMatch(NumberIdentification, @"^[V][\s]([0-9]{6,})$"))
            {
                if (MessageBox.Show("Поле \"№ Удостоверения\" введено некорректно желаете продолжить?", "Внимание",
                     MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                    return;
            }
            if (String.IsNullOrWhiteSpace(Post))
            {
                MessageBox.Show("Поле \"Должность\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            Regex re = new Regex(Environment.NewLine);
            Post = re.Replace(Post, " ");
            Post.Trim();

            #endregion

            if (_workRepositoryRadiostantionFull.
                ChangeByNumberActRepresentativeForDocumentInDBRadiostantionFull(
                Road, City, NumberAct, dateOfIssuanceOfTheCertificateDataBase,
                Representative, NumberIdentification, Post, PhoneNumber))
            { }
            else
                MessageBox.Show($"Ошибка изменения представителя Предприятия по данному № {NumberAct} акта в radiostantionFull", "Отмена", MessageBoxButton.OK,
                    MessageBoxImage.Error);

            if (_workRepositoryRadiostantion.
                ChangeByNumberActRepresentativeForDocumentInDataBase(
                Road, City, NumberAct, dateOfIssuanceOfTheCertificateDataBase, 
                Representative, NumberIdentification, Post, PhoneNumber))
                MessageBox.Show("Успешно", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show($"Ошибка изменения представителя Предприятия по данному № {NumberAct} акта", "Отмена", MessageBoxButton.OK,
                    MessageBoxImage.Error);
        }

        #endregion

        #region SearchBySerialNumberForFeaturesAdditionsRepresentativeFromTheDatabase

        private void ExecuteSearchBySerialNumberForFeaturesAdditionsRepresentativeFromTheDatabaseCommand(object obj)
        {
            if (String.IsNullOrWhiteSpace(SerialNumber))
                return;
            if (RadiostationForDocumentsCollection.Count != 0)
                RadiostationForDocumentsCollection.Clear();

            RadiostationForDocumentsCollection =
            _workRepositoryRadiostantionFull.SearchBySerialNumberInDatabaseCharacteristics(
                Road, City, SerialNumber, RadiostationForDocumentsCollection);
            if (RadiostationForDocumentsCollection.Count != 0)
            {
                foreach (var item in RadiostationForDocumentsCollection)
                {
                    Representative = item.Representative;
                    NumberIdentification = item.NumberIdentification;
                    DateOfIssuanceOfTheCertificate = item.DateOfIssuanceOfTheCertificate;
                    PhoneNumber = item.PhoneNumber;
                    Post = item.Post;
                }
            }
        }

        #endregion

        #region SearchBySerialNumberForFeaturesAdditionsFromTheDatabase

        private void ExecuteSearchBySerialNumberForFeaturesAdditionsFromTheDatabaseCommand(object obj)
        {
            if (String.IsNullOrWhiteSpace(SerialNumber))
                return;
            if (RadiostationForDocumentsCollection.Count != 0)
                RadiostationForDocumentsCollection.Clear();

            RadiostationForDocumentsCollection =
            _workRepositoryRadiostantionFull.SearchBySerialNumberInDatabaseCharacteristics(
                Road, City, SerialNumber, RadiostationForDocumentsCollection);

            if (RadiostationForDocumentsCollection.Count != 0)
            {
                foreach (var item in RadiostationForDocumentsCollection)
                {
                    InventoryNumber = item.InventoryNumber;
                    NetworkNumber = item.NetworkNumber;
                    City = item.City;
                    Location = item.Location;
                    Poligon = item.Poligon;
                    Company = item.Company;
                    Model = item.Model;
                    Comment = item.Comment;
                    Battery = item.Battery;
                    Price = item.Price;

                    if (Price == UserModelStatic.priceAnalog)
                        CheckBoxPriceViewModel = true;
                    else CheckBoxPriceViewModel = false;
                    if (item.VerifiedRST == UserModelStatic.InRemontTechnicalServices)
                        CheckBoxRemontViewModel = true;
                    if (item.Manipulator == UserModelStatic.UnitMeasureForCheckBox)
                        CheckBoxManipulatorViewModel = true;
                    if (item.Antenna == UserModelStatic.UnitMeasureForCheckBox)
                        CheckBoxAntennaViewModel = true;
                    if (item.Charger == UserModelStatic.UnitMeasureForCheckBox)
                        CheckBoxChargerViewModel = true;
                }
            }
            else
            {
                InventoryNumber = String.Empty;
                NetworkNumber = String.Empty;
                Comment = String.Empty;
                Battery = String.Empty;
                CheckBoxRemontViewModel = false;
                CheckBoxManipulatorViewModel = false;
                CheckBoxAntennaViewModel = false;
                CheckBoxChargerViewModel = false;
            }
        }

        #endregion

        #region ChangeRadiostationForDocumentInDataBase

        private void ExecuteChangeRadiostationForDocumentInDataBaseCommand(object obj)
        {
            if(!String.IsNullOrWhiteSpace(DecommissionNumberAct))
            {
                MessageBox.Show($"У радиостанции \"{SerialNumber}\" есть списание {DecommissionNumberAct}", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (MessageBox.Show("Подтверждаете изменение?", "Внимание",
                    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                return;
        }

        #endregion

        #region ChangeDecommissionNumberActBySerialNumberFromTheDatabase

        private void ExecuteChangeDecommissionNumberActBySerialNumberFromTheDatabaseCommand(object obj)
        {
            if (String.IsNullOrWhiteSpace(DecommissionNumberAct))
            {
                MessageBox.Show("Поле \"№ акта списания\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (MessageBox.Show("Подтверждаете изменение?", "Внимание",
                    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                return;

            if (!Regex.IsMatch(DecommissionNumberAct, @"[0-9]{2,2}/([0-9]+([A-Z]?[А-Я]?)*[.\-]?[0-9]?[0-9]?[0-9]?[A-Z]?[А-Я]?)$"))
            {
                MessageBox.Show("Введите корректно поле \"№ акта списания\"", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if(_workRepositoryRadiostantionFull.ChangeDecommissionNumberActBySerialNumberFromDBRadiostantionFull(Road, City, SerialNumber, DecommissionNumberAct))
            { }
            else
                MessageBox.Show("Ошибка изменения номера акта списания радиостанции в общей таблице(radiostantionFull)", "Отмена", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            if (_workRepositoryRadiostantion.ChangeDecommissionNumberActBySerialNumberFromDBRadiostantion(Road, City, SerialNumber, DecommissionNumberAct))
                MessageBox.Show("Успешно", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show("Ошибка изменения номера акта списания радиостанции", "Отмена", MessageBoxButton.OK,
                    MessageBoxImage.Error);
        }

        #endregion

        #region AddModelDataBase

        private void ExecuteAddModelDataBaseCommand(object obj)
        {
            if (addModelRadiostantion == null)
            {
                addModelRadiostantion = new AddModelRadiostantionView();
                addModelRadiostantion.Closed += (sender, args) => addModelRadiostantion = null;
                addModelRadiostantion.Closed += (sender, args) => GetModelDataBase();
                addModelRadiostantion.Show();
            }
        }

        #endregion

        #region ChangeNumberActBySerialNumberFromTheDatabase

        private void ExecuteChangeNumberActBySerialNumberFromTheDatabaseCommand(object obj)
        {
            if (!String.IsNullOrWhiteSpace(DecommissionNumberAct))
            {
                MessageBox.Show($"У радиостанции \"{SerialNumber}\" " +
                    $"есть списание {DecommissionNumberAct}", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (MessageBox.Show("Подтверждаете изменение?", "Внимание",
                    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                return;

            if (String.IsNullOrWhiteSpace(NumberAct))
            {
                MessageBox.Show("Поле \"Номер акта\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (!Regex.IsMatch(NumberAct, @"[0-9]{2,2}/([0-9]+([A-Z]?[А-Я]?)*[.\-]?[0-9]?[0-9]?[0-9]?[A-Z]?[А-Я]?)$"))
            {
                MessageBox.Show("Введите корректно поле \"№ Акта ТО\"", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (_workRepositoryRadiostantion.ChangeNumberActBySerialNumberFromTheDatabase(Road,City,SerialNumber, NumberAct))
                MessageBox.Show("Успешно", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show("Ошибка изменения номера акта радиостанции", "Отмена", MessageBoxButton.OK,
                    MessageBoxImage.Error);
        }

        #endregion

        private void GetModelDataBase()
        {
            TheIndexModelChoiceCollection = -1;
            if (ModelCollections.Count != 0)
                ModelCollections.Clear();
            ModelCollections = _modelDataBase.GetModelRadiostantionDataBase(ModelCollections);
            TheIndexModelChoiceCollection = ModelCollections.Count - 1;
        }
    }
}
