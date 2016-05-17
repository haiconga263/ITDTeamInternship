using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TollManagement.Data;
using TollTicketManagement.Model;
using TollTicketManagement.Report;

namespace TollTicketManagement.View
{
    /// <summary>
    /// Interaction logic for Test.xaml
    /// </summary>
    public partial class Test : Window
    {
        public Test()
        {
            InitializeComponent();
        }

        private void CrystalReportViewer1_Loaded(object sender, RoutedEventArgs e)
        {
            ////B1. Đưa dữ liệu vào bảng NhanVien và PhongBan vào dataset
            //String sql = @"SELECT * FROM AC_PPCWhiteList;SELECT * FROM LS_VehicleType ";
            //string connectionstring = @"Data Source=SOFT-W\MSSQLSERVER2K14;Initial Catalog=HPE;Persist Security Info=True;User ID=sv2;Password=123456;MultipleActiveResultSets=True;Application Name=EntityFramework";
            //SqlDataAdapter adapter = new SqlDataAdapter(sql, connectionstring);
            //adapter.TableMappings.Add("Table", "AC_PPCWhiteList");
            //adapter.TableMappings.Add("Table1", "LS_VehicleType");
            ////adapter.TableMappings.Add("Table2", "LS_Lane");
            ////adapter.TableMappings.Add("Table3", "LS_VehicleType");
            //DataSet dtset = new DataSet();
            //adapter.Fill(dtset);
            ////B2. Khai báo một biến report
            //rpTest report = new rpTest();
            ////B3. Gán dataset cho report

            //report.SetDataSource(dtset);
            //rpView.ViewerCore.ReportSource = report;


            string sql = string.Format("exec sp_TestRP");
            DataTable dt = DataProvider.ExecuteQuery(sql);
          
            rpTest report = new rpTest();
            report.SetDataSource(dt);
            rpView.ViewerCore.ReportSource = report;
        }
    }
}
