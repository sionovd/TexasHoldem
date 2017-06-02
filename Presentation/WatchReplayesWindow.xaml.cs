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
using System.Windows.Shapes;

namespace Presentation
{
    /// <summary>
    /// Interaction logic for WatchReplayesWindow.xaml
    /// </summary>
    public partial class WatchReplayesWindow : Window
    {
        public WatchReplayesWindow()
        {
            InitializeComponent();
            UserControlWatchReplayes watchReplays = new UserControlWatchReplayes();
            watchReplays.btnBack.Click += new RoutedEventHandler(Button_Click_Back);
            this.Content = watchReplays;
        }

        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {

            MainMenu menu = new MainMenu();
            menu.Show();
            this.Close();
        }
    }
}
