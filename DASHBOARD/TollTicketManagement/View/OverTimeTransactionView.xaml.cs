using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public delegate bool Filter(OverTimeSmartCard w);
    /// <summary>
    /// Interaction logic for OverTimeTransactionView.xaml
    /// </summary>
    public partial class OverTimeTransactionView : Window
    {
        public ObservableCollection<LS_Station> lstStation { get; set; }
        private ObservableCollection<OverTimeSmartCard> dataResults;
        public ObservableCollection<OverTimeSmartCard> DataResults
        {
            get { return dataResults; }
            set { dataResults = value; }
        }
        public string[] lShiftID { set; get; }
        private bool IsSearchTime = true;
        
        public OverTimeTransactionView()
        {
            InitializeComponent();
            Init();
        }
        private void Init()
        {
            lstStation = new ObservableCollection<LS_Station>(DatabaseContext.Instance.LS_Stations.ToList());
            DataResults = new ObservableCollection<OverTimeSmartCard>();
            InitcbShilftNgayCa();
            InitcbStation();
            InitTime();
            radioTime.IsChecked = true;
            radioDateShift.IsChecked = false;
            gbDateShift.IsEnabled = false;
        }
        private void InitcbShilftNgayCa()
        {
            lShiftID = new string[4];
            lShiftID[0] = "Tất cả";
            lShiftID[1] = "1";
            lShiftID[2] = "2";
            lShiftID[3] = "3";
            cbShiftNgayCa.ItemsSource = lShiftID;
            cbShiftNgayCa.SelectedIndex = 0;
        }
        private void InitcbStation()
        {
            for (int i = 0; i < lstStation.Count; i++)
            {
                cbStation.Items.Add(lstStation[i].Name);
            }
            if (lstStation.Count > 0) cbStation.SelectedIndex = 0;
        }
        private void InitTime()
        {
            DTToDate.SelectedDate = DateTime.Now;
            DTFromDate.SelectedDate = DateTime.Now.AddDays(-1.0);
            UpDownFromTime.Value = DateTime.Now.AddDays(-1.0);
            UpDownToTime.Value = DateTime.Now;
            DTNgayCa.SelectedDate = DateTime.Now;
            UpdownTimeOut.Value = 24;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {

            int count = 0;
            int StationID = 0;
            int Timeout = 0;
            if (UpdownTimeOut.IsEnabled && (int)UpdownTimeOut.Value > 0)
            {
                Timeout = (int)UpdownTimeOut.Value;
            }
            foreach (LS_Station item in lstStation)
            {
                if(cbStation.Text.Equals(item.Name))
                {
                    StationID = item.StationID;
                    break;
                }
            }
            if (IsSearchTime)
            {
                count = OverTimeSmartCard.getCountListOverTimeSmartCardbyTime(
                    DTFromDate.SelectedDate.Value.AddHours(UpDownFromTime.Value.Value.Hour).AddMinutes(UpDownFromTime.Value.Value.Minute).AddSeconds(UpDownFromTime.Value.Value.Second),
                    DTToDate.SelectedDate.Value.AddHours(UpDownToTime.Value.Value.Hour).AddMinutes(UpDownToTime.Value.Value.Minute).AddSeconds(UpDownToTime.Value.Value.Second),
                    Timeout,
                    StationID,
                    getCondition());
            }
            else
            {
                count = OverTimeSmartCard.getCountListOverTimeSmartCardbyDateShift(
                    DTNgayCa.SelectedDate.Value,
                    cbShiftNgayCa.SelectedIndex,
                    Timeout,
                    StationID,
                    getCondition());
            }
            lbitemnumber.Text = "/ " + count;
            int Pagenumber = (count / 20 + ((count % 20 == 0) ? 0 : 1));
            lbPagenumber.Text = "/ " + Pagenumber;
            if(count > 0)
            {
                cbPageIndex.Items.Clear();
                tbitemIndex.Text = 1.ToString();
                for (int i = 1; i < Pagenumber + 1; i++)
                {
                    cbPageIndex.Items.Add(i);
                }
                cbPageIndex.SelectedIndex = 0;
            }
            updateView(0);
        }
        private string getCondition()
        {
            string tmp = string.Empty;
            if(!string.IsNullOrEmpty(tbSmartCardID.Text) && !string.IsNullOrWhiteSpace(tbSmartCardID.Text) && tbSmartCardID.Text.Length <= 14)
            {
                string SmartCardID = tbSmartCardID.Text.ToUpper();
                tmp += "and (SmartCardID like ''%" + SmartCardID + "'' or SmartCardID like ''" + SmartCardID + "%'' or SmartCardID like ''%" + SmartCardID + "%'') ";
                SmartCardID = null;
            }
            if(!string.IsNullOrEmpty(tbVehclePlate.Text)&& !string.IsNullOrWhiteSpace(tbVehclePlate.Text) && tbVehclePlate.Text.Length < 11 )
            {
                string VehclePlate = tbVehclePlate.Text.ToUpper();
                tmp += "and (RecogPlateNumber like ''%" + VehclePlate + "'' or RecogPlateNumber like ''" + VehclePlate + "%'' or RecogPlateNumber like ''%" + VehclePlate + "%'') ";
                VehclePlate = null;
            }
            return tmp;
        }
        private void updateView(int pageindex)
        {
            cbPageIndex.SelectedIndex = pageindex;
            string condition = string.Empty;
            condition += "STT >=" + pageindex * 20 + " and STT <= " + (pageindex + 1) * 20;
            List<OverTimeSmartCard> lstOverTimeSmartCards = OverTimeSmartCard.getListOverTimeSmartCardbyCondition(condition);
            DataResults.Clear();
            DataResults = new ObservableCollection<OverTimeSmartCard>(lstOverTimeSmartCards);
            View.ItemsSource = dataResults;
        }
        private void OverTimeTransactionView_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            tabinfo.Width = SystemParameters.MaximizedPrimaryScreenWidth - 35;
        }

        private void btnfirst_Click(object sender, RoutedEventArgs e)
        {
            updateView(0);
        }

        private void btnprev_Click(object sender, RoutedEventArgs e)
        {
            if (cbPageIndex.SelectedIndex > 0)
                updateView(cbPageIndex.SelectedIndex - 1);
        }

        private void btnnext_Click(object sender, RoutedEventArgs e)
        {
            if (cbPageIndex.SelectedIndex < cbPageIndex.Items.Count)
                updateView(cbPageIndex.SelectedIndex + 1);
        }

        private void btnlast_Click(object sender, RoutedEventArgs e)
        {
            updateView(cbPageIndex.Items.Count - 1);
        }

        private void cbPageIndex_Selected(object sender, RoutedEventArgs e)
        {
            updateView(cbPageIndex.SelectedIndex);
        }

        private void radioTime_Checked(object sender, RoutedEventArgs e)
        {
            radioDateShift.IsChecked = false;
            IsSearchTime = true;
            gbDateShift.IsEnabled = false;
            gbTime.IsEnabled = true;
        }

        private void radionDateShift_Checked(object sender, RoutedEventArgs e)
        {
            radioTime.IsChecked = false;
            IsSearchTime = false;
            gbDateShift.IsEnabled = true;
            gbTime.IsEnabled = false;
        }


        private void View_Selected(object sender, SelectedCellsChangedEventArgs e)
        {
            tbitemIndex.Text = (View.SelectedIndex + (int)cbPageIndex.SelectedItem * 20).ToString();
        }
    }
}
