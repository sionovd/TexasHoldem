using System;
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
    /// Interaction logic for UserControlWatchReplayes.xaml
    /// </summary>
    public partial class UserControlWatchReplayes : UserControl
    {
        private List<Game> results;
        public UserControlWatchReplayes(List<Game> results)
        {
            InitializeComponent();
            this.results = results;
            dgReplays.ItemsSource = results;

        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu();
            this.Content = menu;
        }

        private async void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataGridRow row = sender as DataGridRow;
            int index = row.GetIndex();
            int replayID = results[index].GameID;
            ReplyString accept;
            try
            {
                accept = await Client.GetReplayInfo(replayID);
                if (!accept.Sucsses)
                {
                    MessageBox.Show(accept.ErrorMessage, "Warning");
                }
                else
                {
                    String replayInfoString= accept.StringContent;
                    ReplayInfo replayInfo = new ReplayInfo(replayInfoString);

                    if (!UserControlTabs.firstInitiate)
                    {

                        (UserControlTabs.userControlTabs.tabControl.SelectedItem as TabItem).Header = "Replay";
                        TabItem newTabItem = new TabItem();
                        newTabItem.Header = "Menu";
                        Menu newMenu = new Menu();
                        newMenu.btnLogout.Visibility = Visibility.Hidden;
                        newTabItem.Content = newMenu;
                        UserControlTabs.userControlTabs.tabControl.Items.Add(newTabItem);
                        UserControlReplay replay = new UserControlReplay(replayInfo);
                        this.Content = replay;
                    }
                    else
                    {
                        UserControlTabs.firstInitiate = false;
                        UserControlTabs.userControlTabs = new UserControlTabs();
                        UserControlTabs.userControlTabs.firstTab.Content = new UserControlReplay(replayInfo);
                        UserControlTabs.userControlTabs.firstTab.Header = "Replay";
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
