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
    /// Interaction logic for UserControlTabs.xaml
    /// </summary>
    public partial class UserControlTabs : UserControl
    {

        public static UserControlTabs userControlTabs;
        public static bool firstInitiate = true;

        public UserControlTabs()
        {
            InitializeComponent();
            Menu menu = new Menu();
            menuTab.Content = menu;
        }
    }
}
