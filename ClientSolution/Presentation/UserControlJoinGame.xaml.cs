using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Net.Http;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Communication;
using Communication.Replies;

namespace Presentation
{
    /// <summary>
    /// Interaction logic for UserControlJoinGame.xaml
    /// </summary>
    public partial class UserControlJoinGame : UserControl
    {
        private List<Game> results;
        public UserControlJoinGame(List<Game> results)
        {
            this.results = results;
            InitializeComponent();
            dgJoinGame.ItemsSource =results;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            UserControlSearchToJoin searchToJoin = new UserControlSearchToJoin();
            this.Content = searchToJoin;
        }

        private async void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataGridRow row = sender as DataGridRow;
            int i = row.GetIndex();
            int gameID = results[i].GameID;
            int playerID;
            Reply accept;
            try
            {
                accept = await Client.JoinGame(gameID);

                if (!accept.Sucsses)
                {
                    MessageBox.Show(((DataString)accept.Content).Content, "Warning");
                }
                else
                {
                    playerID = ((DataInt)accept.Content).Content;
                    if (!UserControlTabs.firstInitiate)
                    {

                        (UserControlTabs.userControlTabs.tabControl.SelectedItem as TabItem).Header = "Active Game";
                        TabItem newTabItem = new TabItem();
                        newTabItem.Header = "Menu";
                        Menu newMenu = new Menu();
                        newMenu.btnLogout.Visibility = Visibility.Hidden;
                        newTabItem.Content = newMenu;
                        UserControlTabs.userControlTabs.tabControl.Items.Add(newTabItem);
                        UserControlGame game = new UserControlGame(gameID, playerID);
                        this.Content = game;
                    }
                    else
                    {
                        UserControlTabs.firstInitiate = false;
                        UserControlTabs.userControlTabs = new UserControlTabs();
                        UserControlTabs.userControlTabs.firstTab.Content = new UserControlGame(gameID, playerID);
                        UserControlTabs.userControlTabs.firstTab.Header = "Active Game";
                        this.Content = UserControlTabs.userControlTabs;

                    }
                }
            }
            catch (HttpRequestException exception)
            {
                MessageBox.Show(exception.Message, "Warning");
            }


        }
    }
}
