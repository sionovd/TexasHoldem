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
            dgReplays.Items.Add(new object());
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu();
            this.Content = menu;
        }

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (!GameWindow.firstInitiate)
            {

                (GameWindow.gameWindow.tabControl.SelectedItem as TabItem).Header = "Replay";
                TabItem newTabItem = new TabItem();
                newTabItem.Header = "Menu";
                Menu newMenu = new Menu();
                newMenu.btnLogout.Visibility = Visibility.Hidden;
                newTabItem.Content = newMenu;
                GameWindow.gameWindow.tabControl.Items.Add(newTabItem);
                UserControlReplay replay = new UserControlReplay();
                this.Content = replay;
            }
            else
            {
                GameWindow.gameWindow = new GameWindow();
                GameWindow.gameWindow.firstTab.Content = new UserControlReplay();
                GameWindow.gameWindow.firstTab.Header = "Replay";
                GameWindow.gameWindow.Show();
                GameWindow.firstInitiate = false;
                Window.GetWindow(this).Close();

            }
        }
    }
}
