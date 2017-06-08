using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
using Communication;
using Communication.Replies;

namespace Presentation
{
    /// <summary>
    /// Interaction logic for UserControlSpectateGame.xaml
    /// </summary>
    public partial class UserControlSpectateGame : UserControl
    {
        private List<Game> results;
        public UserControlSpectateGame(List<Game> results)
        {
            InitializeComponent();
            this.results = results;
            dgSpectateGame.ItemsSource = results;
           
          
        }


        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu();
            this.Content = menu;
        }

        private async void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {   DataGridRow row = sender as DataGridRow;
            int index = row.GetIndex();
            int gameID = results[index].GameID;
            ReplyInt accept;
            try
            {
               accept =  await Client.SpectateGame(gameID);
                if (!accept.Sucsses)
                {
                    MessageBox.Show(accept.ErrorMessage, "Warning");
                }
                else
                {
                    int spectatorID = accept.IntContent;

                    if (!UserControlTabs.firstInitiate)
                    {

                        (UserControlTabs.userControlTabs.tabControl.SelectedItem as TabItem).Header = "Spectation";
                        TabItem newTabItem = new TabItem();
                        newTabItem.Header = "Menu";
                        Menu newMenu = new Menu();
                        newMenu.btnLogout.Visibility = Visibility.Hidden;
                        newTabItem.Content = newMenu;
                        UserControlTabs.userControlTabs.tabControl.Items.Add(newTabItem);
                        UserControlSpectate spectate = new UserControlSpectate(gameID,spectatorID);
                        this.Content = spectate;
                    }
                    else
                    {
                        UserControlTabs.firstInitiate = false;
                        UserControlTabs.userControlTabs = new UserControlTabs();
                        UserControlTabs.userControlTabs.firstTab.Content = new UserControlSpectate(gameID, spectatorID);
                        UserControlTabs.userControlTabs.firstTab.Header = "Spectation";
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
