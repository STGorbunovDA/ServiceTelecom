﻿using ServiceTelecom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ServiceTelecom.View
{
    /// <summary>
    /// Логика взаимодействия для WorkView.xaml
    /// </summary>
    public partial class WorkView : Window
    {
        readonly UserModel _user;
        public WorkView(UserModel user)
        {
            _user = user;
            InitializeComponent();
        }


        void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
    }
}