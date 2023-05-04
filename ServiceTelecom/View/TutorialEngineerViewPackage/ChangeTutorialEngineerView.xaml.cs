using ServiceTelecom.Models;
using System.Windows;
using System.Windows.Input;

namespace ServiceTelecom.View.TutorialEngineerViewPackage
{

    public partial class ChangeTutorialEngineerView : Window
    {
        public ChangeTutorialEngineerView(TutorialEngineerDataBaseModel tutorialEngineerDataBase)
        {
            InitializeComponent();
            txbId.Text = tutorialEngineerDataBase.IdTutorialEngineer.ToString();
            cmbModel.Text = tutorialEngineerDataBase.Model;
            cmbProblem.Text = tutorialEngineerDataBase.Problem;
            txbInfo.Text = tutorialEngineerDataBase.Info;
            txbActions.Text = tutorialEngineerDataBase.Actions;
        }

        private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void BtnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
