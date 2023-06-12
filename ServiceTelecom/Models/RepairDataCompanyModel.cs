using ServiceTelecom.ViewModels;

namespace ServiceTelecom.Models
{
    internal class RepairDataCompanyModel : ViewModelBase
    {
        private string _okpo;
        private string _be;
        private string _fullNameCompany;
        private string _chiefСompanyFIO;
        private string _chiefСompanyPost;
        private string _chairmanСompanyFIO;
        private string _chairmanСompanyPost;
        private string _firstMemberCommissionFIO;
        private string _firstMemberCommissionPost;
        private string _secondMemberCommissionFIO;
        private string _secondMemberCommissionPost;
        private string _thirdMemberCommissionFIO;
        private string _thirdMemberCommissionPost;

        public RepairDataCompanyModel(string oKPO, string bE, 
            string fullNameCompany, string chiefСompanyFIO, 
            string chiefСompanyPost, string chairmanСompanyFIO, 
            string chairmanСompanyPost, string firstMemberCommissionFIO, 
            string firstMemberCommissionPost, string secondMemberCommissionFIO, 
            string secondMemberCommissionPost, string thirdMemberCommissionFIO, 
            string thirdMemberCommissionPost)
        {
            OKPO = oKPO;
            BE = bE;
            FullNameCompany = fullNameCompany;
            ChiefСompanyFIO = chiefСompanyFIO;
            ChiefСompanyPost = chiefСompanyPost;
            ChairmanСompanyFIO = chairmanСompanyFIO;
            ChairmanСompanyPost = chairmanСompanyPost;
            FirstMemberCommissionFIO = firstMemberCommissionFIO;
            FirstMemberCommissionPost = firstMemberCommissionPost;
            SecondMemberCommissionFIO = secondMemberCommissionFIO;
            SecondMemberCommissionPost = secondMemberCommissionPost;
            ThirdMemberCommissionFIO = thirdMemberCommissionFIO;
            ThirdMemberCommissionPost = thirdMemberCommissionPost;
        }

        public string OKPO { get => _okpo; set { _okpo = value; OnPropertyChanged(nameof(OKPO)); } }
        public string BE { get => _be; set { _be = value; OnPropertyChanged(nameof(BE)); } }
        public string FullNameCompany { get => _fullNameCompany; set { _fullNameCompany = value; OnPropertyChanged(nameof(FullNameCompany)); } }
        public string ChiefСompanyFIO { get => _chiefСompanyFIO; set { _chiefСompanyFIO = value; OnPropertyChanged(nameof(ChiefСompanyFIO)); } }
        public string ChiefСompanyPost { get => _chiefСompanyPost; set { _chiefСompanyPost = value; OnPropertyChanged(nameof(ChiefСompanyPost)); } }
        public string ChairmanСompanyFIO { get => _chairmanСompanyFIO; set { _chairmanСompanyFIO = value; OnPropertyChanged(nameof(ChairmanСompanyFIO)); } }
        public string ChairmanСompanyPost { get => _chairmanСompanyPost; set { _chairmanСompanyPost = value; OnPropertyChanged(nameof(ChairmanСompanyPost)); } }
        public string FirstMemberCommissionFIO { get => _firstMemberCommissionFIO; set { _firstMemberCommissionFIO = value; OnPropertyChanged(nameof(FirstMemberCommissionFIO)); } }
        public string FirstMemberCommissionPost { get => _firstMemberCommissionPost; set { _firstMemberCommissionPost = value; OnPropertyChanged(nameof(FirstMemberCommissionPost)); } }
        public string SecondMemberCommissionFIO { get => _secondMemberCommissionFIO; set { _secondMemberCommissionFIO = value; OnPropertyChanged(nameof(SecondMemberCommissionFIO)); } }
        public string SecondMemberCommissionPost { get => _secondMemberCommissionPost; set { _secondMemberCommissionPost = value; OnPropertyChanged(nameof(SecondMemberCommissionPost)); } }
        public string ThirdMemberCommissionFIO { get => _thirdMemberCommissionFIO; set { _thirdMemberCommissionFIO = value; OnPropertyChanged(nameof(ThirdMemberCommissionFIO)); } }
        public string ThirdMemberCommissionPost { get => _thirdMemberCommissionPost; set { _thirdMemberCommissionPost = value; OnPropertyChanged(nameof(ThirdMemberCommissionPost)); } }

        
    }
}
