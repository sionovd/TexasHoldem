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
    /// Interaction logic for UserControlCreateGame.xaml
    /// </summary>
    public partial class UserControlCreateGame : UserControl
    {
        public UserControlCreateGame()
        {
            InitializeComponent();
        }



        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu();
            this.Content = menu;
            
        }

        private void slMaxPlayers_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            if (slMaxPlayers.Value < slMinPlayers.Value)
                slMinPlayers.Value = slMaxPlayers.Value;
        }
        private void txtMaxPlayers_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (slMaxPlayers.Value < slMinPlayers.Value)
                slMinPlayers.Value = slMaxPlayers.Value;
        }

        private void slMinPlayers_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            if (slMinPlayers.Value > slMaxPlayers.Value)
                slMaxPlayers.Value = slMinPlayers.Value;
        }

        private void txtMinPlayers_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (slMinPlayers.Value > slMaxPlayers.Value)
                slMaxPlayers.Value = slMinPlayers.Value;

        }

        private int _numValue1 = 0;
        private int _numValue2 = 0;

        public int NumValue1
        {
            get { return _numValue1; }
            set
            {
                _numValue1 = value;
                txtBuyIn.Text = value.ToString();
            }
        }

        private void cmdUp_Click1(object sender, RoutedEventArgs e)
        {
            NumValue1++;
        }

        private void cmdDown_Click1(object sender, RoutedEventArgs e)
        {
            if (NumValue1 > 0)
                NumValue1--;
        }

        private void txtNum_TextChanged1(object sender, TextChangedEventArgs e)
        {
            if (txtBuyIn == null)
            {
                return;
            }

            if (!int.TryParse(txtBuyIn.Text, out _numValue1))
            {
                txtBuyIn.Text = _numValue1.ToString();
            }
            else
            {
                if (_numValue1 < 0)
                    txtBuyIn.Text = "0";
            }
        }

        public int NumValue2
        {
            get { return _numValue2; }
            set
            {
                _numValue2 = value;
                txtChipPolicy.Text = value.ToString();
            }
        }



        private void cmdUp_Click2(object sender, RoutedEventArgs e)
        {
            NumValue2++;
        }

        private void cmdDown_Click2(object sender, RoutedEventArgs e)
        {
            if (NumValue2 > 0)
                NumValue2--;
        }

        private void txtNum_TextChanged2(object sender, TextChangedEventArgs e)
        {
            if (txtChipPolicy == null)
            {
                return;
            }

            if (!int.TryParse(txtChipPolicy.Text, out _numValue2))
                txtChipPolicy.Text = _numValue2.ToString();
            else
            {
                if (_numValue2 < 0)
                    txtChipPolicy.Text = "0";
            }
        }

        private void btnJoinGame_Click(object sender, RoutedEventArgs e)
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
        
                Window.GetWindow(this).Close();

            }
           

            
            

        }
    }
}
