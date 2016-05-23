using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
using TollTicketManagement.Controller;
using TollTicketManagement.Model;

namespace TollTicketManagement.View
{
    /// <summary>
    /// Interaction logic for OverViewTransactionDetail.xaml
    /// </summary>
    public partial class OverViewTransactionDetail : Window
    {
        private OverTransactionDetail dataResult;
        public OverViewTransactionDetail(string smartcardid,string recogplatenumber,string stationin,string lanein,string shift,string checkdate, string imageiD)
        {
            InitializeComponent();
            dataResult = new OverTransactionDetail()
            {
                SmartCardID = "Mã thẻ: " + smartcardid,
                RecogPlateNumber = "Biển số: " + recogplatenumber,
                StationIn = "Trạm: " + stationin,
                LaneIn = "Làn: " + lanein,
                Shift = "Ca: " + shift,
                CheckDate = "Ngày giờ: " + checkdate,
                ImageID = imageiD
            };
            this.DataContext = dataResult;
        }

    }
}
