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


namespace TollTicketManagement.View
{
    /// <summary>
    /// Interaction logic for wdnStatistical.xaml
    /// </summary>
    public partial class Statistical : Window
    {
        public Statistical()
        {
            InitializeComponent();
            
        }
        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnTKTheMat_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string sql = string.Format("exec usp_TKTheMat");
                DataTable dt = DataProvider.ExecuteQuery(sql);

                rpTKTheMat_PPC report = new rpTKTheMat_PPC();
                report.SetDataSource(dt);
                rpView.ViewerCore.ReportSource = report;
            }
            catch
            {
                throw;
            }
        }

        private void btnTKLoTrinh_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string sql = string.Format("exec usp_TKLoTrinhDiNhieuNhat");
                DataTable dt = DataProvider.ExecuteQuery(sql);

                rpTKLoTrinhDiNhieuNhat report = new rpTKLoTrinhDiNhieuNhat();
                report.SetDataSource(dt);
                rpView.ViewerCore.ReportSource = report;
            }
            catch
            {
                throw;
            }
        }
    }
}
