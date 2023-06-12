using ServiceTelecom.Infrastructure;
using ServiceTelecom.Infrastructure.Interfaces;
using ServiceTelecom.Models;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace ServiceTelecom.View.WorkViewPackage
{
    public partial class PrintRepairView : Window
    {
        List<RepairDataCompanyModel> repairData;
        GetSetRegistryServiceTelecomSetting getSetRegistryServiceTelecomSetting;
        public PrintRepairView()
        {
            repairData = new List<RepairDataCompanyModel>();
            getSetRegistryServiceTelecomSetting = new GetSetRegistryServiceTelecomSetting();

            InitializeComponent();
            Loaded += PrintRepairView_Loader;
            repairData = getSetRegistryServiceTelecomSetting.GetRepairData(txbCompany.Text);

            foreach (var item in repairData)
            {
                txbOKPO.Text = item.OKPO;
                txbBE.Text = item.BE;
                txbFullNameCompany.Text = item.FullNameCompany;
                txbChiefСompanyFIO.Text = item.ChiefСompanyFIO;
                txbChiefСompanyPost.Text = item.ChiefСompanyPost;
                txbChairmanСompanyFIO.Text = item.ChairmanСompanyFIO;
                txbChairmanСompanyPost.Text = item.ChairmanСompanyPost;
                txbFirstMemberCommissionFIO.Text = item.FirstMemberCommissionFIO;
                txbFirstMemberCommissionPost.Text = item.FirstMemberCommissionPost;
                txbSecondMemberCommissionFIO.Text = item.SecondMemberCommissionFIO;
                txbSecondMemberCommissionPost.Text = item.SecondMemberCommissionPost;
                txbThirdMemberCommissionFIO.Text = item.ThirdMemberCommissionFIO;
                txbThirdMemberCommissionPost.Text = item.ThirdMemberCommissionPost;
            }

            if (!string.IsNullOrWhiteSpace(txbOKPO.Text) &&
               !string.IsNullOrWhiteSpace(txbBE.Text) &&
               !string.IsNullOrWhiteSpace(txbFullNameCompany.Text) &&
               !string.IsNullOrWhiteSpace(txbChiefСompanyFIO.Text) &&
               !string.IsNullOrWhiteSpace(txbChiefСompanyPost.Text) &&
               !string.IsNullOrWhiteSpace(txbChairmanСompanyFIO.Text) &&
               !string.IsNullOrWhiteSpace(txbChairmanСompanyPost.Text) &&
               !string.IsNullOrWhiteSpace(txbFirstMemberCommissionFIO.Text) &&
               !string.IsNullOrWhiteSpace(txbFirstMemberCommissionPost.Text) &&
               !string.IsNullOrWhiteSpace(txbSecondMemberCommissionFIO.Text) &&
               !string.IsNullOrWhiteSpace(txbSecondMemberCommissionPost.Text))
            {
                CheckBoxDisableThirdVerification.IsChecked = true;
                CheckContinue.IsChecked = true;
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void BtnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }


        private void PrintRepairView_Loader(object sender, RoutedEventArgs e)
        {
            if (DataContext is ICloseWindows vm)
            {
                vm.Close += () =>
                {
                    this.Close();
                };
            }
        }
    }
}
