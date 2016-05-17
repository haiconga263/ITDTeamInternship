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

        private string cardType;
        public string CardType
        {
            get { return cardType; }
            set { cardType = value; OnPropertyChanged(); }
        }

        private string cardID;
        public string CardID
        {
            get { return cardID; }
            set { cardID = value; OnPropertyChanged(); }
        }

        private LS_VehicleType vehicleType;
        public LS_VehicleType VehicleType
        {
            get { return vehicleType; }
            set { vehicleType = value; OnPropertyChanged(); }
        }

        private string vehiclePlateIn;
        public string VehiclePlateIn
        {
            get { return vehiclePlateIn; }
            set { vehiclePlateIn = value; OnPropertyChanged(); }
        }

        private string vehiclePlateOut;
        public string VehiclePlateOut
        {
            get { return vehiclePlateOut; }
            set { vehiclePlateOut = value; OnPropertyChanged(); }
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

        private string lastCheckDateIn;
        public string LastCheckDateIn
        {
            get { return lastCheckDateIn; }
            set { lastCheckDateIn = value; OnPropertyChanged(); }
        }

        private string lastCheckDateOut;
        public string LastCheckDateOut
        {
            get { return lastCheckDateOut; }
            set { lastCheckDateOut = value; OnPropertyChanged(); }
        }

        private LS_Route route;
        public LS_Route Route
        {
            get { return route; }
            set { route = value; OnPropertyChanged(); }
        }

        private string isLock;

        public string IsLock
        {
            get { return isLock; }
            set { isLock = value; OnPropertyChanged(); }
        }

        private LS_Employee lockEmployee;
        public LS_Employee LockEmployee
        {
            get { return lockEmployee; }
            set { lockEmployee = value; OnPropertyChanged(); }
        }

        private LS_Employee unlockEmployee;
        public LS_Employee UnlockEmployee
        {
            get { return unlockEmployee; }
            set { unlockEmployee = value; OnPropertyChanged(); }
        }

        private string lockDate;
        public string LockDate
        {
            get { return lockDate; }
            set { lockDate = value; OnPropertyChanged(); }
        }

        private string unlockDate;
        public string UnlockDate
        {
            get { return unlockDate; }
            set { unlockDate = value; OnPropertyChanged(); }
        }

        private string isLost;
        public string IsLost
        {
            get { return isLost; }
            set { isLost = value; OnPropertyChanged(); }
        }

        private string note;
        public string Note
        {
            get { return note; }
            set { note = value; OnPropertyChanged(); }
        }

        private string imageIn;
        public string ImageIn
        {
            get { return imageIn; }
            set { imageIn = value; OnPropertyChanged(); }
        }

        private string imageOut;

        public string ImageOut
        {
            get { return imageOut; }
            set { imageOut = value; }
        }
        
        

        public static WhiteList CreateFromPPCWhiteList(AC_PPCWhiteList x)
        {
            
            WhiteList wl = new WhiteList()
            {
                CardType = "Thẻ PPC",
                CardID = x.CardID,
                VehiclePlateIn = x.VehiclePlateIn,
                VehiclePlateOut = x.VehiclePlateOut,
                VehicleType = x.LS_VehicleType,
                LaneIn = x.LS_Lane,
                LaneOut = x.LS_Lane1,
                LastCheckDateIn = x.LastCheckDateIn.ToString(),
                LastCheckDateOut = x.LastCheckDateOut.ToString(),
                Route = x.LS_Route,
                StationIn = x.LS_Station,
                StationOut = x.LS_Station1,
                LockEmployee = x.LS_Employee,
                UnlockEmployee = x.LS_Employee1,
                LockDate = x.LockDate.ToString(),
                UnlockDate = x.UnlockDate.ToString(),
                IsLock = x.IsLost.ToString(),
                IsLost = x.IsLost.ToString(),
                Note = x.Note,
                ImageIn = x.ImageIDIn,
                ImageOut = x.ImageIDOut,
            };
            return wl;
        }
        public static WhiteList CreateFromTollWhiteList(AC_TollWhiteList x)
        {
            WhiteList wl = new WhiteList()
            {
                CardType = "Thẻ lượt",
                CardID = x.CardID,
                VehiclePlateIn = x.VehiclePlateIn,
                VehiclePlateOut = x.VehiclePlateOut,
                VehicleType = x.LS_VehicleType,
                LaneIn = x.LS_Lane,
                LaneOut = x.LS_Lane1,
                LastCheckDateIn = x.LastCheckDateIn.ToString(),
                LastCheckDateOut = x.LastCheckDateOut.ToString(),
                Route = x.LS_Route,
                StationIn = x.LS_Station,
                StationOut = x.LS_Station1,
                LockEmployee = x.LS_Employee,
                UnlockEmployee = x.LS_Employee1,
                LockDate = x.LockDate.ToString(),
                UnlockDate = x.UnlockDate.ToString(),
                IsLock = x.IsLost.ToString(),
                IsLost = x.IsLost.ToString(),
                Note = x.Note,
                ImageIn = x.ImageIDIn,
                ImageOut = x.ImageIDOut,
            };
            return wl;
        }
    }
}
