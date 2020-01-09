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

namespace Registration_ADO
{
    /// <summary>
    /// Interaction logic for WindowHello.xaml
    /// </summary>
    public partial class WindowHello : Window
    {

        public User user;

        public WindowHello()
        {
            InitializeComponent();

        }

        private void Thanks_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // закрытие окна
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            HelloText.Text = HelloText.Text.Replace("{RealName}", user.RealName);
            HelloLastDate.Text = HelloLastDate.Text.Replace("{LastVisitDate}",user.RegisterDT.ToString());
        }
    }
}
