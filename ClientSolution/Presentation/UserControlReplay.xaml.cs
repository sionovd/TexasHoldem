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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Presentation
{
    /// <summary>
    /// Interaction logic for UserControlReplay.xaml
    /// </summary>
    public partial class UserControlReplay : UserControl
    {
        public UserControlReplay()
        {
            InitializeComponent();
        }

        private void BtnLeaveTable_Click(object sender, RoutedEventArgs e)
        {
            if (GameWindow.gameWindow.tabControl.Items.Count <= 2)
            {
                GameWindow.firstInitiate = true;
                Menu menu = new Menu();
                GameWindow.gameWindow.Content = menu;
            }
            else
            {

                GameWindow.gameWindow.tabControl.Items.Remove(((GameWindow)Window.GetWindow(this)).tabControl.SelectedItem);
            }



        }

     
    }
}
