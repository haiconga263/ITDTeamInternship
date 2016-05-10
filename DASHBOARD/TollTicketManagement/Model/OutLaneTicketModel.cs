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
    public class OutLaneTicketModel
    {
        private string laneID;
        private string laneCode;
        private int directionType;
        private int totalTicket;
        private DispatcherTimer LaneTimer;

        public delegate void OutTicketChange(int changeNum);
        /// <summary>
        /// raise sự kiện khi lượng thẻ của làn thay đổi
        /// </summary>
        public event OutTicketChange OnOutTicketChange;

        public string LaneID
        {
            get { return laneID; }
            set { laneID = value; }
        }

        public string LaneCode
        {
            get { return laneCode; }
            set { laneCode = value; }
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
        /// Tổng thẻ nhận từ giao dịch
        /// </summary>
        public int TotalTicket
        {
            get { return totalTicket; }
            set { totalTicket = value; }
        }

        public OutLaneTicketModel(string code)
        {
            laneCode = code;
            totalTicket = 0;
            LaneTimer = new DispatcherTimer();
            LaneTimer.Interval = new TimeSpan(0, 1,0);
            LaneTimer.Tick += LaneTimerTick;
        }

        private void LaneTimerTick(object sender, EventArgs e)
        {
            GetLaneTicketInfo();
        }

        private void GetLaneTicketInfo()
        {
            string sqlCmd = @"SELECT SUM(t.TicketCount) FROM ( select COUNT(*) AS 'TicketCount' from OUT_CheckSmartCard where LaneID = '" + laneID + "' AND TransactionStatus IS NULL UNION ALLSELECT  COUNT(*) AS 'TicketCount' from OUT_CheckForceOpen where LaneID = '" + laneID +"'  AND PreSupervisionStatus = 10) as t";
            string connectionString = "data source= DUY-HA;initial catalog=HPE_CMO;persist security info=True;user id = sa;password=123456;Connection Timeout=10; MultipleActiveResultSets=True;App=EntityFramework";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter dataadapter = new SqlDataAdapter(sqlCmd, connection);
            DataTable dt = new DataTable();
            connection.Open();
            dataadapter.Fill(dt);
            connection.Close();

            int totalTicketTmp = int.Parse(dt.Rows[0][0].ToString());
            if(totalTicketTmp != totalTicket)
            {
                OnOutTicketChange(totalTicketTmp - totalTicket);
                totalTicket = totalTicketTmp;
            }
        }
    }
}
