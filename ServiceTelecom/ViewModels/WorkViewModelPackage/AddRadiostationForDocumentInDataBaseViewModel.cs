using ServiceTelecom.Models;
using ServiceTelecom.Repositories;
using ServiceTelecom.Repositories.Base;
using ServiceTelecom.Repositories.Interfaces;
using ServiceTelecom.View.Base;
using System;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace ServiceTelecom.ViewModels.WorkViewModelPackage
{
    internal class AddRadiostationForDocumentInDataBaseViewModel : ViewModelBase
    {
        AddModelRadiostantionView addModelRadiostantion = null;
        private ModelDataBaseRepository _modelDataBase;
        private WorkRepository _workRepository;

        public ObservableCollection<ModelRadiostantionDataBaseModel> ModelCollections { get; set; }

        public string Road { get; set; }
        public string NumberAct { get; set; }
        public string DateMaintenance { get; set; }
        public string Representative { get; set; }
        public string NumberIdentification { get; set; }
        public string DateOfIssuanceOfTheCertificate { get; set; }
        public string PhoneNumber { get; set; }
        public string Post { get; set; }
        public string Comment { get; set; }
        public string City { get; set; }
        public string Location { get; set; }
        public string Poligon { get; set; }
        public string Company { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; }
        public string InventoryNumber { get; set; }
        public string NetworkNumber { get; set; }

        private string _price;
        public string Price
        {
            get => _price;
            set
            {
                _price = value; OnPropertyChanged(nameof(Price));
            }
        }
        public string Battery { get; set; }
        public bool CheckBoxManipulatorViewModel { get; set; }
        private string Manipulator { get; set; }
        public bool CheckBoxAntennaViewModel { get; set; }
        private string Antenna { get; set; }
        public bool CheckBoxChargerViewModel { get; set; }
        private string Charger { get; set; }
        public bool CheckBoxRemontViewModel { get; set; }
        private string Remont { get; set; }

        private bool _сheckBoxPriceViewModel;
        public bool CheckBoxPriceViewModel
        {
            get => _сheckBoxPriceViewModel;
            set
            {
                if (value == true)
                    Price = UserModelStatic.priceAnalog;
                else Price = UserModelStatic.priceDigital;
                _сheckBoxPriceViewModel = value; OnPropertyChanged(nameof(CheckBoxPriceViewModel));
            }
        }

        private int _theIndexModelChoiceCollection;
        public int TheIndexModelChoiceCollection
        {
            get
            {
                return _theIndexModelChoiceCollection;
            }
            set
            {
                _theIndexModelChoiceCollection = value;
                OnPropertyChanged(nameof(TheIndexModelChoiceCollection));
            }
        }
        public ICommand AddModelDataBase { get; }

        public ICommand AddRadiostationForDocumentInDataBase { get; }

        public AddRadiostationForDocumentInDataBaseViewModel()
        {
            ModelCollections = new ObservableCollection<ModelRadiostantionDataBaseModel>();
            _modelDataBase = new ModelDataBaseRepository();
            _workRepository = new WorkRepository();
            AddModelDataBase = new ViewModelCommand(ExecuteAddModelDataBaseCommand);
            AddRadiostationForDocumentInDataBase = new ViewModelCommand(ExecuteAddRadiostationForDocumentInDataBaseCommand);
            GetModelDataBase();
        }

        #region AddRadiostationForDocumentInDataBase

        private void ExecuteAddRadiostationForDocumentInDataBaseCommand(object obj)
        {
            #region Проверка ввода контролов

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
            if (String.IsNullOrWhiteSpace(DateMaintenance))
            {
                MessageBox.Show("Поле \"Дата ТО\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (!Regex.IsMatch(DateMaintenance, @"^[0-9]{2,2}[.][0-9]{2,2}[.][2][0][0-9]{2,2}$"))
            {
                MessageBox.Show("Введите корректно поле \"Дата ТО\"", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            string dateMaintenanceDataBase = Convert.ToDateTime(DateMaintenance).ToString("yyyy-MM-dd");

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

            if (!String.IsNullOrWhiteSpace(Comment))
            {
                Regex re2 = new Regex(Environment.NewLine);
                Comment = re2.Replace(Comment, " ");
                Comment.Trim();
            }
            if (String.IsNullOrWhiteSpace(City))
            {
                MessageBox.Show("Поле \"Город\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (!Regex.IsMatch(City, @"^[А-Я][а-я]*(?:[\s-][А-Я][а-я]*)*$"))
            {
                if (MessageBox.Show("Поле \"Город\" введено некорректно желаете продолжить?", "Внимание",
                     MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                    return;
            }
            if (String.IsNullOrWhiteSpace(Location))
            {
                MessageBox.Show("Поле \"Станция\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (!Regex.IsMatch(Location, @"^[с][т][.][\s][А-Я][а-я]*(([\s-]?[0-9])*$)?([\s-]?[А-Я][а-я]*)*$"))
            {
                if (MessageBox.Show("Поле \"Станция\" введено некорректно желаете продолжить?", "Внимание",
                     MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                    return;
            }
            if (String.IsNullOrWhiteSpace(Poligon))
            {
                MessageBox.Show("Поле \"Полигон\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (!Regex.IsMatch(Poligon, @"^[Р][Ц][С][-][1-9]{1,1}$"))
            {
                MessageBox.Show("Поле \"Полигон\" введено некорректно. Пример от РЦС-1 до РЦС-9", "Отмена",
                     MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (String.IsNullOrWhiteSpace(Company))
            {
                MessageBox.Show("Поле \"Предприятие\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (String.IsNullOrWhiteSpace(SerialNumber))
            {
                MessageBox.Show("Поле \"Заводской №\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            #region проверка заводского номера по модели

            if (Model == "Motorola GP-340")
            {
                if (!Regex.IsMatch(SerialNumber, @"^([6][7][2]([A-Z]{3,3}[0-9]{4,4}))?([6][7][2][A-Z]{4,4}[0-9]{3,3})*$"))
                {
                    MessageBox.Show("Введите корректно поле \"Заводской №\"\nПример: Motorola GP-340 - \"672TTD0000 или 672TTDE000\"",
                        "Отмена", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
            }
            else if (Model == "Motorola GP-360")
            {
                if (!Regex.IsMatch(SerialNumber, @"^([7][4][9]([A-Z]{3,3}[0-9]{4,4}))?([7][4][9][A-Z]{4,4}[0-9]{3,3})*$"))
                {
                    MessageBox.Show("Введите корректно поле \"Заводской номер\"\nПример: Motorola GP-360 \"749TTD0000 или 749TTDE000\"", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
            }
            else if (Model == "Motorola DP-2400е" || Model == "Motorola DP-2400")
            {
                if (!Regex.IsMatch(SerialNumber, @"^([4][4][6]([A-Z]{3,3}[0-9]{4,4}))?([4][4][6][A-Z]{4,4}[0-9]{3,3})*$"))
                {
                    MessageBox.Show("Введите корректно поле \"Заводской номер\"\nПример: Motorola DP-2400 - \"446TTD0000 или 446TTDE000\"", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
            }
            else if (Model == "Comrade R5")
            {
                if (!Regex.IsMatch(SerialNumber, @"^([2][0][1][0][R][5]([0-9]{6,6}))?([2][2][1][0][R][5][V][T]([0-9]{5,5}))*$"))
                {
                    MessageBox.Show("Введите корректно поле \"Заводской номер\"\nПример: Comrade R5 - \"2010R5107867\"", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
            }
            else if (Model == "Icom IC-F3GS")
            {
                if (!Regex.IsMatch(SerialNumber, @"^[5][4]([0-9]{5,5})$"))
                {
                    if (MessageBox.Show($"Поле \"Заводской номер\" для {Model} введено некорректно желаете продолжить?", "Внимание",
                     MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                        return;
                }
            }
            else if (Model == "Icom IC-F3GT")
            {
                if (!Regex.IsMatch(SerialNumber, @"^[0][4]([0-9]{5,5})$"))
                {
                    if (MessageBox.Show($"Поле \"Заводской номер\" для {Model} введено некорректно желаете продолжить?", "Внимание",
                     MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                        return;
                }
            }
            else if (Model == "Icom IC-F16")
            {
                if (!Regex.IsMatch(SerialNumber, @"^[0][7]([0-9]{5,5})$"))
                {
                    if (MessageBox.Show($"Поле \"Заводской номер\" для {Model} введено некорректно желаете продолжить?", "Внимание",
                     MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                        return;
                }
            }
            else if (Model == "Icom IC-F11")
            {
                if (!Regex.IsMatch(SerialNumber, @"^[1][0]([0-9]{4,4})$"))
                {
                    if (MessageBox.Show($"Поле \"Заводской номер\" для {Model} введено некорректно желаете продолжить?", "Внимание",
                     MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                        return;
                }
            }
            else if (Model == "Альтавия-301М")
            {
                if (!Regex.IsMatch(SerialNumber, @"^[0-9]{9,9}$"))
                {
                    if (MessageBox.Show($"Поле \"Заводской номер\" для {Model} введено некорректно желаете продолжить?", "Внимание",
                      MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                        return;
                }
            }
            else if (Model == "Элодия-351М")
            {
                if (!Regex.IsMatch(SerialNumber, @"^[0-9]{9,9}$"))
                {
                    if (MessageBox.Show($"Поле \"Заводской номер\" для {Model} введено некорректно желаете продолжить?", "Внимание",
                      MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                        return;
                }
            }
            else if (Model == "Комбат T-44")
            {
                if (!Regex.IsMatch(SerialNumber, @"^[T][4][4][.][0-9]{2,2}[.]+[0-9]{2,2}[.][0-9]{4,4}$"))
                {
                    if (MessageBox.Show($"Поле \"Заводской номер\" для {Model} введено некорректно желаете продолжить?", "Внимание",
                      MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                        return;
                }
            }
            else if (Model == "Шеврон T-44 V2")
            {
                if (!Regex.IsMatch(SerialNumber, @"^[T][4][4][.][0-9]{2,2}[.]+[0-9]{1,2}[.][0-9]{4,4}$"))
                {
                    if (MessageBox.Show($"Поле \"Заводской номер\" для {Model} введено некорректно желаете продолжить?", "Внимание",
                      MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                        return;
                }
            }
            else if (Model == "РН311М")
            {
                if (!Regex.IsMatch(SerialNumber, @"^[0-9]{1,20}((([\S][0-9])*$)?([\s][0-9]{2,2}[.]?[0-9]{2,2}?)*$)"))
                {
                    if (MessageBox.Show($"Поле \"Заводской номер\" для {Model} введено некорректно желаете продолжить?", "Внимание",
                      MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                        return;
                }
            }
            else if (Model == "Motorola DP-4400")
            {
                if (!Regex.IsMatch(SerialNumber, @"^([8][0][7]([A-Z]{3,3}[0-9]{4,4}))?([8][0][7][A-Z]{4,4}[0-9]{3,3})*$"))
                {
                    MessageBox.Show("Введите корректно поле \"Заводской номер\"\nПример: Motorola DP-4400 - \"807TTD0000 или 807TTDE000\"", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
            }
            else if (Model == "Motorola DP-1400")
            {
                if (!Regex.IsMatch(SerialNumber, @"^([7][5][2]([A-Z]{3,3}[0-9]{4,4}))?([7][5][2][A-Z]{4,4}[0-9]{3,3})*$"))
                {
                    MessageBox.Show("Введите корректно поле \"Заводской номер\"\nПример: Motorola DP-1400 - \"752TTD0000 или 752TTDE000\"", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
            }
            else if (Model == "Motorola GP-320")
            {
                if (!Regex.IsMatch(SerialNumber, @"^([6][3][8]([A-Z]{3,3}[0-9]{4,4}))?([6][3][8][A-Z]{4,4}[0-9]{3,3})*$"))
                {
                    MessageBox.Show("Введите корректно поле \"Заводской номер\"\nПример: Motorola GP-320 - \"000TTD0000 или 000TTDE000\"", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
            }
            else if (Model == "Motorola GP-300")
            {
                if (!Regex.IsMatch(SerialNumber, @"^([1][7][4]([A-Z]{3,3}[0-9]{4,4}))?([1][7][4][A-Z]{4,4}[0-9]{3,3})*$"))
                {
                    MessageBox.Show("Введите корректно поле \"Заводской номер\"\nПример: Motorola GP-300 - \"174TTD0000 или 174TTDE000\"", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
            }
            else if (Model == "Motorola P080")
            {
                if (!Regex.IsMatch(SerialNumber, @"^([4][2][2]([A-Z]{3,3}[0-9]{4,4}))?([4][2][2][A-Z]{4,4}[0-9]{3,3})*$"))
                {
                    MessageBox.Show("Введите корректно поле \"Заводской номер\"\nПример: Motorola P080 - \"452TTD0000 или 452TTDE000\"", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
            }
            else if (Model == "Motorola P040")
            {
                if (!Regex.IsMatch(SerialNumber, @"^([4][2][2]([A-Z]{3,3}[0-9]{4,4}))?([4][2][2][A-Z]{4,4}[0-9]{3,3})*$"))
                {
                    MessageBox.Show("Введите корректно поле \"Заводской номер\"\nПример: Motorola P040 - \"452TTD0000 или 452TTDE000\"", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
            }
            else if (Model == "Гранит Р33П-1")
            {
                if (!Regex.IsMatch(SerialNumber, @"^[0-9]{2,2}[\s][0-9]{5,5}$"))
                {
                    if (MessageBox.Show($"Поле \"Заводской номер\" для {Model} введено некорректно желаете продолжить?", "Внимание",
                      MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                        return;
                }
            }
            else if (Model == "Гранит Р-43")
            {
                if (!Regex.IsMatch(SerialNumber, @"^[0-9]{2,2}[\s][0-9]{6,6}$"))
                {
                    if (MessageBox.Show($"Поле \"Заводской номер\" для {Model} введено некорректно желаете продолжить?", "Внимание",
                      MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                        return;
                }
            }
            else if (Model == "Радий-301")
            {
                if (!Regex.IsMatch(SerialNumber, @"^[0-9]{6,6}$"))
                {
                    if (MessageBox.Show($"Поле \"Заводской номер\" для {Model} введено некорректно желаете продолжить?", "Внимание",
                      MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                        return;
                }
            }
            else if (Model == "РНД-500")
            {
                if (!Regex.IsMatch(SerialNumber, @"^[0-9]{1,}[[\s]?[0-9]{2,}[\.]?[0-9]{2,}$"))
                {
                    if (MessageBox.Show($"Поле \"Заводской номер\" для {Model} введено некорректно желаете продолжить?", "Внимание",
                      MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                        return;
                }
            }
            else if (Model == "РНД-512")
            {
                if (!Regex.IsMatch(SerialNumber, @"^[0-9]{1,}[[\s]?[0-9]{2,}[\.]?[0-9]{2,}$"))
                {
                    if (MessageBox.Show($"Поле \"Заводской номер\" для {Model} введено некорректно желаете продолжить?", "Внимание",
                      MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                        return;
                }
            }

            #endregion

            if (String.IsNullOrWhiteSpace(InventoryNumber))
            {
                MessageBox.Show("Поле \"Инвентарный №\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (InventoryNumber.Contains("\\"))
                InventoryNumber = InventoryNumber.Replace("\\", "\\\\");

            if (String.IsNullOrWhiteSpace(NetworkNumber))
            {
                MessageBox.Show("Поле \"Инвентарный №\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (NetworkNumber.Contains("\\"))
                NetworkNumber = NetworkNumber.Replace("\\", "\\\\");

            if (String.IsNullOrWhiteSpace(Price))
            {
                MessageBox.Show("Поле \"Прайс\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if (CheckBoxManipulatorViewModel)
                Manipulator = "1";
            else Manipulator = "-";

            if (CheckBoxAntennaViewModel)
                Antenna = "1";
            else Antenna = "-";

            if (CheckBoxChargerViewModel)
                Charger = "1";
            else Charger = "-";

            if (CheckBoxRemontViewModel)
                Remont = "ремонт";
            else Remont = "-";

            #endregion

            if (_workRepository.CheckSerialNumberForDocumentInDataBase(Road, SerialNumber))
            {
                MessageBox.Show($"Номер: \"{SerialNumber}\" присутсвует в Базе Данных", "Отмена", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (_workRepository.CheckNumberActOverTwentyForDocumentInDataBase(Road, City, NumberAct))
            {
                MessageBox.Show($"В акте: \"{NumberAct}\" более 20 радиостанций. Создайте другой номер акта", "Отмена", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (_workRepository.AddRadiostationForDocumentInDataBase(Road, NumberAct,
                dateMaintenanceDataBase, Representative, NumberIdentification, dateOfIssuanceOfTheCertificateDataBase,
                PhoneNumber, Post, Comment, City, Location, Poligon, Company, Model, SerialNumber,
                InventoryNumber, NetworkNumber, Price, Battery, Manipulator, Antenna, Charger, Remont))
                MessageBox.Show("Успешно", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show("Ошибка добавления инструкции", "Отмена", MessageBoxButton.OK, MessageBoxImage.Error);
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
