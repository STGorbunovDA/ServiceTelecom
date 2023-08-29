﻿using System.Windows;
using System.Windows.Input;

namespace ServiceTelecom.View.Base
{
    public partial class AddFrequencyRadiostantionView : Window
    {
        public AddFrequencyRadiostantionView()
        {
            InitializeComponent();
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

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
