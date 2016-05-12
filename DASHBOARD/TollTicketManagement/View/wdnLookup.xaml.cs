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

namespace TollTicketManagement.View
{
    /// <summary>
    /// Interaction logic for wdnLookup.xaml
    /// </summary>
    public partial class wdnLookup : Window
    {
        public List<LS_VehicleType> lstVeh { get; set; }
        public wdnLookup()
        {
            InitializeComponent();
            using (var dc = new QLHPDataContext())
            {
                 lstVeh = dc.LS_VehicleTypes.Select(x => x).ToList();
            }
            lstVeh.Insert(0, new LS_VehicleType() { Name = "Tất cả", VehicleTypeID = -1 });
            DataContext = this;
        }
    }
}
