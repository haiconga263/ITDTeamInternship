using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TollTicketManagement.Model
{
    public class WhiteList : INotifyPropertyChanged
    {
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
        private string typeCard;

        public string TypeCard
        {
            get { return typeCard; }
            set { typeCard = value; OnPropertyChanged(); }
        }

        private LS_VehicleType vehicleType;

        public LS_VehicleType VehicleType
        {
            get { return vehicleType; }
            set { vehicleType = value; OnPropertyChanged(); }
        }
        private LS_Station stationIn;

        public LS_Station StationIn
        {
            get { return stationIn; }
            set { stationIn = value; OnPropertyChanged(); }
        }

        private LS_Station stationOut;

        public LS_Station StationOut
        {
            get { return stationOut; }
            set { stationOut = value; OnPropertyChanged(); }
        }

        private LS_Lane laneIn;

        public LS_Lane LaneIn
        {
            get { return laneIn; }
            set { laneIn = value; OnPropertyChanged(); }
        }

        private LS_Lane laneOut;

        public LS_Lane LaneOut
        {
            get { return laneOut; }
            set { laneOut = value; OnPropertyChanged(); }
        }
        private string lastCheckIn;

        public string LastCheckIn
        {
            get { return lastCheckIn; }
            set { lastCheckIn = value; OnPropertyChanged(); }
        }
        private string lastCheckOut;

        public string LastCheckOut
        {
            get { return lastCheckOut; }
            set { lastCheckOut = value; OnPropertyChanged(); }
        }
        private LS_Route route;

        public LS_Route Route
        {
            get { return route; }
            set { route = value; OnPropertyChanged(); }
        }

        private string vehiclePlateIn;

        public string VehiclePlateIn
        {
            get { return vehiclePlateIn; }
            set { vehiclePlateIn = value; }
        }

        private string vehiclePlateOut;

        public string VehiclePlateOut
        {
            get { return vehiclePlateOut; }
            set { vehiclePlateOut = value; }
        }

        private string cardID;

        public string CardID
        {
            get { return cardID; }
            set { cardID = value; }
        }

        
        
        public static WhiteList CreateFromPPCWhiteList(AC_PPCWhiteList x)
        {
            WhiteList wl = new WhiteList()
            {
                TypeCard = "Thẻ PPC",
                CardID = x.CardID,
                VehiclePlateIn = x.VehiclePlateIn,
                VehiclePlateOut = x.VehiclePlateOut,
                VehicleType = x.LS_VehicleType,
                LaneIn = x.LS_Lane,
                LaneOut = x.LS_Lane1,
                LastCheckIn = x.LastCheckDateIn.ToString(),
                LastCheckOut = x.LastCheckDateOut.ToString(),
                Route = x.LS_Route,
                StationIn = x.LS_Station,
                StationOut = x.LS_Station1
            };
            return wl;
        }
        public static WhiteList CreateFromTollWhiteList(AC_TollWhiteList x)
        {
            WhiteList wl = new WhiteList()
            {
                TypeCard = "Thẻ lượt",
                CardID = x.CardID,
                VehiclePlateIn = x.VehiclePlateIn,
                VehiclePlateOut = x.VehiclePlateOut,
                VehicleType = x.LS_VehicleType,
                LaneIn = x.LS_Lane,
                LaneOut = x.LS_Lane1,
                LastCheckIn = x.LastCheckDateIn.ToString(),
                LastCheckOut = x.LastCheckDateOut.ToString(),
                Route = x.LS_Route,
                StationIn = x.LS_Station,
                StationOut = x.LS_Station1
            };
            return wl;
        }
    }
}
