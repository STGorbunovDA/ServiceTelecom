using ServiceTelecom.Infrastructure;
using ServiceTelecom.Infrastructure.Interfaces;
using ServiceTelecom.Models;
using ServiceTelecom.Models.Base;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace ServiceTelecom.ViewModels.WorkViewModelPackage
{
    internal class AddChangeRepresentativeRCSViewModel : ViewModelBase
    {
        IGetSetRegistryServiceTelecomSetting _getSetRegistryServiceTelecomSetting;
        
        string _nameRepresentativeRCS;
        
        public string NameRepresentativeRCS
        {
            get => _nameRepresentativeRCS;
            set
            {
                _nameRepresentativeRCS = value;
                OnPropertyChanged(nameof(NameRepresentativeRCS));
            }
        }
        string _postRepresentativeRCS;

        public string PostRepresentativeRCS
        {
            get => _postRepresentativeRCS;
            set
            {
                _postRepresentativeRCS = value;
                OnPropertyChanged(nameof(PostRepresentativeRCS));
            }
        }


        public ICommand AddChangeRepresentativeRCS { get; }
        
        public AddChangeRepresentativeRCSViewModel()
        {
            _getSetRegistryServiceTelecomSetting = new GetSetRegistryServiceTelecomSetting();
            NameRepresentativeRCS 
                = _getSetRegistryServiceTelecomSetting.GetRegistryNameRepresentativeRCS();
            PostRepresentativeRCS = _getSetRegistryServiceTelecomSetting.GetRegistryPostRepresentativeRCS();
            AddChangeRepresentativeRCS = 
                new ViewModelCommand(ExecuteAddChangeNameRadioCommunicationDirectorateCommand);
        }


        #region AddChangeRepresentativeRCS

        void ExecuteAddChangeNameRadioCommunicationDirectorateCommand(object obj)
        {
            if (!string.IsNullOrWhiteSpace(NameRepresentativeRCS) &&
                !string.IsNullOrWhiteSpace(PostRepresentativeRCS))
            {
                if (!NameRepresentativeRCS.Contains("-"))
                {
                    if (!Regex.IsMatch(NameRepresentativeRCS,
                        @"^[А-ЯЁ][а-яё]*(([\s]+[А-Я][\.]+[А-Я]+[\.])$)"))
                    {
                        MessageBox.Show("Введите корректно поле \"Представитель ФИО\" " +
                            "пример Иванов И.И.", "Отмена",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }
                }
                if (NameRepresentativeRCS.Contains("-"))
                {
                    if (!Regex.IsMatch(NameRepresentativeRCS,
                        @"^[А-ЯЁ][а-яё]*(([\-][А-Я][а-яё]*[\s]+[А-Я]+[\.]+[А-Я]+[\.])$)"))
                    {
                        MessageBox.Show("Введите корректно поле \"Представитель ФИО\" " +
                            "пример Иванова-Сидорова Я.И.", "Отмена",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }
                }
                _getSetRegistryServiceTelecomSetting.
                    SetRegistryRepresentativeRCS(
                    NameRepresentativeRCS, PostRepresentativeRCS);
                GlobalValue.RCS_REPRESENTATIVE_TO_SIGN_ACTS 
                    = _getSetRegistryServiceTelecomSetting.GetRegistryNameRepresentativeRCS();
                GlobalValue.RCS_POST_TO_SIGN_ACTS =
                    _getSetRegistryServiceTelecomSetting.GetRegistryPostRepresentativeRCS();
            }                
        }

        #endregion

    }
}
