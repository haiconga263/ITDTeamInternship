using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TollTicketManagement.CommandHelper;
using TollTicketManagement.Model;
using TollTicketManagement.View;

namespace TollTicketManagement.ViewModel
{
    public delegate bool Filter(WhiteList w);

    public class LookupViewModel : INotifyPropertyChanged
    {
        public LookupViewModel()
        {
            SearchCommand = new RelayCommand(ActionSearch);
            DataResults = new ObservableCollection<WhiteList>();
            lstVeh = new ObservableCollection<LS_VehicleType>(DatabaseContext.Instance.LS_VehicleTypes.Select(x => x).ToList());
            lstStation = new ObservableCollection<LS_Station>(DatabaseContext.Instance.LS_Stations.Select(x => x).ToList());
            lstCardType = new ObservableCollection<CardType>(new CardTypeList());

            lstVeh.Insert(0, new LS_VehicleType() { ShortName = "-Tất cả-", VehicleTypeID = 0 });
            SelectedItemVehicleType = lstVeh[0];

            lstStation.Insert(0, new LS_Station() { Name = "-Tất cả-", LS_Lanes = null });
            SelectedItemStationIn = lstStation[0];
            SelectedItemStationOut = lstStation[0];

            lstCardType.Insert(0, new CardType() { Name = "-Tất cả-", ID = 0 });
            SelectedItemCardType = lstCardType[0];

            SelectedItemLaneIn = new LS_Lane() { Name = "-Tất cả-", LaneID = 0 };
        }

