using System;
using System.Collections.Generic;
using System.Data;
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
using TollTicketManagement.Report;

namespace TollTicketManagement
{
    /// <summary>
    /// Interaction logic for wdnRoute.xaml
    /// </summary>
    public partial class wdnRoute : Window
    {
        public wdnRoute()
        {
            InitializeComponent();
            crThongKeLoTrinh cr = new crThongKeLoTrinh();
            
            
                //var query = from c in DatabaseContext.Instance.OUT_CheckSmartCards
                //join v in DatabaseContext.Instance.LS_Routes on c.RouteCode equals v.RouteCode
                //join c in DatabaseContext.Instance.LS_VehicleTypes on c. equals c.id
                //where c.Name == clientName
                //select new { p = c, r, v };

            //List<AC_PPCWhiteList> lst = DatabaseContext.Instance.AC_PPCWhiteLists.Select(x => x).ToList();

            //DataTable dtbl = new DataTable();
            //cr.SetDataSource(lst);
            //crv.ViewerCore.ReportSource = cr;
        }
    }
}
