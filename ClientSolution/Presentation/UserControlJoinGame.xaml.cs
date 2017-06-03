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
            if (!GameWindow.firstInitiate)
            {

                (GameWindow.gameWindow.tabControl.SelectedItem as TabItem).Header = "Active Game";
                TabItem newTabItem = new TabItem();
                newTabItem.Header = "Menu";
                Menu newMenu = new Menu();
                newMenu.btnLogout.Visibility = Visibility.Hidden;
                newTabItem.Content = newMenu;
                GameWindow.gameWindow.tabControl.Items.Add(newTabItem);
                UserControlGame game = new UserControlGame();
                this.Content = game;
            }
            else
            {
                GameWindow.firstInitiate = false;
                GameWindow.gameWindow = new GameWindow();
                GameWindow.gameWindow.firstTab.Content = new UserControlGame();
                GameWindow.gameWindow.firstTab.Header = "Active Game";
                GameWindow.gameWindow.Show();
                var window = Window.GetWindow(this);
                if (window != null) window.Close();
            }
        }
    }
}
