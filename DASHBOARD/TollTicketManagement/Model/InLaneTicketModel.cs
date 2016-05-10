using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace TollTicketManagement.Model
{
    public class InLaneTicketModel
    {
        private string laneID;
        private string laneCode;
        private int directionType;
        private int transactionTicket;
        private DispatcherTimer LaneTimer;
        

        public delegate void InTicketChange(int changeNum);
        /// <summary>
        /// raise sự kiện khi lượng thẻ của làn thay đổi
        /// </summary>
        public event InTicketChange OnInTicketChange;

        public string LaneID
        {
            get { return laneID; }
        }
        public string LaneCode
        {
            get { return laneCode; }
        }
        /// <summary>
        /// Làn vào - làn ra
        /// </summary>
        public int DirectionType
        {
            get { return directionType; }
            set { directionType = value; }
        }

        /// <summary>
        /// Số thẻ đã giao dịch
        /// </summary>
        public int TransactionTicket
        {
            get { return transactionTicket; }
            set { transactionTicket = value; }
        }


        public InLaneTicketModel(string code)
        {
            laneCode = code;
            LaneTimer = new DispatcherTimer();
            LaneTimer.Interval = new TimeSpan(0, 1, 0);
            LaneTimer.Tick += LaneTimerTick;
        }

        private void LaneTimerTick(object sender, EventArgs e)
        {
            GetLaneTicketInfo();
        }

        private void GetLaneTicketInfo()
        {
            string sqlCmd = @" select COUNT(*) AS 'TicketCount' from IN_CheckSmartCard where LaneID = '" + laneID + "' AND TransactionStatus IS NULL";
            string connectionString = "data source= DUY-HA;initial catalog=HPE_CMO;persist security info=True;user id = sa;password=123456;Connection Timeout=10; MultipleActiveResultSets=True;App=EntityFramework";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter dataadapter = new SqlDataAdapter(sqlCmd, connection);
            DataTable dt = new DataTable();
            connection.Open();
            dataadapter.Fill(dt);
            connection.Close();

            int transactionTicketTmp = int.Parse(dt.Rows[0][0].ToString());
            if (transactionTicketTmp != transactionTicket)
            {
                OnInTicketChange(transactionTicketTmp - transactionTicket);
                transactionTicket = transactionTicketTmp;
            }
        }
    }
}
