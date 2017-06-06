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
    /// Interaction logic for UserControlWatchReplayes.xaml
    /// </summary>
    public partial class UserControlWatchReplayes : UserControl
    {
        public UserControlWatchReplayes()
        {
            InitializeComponent();
            
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu();
            this.Content = menu;
        }

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            if (!UserControlTabs.firstInitiate)
            {

                (UserControlTabs.userControlTabs.tabControl.SelectedItem as TabItem).Header = "Replay";
                TabItem newTabItem = new TabItem();
                newTabItem.Header = "Menu";
                Menu newMenu = new Menu();
                newMenu.btnLogout.Visibility = Visibility.Hidden;
                newTabItem.Content = newMenu;
                UserControlTabs.userControlTabs.tabControl.Items.Add(newTabItem);
                UserControlReplay replay = new UserControlReplay();
                this.Content = replay;
            }
            else
            {
                UserControlTabs.firstInitiate = false;
                UserControlTabs.userControlTabs = new UserControlTabs();
                UserControlTabs.userControlTabs.firstTab.Content = new UserControlReplay();
                UserControlTabs.userControlTabs.firstTab.Header = "Replay";
                this.Content = UserControlTabs.userControlTabs;

            }
        }
    }
}
