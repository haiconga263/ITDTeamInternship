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

namespace TollTicketManagement
{
    /// <summary>
    /// Interaction logic for ManagementView.xaml
    /// </summary>
    public partial class ManagementView : Window
    {
        public ManagementView()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //OneStation oneStation = new OneStation("2");
            //Grid.SetRow(oneStation, 0);
            //Grid.SetColumn(oneStation, 0);
            //mainGrid.Children.Add(oneStation);
        }
    }
}
