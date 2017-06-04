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
    /// Interaction logic for UserControlJoinGame.xaml
    /// </summary>
    public partial class UserControlJoinGame : UserControl
    {
        public UserControlJoinGame()
        {
            InitializeComponent();
            dgJoinGame.Items.Add(new object());
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            UserControlSearchToJoin searchToJoin = new UserControlSearchToJoin();
            this.Content = searchToJoin;
        }

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            if (!UserControlTabs.firstInitiate)
            {

                (UserControlTabs.userControlTabs.tabControl.SelectedItem as TabItem).Header = "Active Game";
                TabItem newTabItem = new TabItem();
                newTabItem.Header = "Menu";
                Menu newMenu = new Menu();
                newMenu.btnLogout.Visibility = Visibility.Hidden;
                newTabItem.Content = newMenu;
                UserControlTabs.userControlTabs.tabControl.Items.Add(newTabItem);
                UserControlGame game = new UserControlGame();
                this.Content = game;
            }
            else
            {
                UserControlTabs.firstInitiate = false;
                UserControlTabs.userControlTabs = new UserControlTabs();
                UserControlTabs.userControlTabs.firstTab.Content = new UserControlGame();
                UserControlTabs.userControlTabs.firstTab.Header = "Active Game";
                this.Content = UserControlTabs.userControlTabs;

            }


        }
    }
}
