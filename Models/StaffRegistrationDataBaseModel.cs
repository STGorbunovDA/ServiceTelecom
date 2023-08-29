using ServiceTelecom.Infrastructure;
using ServiceTelecom.ViewModels;

namespace ServiceTelecom.Models
{
    public class StaffRegistrationDataBaseModel : ViewModelBase
    {
        private int _idStaffRegistration;
        private string _sectionForeman;
        private string _engineer;
        private string _attorney;
        private string _road;
        private string _numberPrintDocument;
        private string _curator;
        private string _radioCommunicationDirectorate;

        public int IdStaffRegistrationBase { get => _idStaffRegistration; set { _idStaffRegistration = value; OnPropertyChanged(nameof(IdStaffRegistrationBase)); } }
        public string SectionForemanBase { get => _sectionForeman; set { _sectionForeman = value; OnPropertyChanged(nameof(SectionForemanBase)); } }
        public string EngineerBase { get => _engineer; set { _engineer = value; OnPropertyChanged(nameof(EngineerBase)); } }
        public string AttorneyBase { get => _attorney; set { _attorney = value; OnPropertyChanged(nameof(AttorneyBase)); } }
        public string RoadBase { get => _road; set { _road = value; OnPropertyChanged(nameof(RoadBase)); } }
        public string NumberPrintDocumentBase { get => _numberPrintDocument; set { _numberPrintDocument = value; OnPropertyChanged(nameof(NumberPrintDocumentBase)); } }
        public string CuratorBase { get => _curator; set { _curator = value; OnPropertyChanged(nameof(CuratorBase)); } }
        public string RadioCommunicationDirectorateBase { get => _radioCommunicationDirectorate; set { _radioCommunicationDirectorate = value; OnPropertyChanged(nameof(RadioCommunicationDirectorateBase)); } }

        public StaffRegistrationDataBaseModel(int idStaffRegistration, string sectionForeman, string engineer, 
            string attorney, string road, string numberPrintDocument, string curator, string radioCommunicationDirectorate)
        {
            _idStaffRegistration = idStaffRegistration;
            _sectionForeman = Encryption.DecryptCipherTextToPlainText(sectionForeman);
            _engineer = Encryption.DecryptCipherTextToPlainText(engineer);
            _attorney = Encryption.DecryptCipherTextToPlainText(attorney);
            _road = Encryption.DecryptCipherTextToPlainText(road);
            _numberPrintDocument = Encryption.DecryptCipherTextToPlainText(numberPrintDocument);
            _curator = Encryption.DecryptCipherTextToPlainText(curator);
            _radioCommunicationDirectorate = Encryption.DecryptCipherTextToPlainText(radioCommunicationDirectorate);    
        }  
    }
}
