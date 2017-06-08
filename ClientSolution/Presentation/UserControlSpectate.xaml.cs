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
    /// Interaction logic for UserControlSpectate.xaml
    /// </summary>
    public partial class UserControlSpectate : UserControl
    {
        private int gameID;
        private int spectatorID;
        public UserControlSpectate(int gameID, int spectatorID)
        {
            this.gameID = gameID;
            this.spectatorID = spectatorID;
            InitializeComponent();
        }

        private async void BtnLeaveTable_Click(object sender, RoutedEventArgs e)
        {
            Reply accept;
            try
            {
                accept = await Client.LeaveGame(gameID);

                if (!accept.Sucsses)
                {
                    MessageBox.Show(accept.ErrorMessage, "Warning");
                }
                else
                {

                    if (UserControlTabs.userControlTabs.tabControl.Items.Count <= 2)
                    {
                        UserControlTabs.firstInitiate = true;
                        Menu menu = new Menu();
                        UserControlTabs.userControlTabs.Content = menu;
                    }
                    else
                    {

                        UserControlTabs.userControlTabs.tabControl.Items.Remove(UserControlTabs.userControlTabs
                            .tabControl.SelectedItem);
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
