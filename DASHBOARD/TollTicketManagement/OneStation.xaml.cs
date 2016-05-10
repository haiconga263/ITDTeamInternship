using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using TollTicketManagement.Model;

namespace TollTicketManagement
{
    /// <summary>
    /// Interaction logic for OneStation.xaml
    /// </summary>
    public partial class OneStation : UserControl
    {

        #region Property

        private string stationID;
        private string stationName;
        public string StationID
        {
            get { return stationID; }
        }
        /// <summary>
        /// List làn vào
        /// </summary>
        public List<InLaneTicketModel> InLanes;

        /// <summary>
        /// List làn ra
        /// </summary>
        public List<OutLaneTicketModel> OutLanes;

        /// <summary>
        /// Tổng thẻ còn lại của làn vào
        /// </summary>
        public int InRemainTicket;

        /// <summary>
        /// Tổng thẻ làn ra
        /// </summary>
        public int OutTicket;

        /// <summary>
        /// Lượng tồn của trạm
        /// </summary>
        public int InStockTicket;

        public delegate void TicketStationChange();

        public event TicketStationChange OnTicketStationChange;

        #endregion
        public OneStation()
        {
            InitializeComponent();
        }

        public OneStation(string id)
        {
            InitializeComponent();
            stationID = id;
            
        }

        /// <summary>
        /// Lấy tất cả các làn của một station
        /// </summary>
        private void GetStationLane()
        {
            string sqlCmd = "SELECT * FROM LS_Lane where StationID = " + stationID;
            string connectionString = "data source= DUY-HA;initial catalog=HPE_CMO;persist security info=True;user id = sa;password=123456;Connection Timeout=10; MultipleActiveResultSets=True;App=EntityFramework";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter dataadapter = new SqlDataAdapter(sqlCmd, connection);
            DataTable dt = new DataTable();
            connection.Open();
            dataadapter.Fill(dt);
            connection.Close();

            InLanes = new List<InLaneTicketModel>();
            OutLanes = new List<OutLaneTicketModel>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][4].ToString() == "0")
                {
                    InLaneTicketModel inLane = new InLaneTicketModel(dt.Rows[i][2].ToString());
                    inLane.OnInTicketChange += new InLaneTicketModel.InTicketChange(OnInTicketChangeStation);
                    InLanes.Add(inLane);
                }
                else
                {
                    OutLaneTicketModel outLane = new OutLaneTicketModel(dt.Rows[i][2].ToString());
                    outLane.OnOutTicketChange += new OutLaneTicketModel.OutTicketChange(OnOutTicketChangeStation);
                    OutLanes.Add(outLane);
                }
            }
        }

        private void GetStationInfo()
        {
            string sqlCmd = "SELECT * FROM LS_Station where StationID = " + stationID;
            string connectionString = "data source= DUY-HA;initial catalog=HPE_CMO;persist security info=True;user id = sa;password=123456;Connection Timeout=10; MultipleActiveResultSets=True;App=EntityFramework";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter dataadapter = new SqlDataAdapter(sqlCmd, connection);
            DataTable dt = new DataTable();
            connection.Open();
            dataadapter.Fill(dt);
            connection.Close();

            if (dt.Rows[0][2] != null)
                this.stationName = dt.Rows[0][2].ToString();
        }

        private void OnOutTicketChangeStation(int changeNum)
        {
            OutTicket += changeNum;
            OnTicketStationChange();
        }

        private void OnInTicketChangeStation(int changeNum)
        {
            InRemainTicket -= changeNum;
            OnTicketStationChange();
        }

        private void LoadUI()
        {

        }

        private void SetUI()
        {

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //GetStationLane();
        }

        

        
    }
}