        #region search tool 
        private List<Filter> filters;
        private bool IsFilter(WhiteList w)
        {
            foreach(Filter item in filters)
            {
                try
                {
                    if (!item(w)) return false;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return true;
        }

        #region Filter
        private bool MaTheFilter(WhiteList w)
        {
            return (w.CardID == keyBienSo);
        }
        private bool BienSoFilter(WhiteList w)
        {
            return (w.VehiclePlateIn == keyBienSo) || (w.VehiclePlateOut == keyBienSo);
        }
        private bool VehicleTypeFilter(WhiteList w)
        {
            return (w.VehicleType.VehicleTypeID == selectedItemVehicleType.VehicleTypeID);
        }
        private bool StationInFilter(WhiteList w)
        {
            return (w.StationIn.StationID == selectedItemStationIn.StationID);
        }
        private bool StationOutFilter(WhiteList w)
        {
            return (w.StationOut.StationID == selectedItemStationOut.StationID);
        }
        private bool LaneInFilter(WhiteList w)
        {
            return (w.LaneIn.LaneID == selectedItemLaneIn.LaneID);
        }
        private bool LaneOutFilter(WhiteList w)
        {
            return (w.LaneOut.LaneID == selectedItemLaneOut.LaneID);
        }
        private bool DateInFilter(WhiteList w)
        {
            return DateTime.Parse(w.LastCheckDateIn).Date == DateTime.Parse(keyTimeIn).Date;
        }
        private bool DateOutFilter(WhiteList w)
        {
            return DateTime.Parse(w.LastCheckDateOut).Date == DateTime.Parse(keyTimeOut).Date;
        }
        private bool TimeInFilter(WhiteList w)
        {
            return DateTime.Parse(w.LastCheckDateIn).TimeOfDay == DateTime.Parse(keyTimeIn).TimeOfDay;
        }
        private bool TimeOutFilter(WhiteList w)
        {
            return DateTime.Parse(w.LastCheckDateOut).TimeOfDay == DateTime.Parse(keyTimeOut).TimeOfDay;
        }
        #endregion
        private void ActionSearch()
        {
            List<WhiteList> lst = new List<WhiteList>();
            List<AC_PPCWhiteList> lstPCC = DatabaseContext.Instance.AC_PPCWhiteLists.Select(x => x).ToList();
            List<AC_TollWhiteList> lstToll = DatabaseContext.Instance.AC_TollWhiteLists.Select(x => x).ToList();

            filters = new List<Filter>();

            // Search by Ma the
            if (!string.IsNullOrEmpty(keyMaThe) && string.IsNullOrWhiteSpace(keyMaThe))
            {
                filters.Add(MaTheFilter);
            }

            // Search by num car
            if (!string.IsNullOrWhiteSpace(keyBienSo) && !string.IsNullOrEmpty(keyBienSo))
            {
                filters.Add(BienSoFilter);
            }

            // Search by Vehicle type
            if (selectedItemVehicleType != null && (selectedItemVehicleType.VehicleTypeID != 0 
                ||(!string.IsNullOrEmpty(selectedItemVehicleType.Name) && !string.IsNullOrWhiteSpace(selectedItemVehicleType.Name))))
            {
                filters.Add(VehicleTypeFilter);
            }

            // Search by StationIn
            if (selectedItemStationIn != null && selectedItemStationIn.StationID != 0)
            {
                filters.Add(StationInFilter);

                // Search by LaneIn
                if (SelectedItemLaneIn != null && selectedItemLaneIn.LaneID != 0)
                {
                    filters.Add(LaneInFilter);
                }
            }

            // Search by StationOut
            if (selectedItemStationOut != null && selectedItemStationOut.StationID != 0)
            {
                filters.Add(StationOutFilter);

                // Search by LaneOut
                if (SelectedItemLaneOut != null && selectedItemLaneOut.LaneID != 0)
                {
                    filters.Add(LaneOutFilter);
                }
            }

            // Search by datetime In
            if (!string.IsNullOrEmpty(keyDateIn) && !string.IsNullOrWhiteSpace(keyDateIn))
            {
                filters.Add(DateInFilter);

                // Search by LaneOut
                if (!string.IsNullOrEmpty(keyTimeIn) && !string.IsNullOrWhiteSpace(keyTimeIn))
                {
                    filters.Add(TimeInFilter);
                }
            }

            // Search by datetime Out
            if (!string.IsNullOrEmpty(keyDateOut) && !string.IsNullOrWhiteSpace(keyDateOut))
            {
                filters.Add(DateOutFilter);

                // Search by LaneOut
                if (!string.IsNullOrEmpty(keyTimeOut) && !string.IsNullOrWhiteSpace(keyTimeOut))
                {
                    filters.Add(TimeOutFilter);
                }
            }

            if (selectedItemCardType.ID == 0 || selectedItemCardType.ID == 1)
                lst = lst.Concat(new List<WhiteList>(lstPCC.Where(x => IsFilter(WhiteList.CreateFromPPCWhiteList(x))).Select(x => WhiteList.CreateFromPPCWhiteList(x)))).ToList();
            if (selectedItemCardType.ID == 0 || selectedItemCardType.ID == 2)
                lst = lst.Concat(new List<WhiteList>(lstToll.Where(x => IsFilter(WhiteList.CreateFromTollWhiteList(x))).Select(x => WhiteList.CreateFromTollWhiteList(x)))).ToList();

            DataResults.Clear();
            DataResults = new ObservableCollection<WhiteList>(lst);
        }
        #endregion

        #region Notify property changed
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var eventHandler = this.PropertyChanged;
            if (eventHandler != null)
            {
                eventHandler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        public ObservableCollection<LS_VehicleType> lstVeh { get; set; }
        public ObservableCollection<LS_Station> lstStation { get; set; }
        public ObservableCollection<CardType> lstCardType { get; set; }

        private LS_Lane selectedItemLaneIn;
        public LS_Lane SelectedItemLaneIn
        {
            get { return selectedItemLaneIn; }
            set { selectedItemLaneIn = value; OnPropertyChanged(); }
        }

        private LS_Lane selectedItemLaneOut;
        public LS_Lane SelectedItemLaneOut
        {
            get { return selectedItemLaneOut; }
            set { selectedItemLaneOut = value; OnPropertyChanged(); }
        }

        private LS_Station selectedItemStationIn;
        public LS_Station SelectedItemStationIn
        {
            get { return selectedItemStationIn; }
            set { selectedItemStationIn = value; }
        }

        private LS_Station selectedItemStationOut;
        public LS_Station SelectedItemStationOut
        {
            get { return selectedItemStationOut; }
            set { selectedItemStationOut = value; }
        }

        private LS_VehicleType selectedItemVehicleType;
        public LS_VehicleType SelectedItemVehicleType
        {
            get { return selectedItemVehicleType; }
            set { selectedItemVehicleType = value; }
        }

        private CardType selectedItemCardType;
        public CardType SelectedItemCardType
        {
            get { return selectedItemCardType; }
            set { selectedItemCardType = value; }
        }

        private ObservableCollection<WhiteList> dataResults;
        public ObservableCollection<WhiteList> DataResults
        {
            get { return dataResults; }
            set { dataResults = value; OnPropertyChanged(); }
        }
        
        private string keyMaThe;
        public string KeyMaThe
        {
            get { return keyMaThe; }
            set { keyMaThe = value; OnPropertyChanged(); }
        }

        private string keyBienSo;
        public string KeyBienSo
        {
            get { return keyBienSo; }
            set { keyBienSo = value; }
        }

        private string keyDateIn;
        public string KeyDateIn
        {
            get { return keyDateIn; }
            set { keyDateIn = value; }
        }

        private string keyDateOut;
        public string KeyDateOut
        {
            get { return keyDateOut; }
            set { keyDateOut = value; }
        }

        private string keyTimeIn;
        public string KeyTimeIn
        {
            get { return keyTimeIn; }
            set { keyTimeIn = value; }
        }

        private string keyTimeOut;
        public string KeyTimeOut
        {
            get { return keyTimeOut; }
            set { keyTimeOut = value; }
        }

        private int selectedIndexDataGrid;

        public int SelectedIndexDataGrid
        {
            get { return selectedIndexDataGrid; }
            set 
            { 
                selectedIndexDataGrid = value; 
                OnPropertyChanged();
                if (value > -1)
                {
                    var wdn = new TransDetailsView(dataResults[value]);
                    wdn.ShowDialog();
                }
            }
        }
        
        public ICommand SearchCommand { get; set; }
        
    }
}
