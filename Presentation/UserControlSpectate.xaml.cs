﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Presentation
{
    /// <summary>
    /// Interaction logic for UserControlSpectate.xaml
    /// </summary>
    public partial class UserControlSpectate : UserControl
    {
        public UserControlSpectate()
        {
            InitializeComponent();
        }

        private void BtnLeaveTable_Click(object sender, RoutedEventArgs e)
        {
            if (GameWindow.gameWindow.tabControl.Items.Count <= 2)
            {
                GameWindow.firstInitiate = true;
                MainMenu mainMenu = new MainMenu();
                mainMenu.Show();
                GameWindow.gameWindow.Close();
            }
            else
            {

                GameWindow.gameWindow.tabControl.Items.Remove(GameWindow.gameWindow.tabControl.SelectedItem);
            }

        }



    }
}