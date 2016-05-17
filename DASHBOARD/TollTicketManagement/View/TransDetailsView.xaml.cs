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
using TollTicketManagement.Model;
using TollTicketManagement.ViewModel;

namespace TollTicketManagement.View
{
    /// <summary>
    /// Interaction logic for TransDetailsView.xaml
    /// </summary>
    public partial class TransDetailsView : Window
    {
        private TransDetailsViewModel vm;
        public TransDetailsView(WhiteList wl)
        {
            InitializeComponent();
            vm = new TransDetailsViewModel(wl);
            DataContext = vm;
        }
    }
}
