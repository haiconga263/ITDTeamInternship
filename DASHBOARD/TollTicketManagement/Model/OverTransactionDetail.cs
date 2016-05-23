using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TollTicketManagement.Model
{
    public class OverTransactionDetail : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var eventHandler = this.PropertyChanged;
            if (eventHandler != null)
            {
                eventHandler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private string _SmartCardID;
        private string _RecogPlateNumber;
        private string _StationIn;
        private string _LaneIn;
        private string _Shift;
        private string _CheckDate;
        private string _ImageID;
        public string SmartCardID
        {
            set { _SmartCardID = value; OnPropertyChanged("SmartCardID"); }
            get { return _SmartCardID; }
        }
        public string RecogPlateNumber
        {
            set { _RecogPlateNumber = value; OnPropertyChanged("RecogPlateNumber"); }
            get { return _RecogPlateNumber; }
        }
        public string StationIn
        {
            set { _StationIn = value; OnPropertyChanged("StationIn"); }
            get { return _StationIn; }
        }
        public string LaneIn
        {
            set { _LaneIn = value; OnPropertyChanged("LaneIn"); }
            get { return _LaneIn; }
        }
        public string Shift
        {
            set { _Shift = value; OnPropertyChanged("Shift"); }
            get { return _Shift; }
        }
        public string CheckDate
        {
            set { _CheckDate = value; OnPropertyChanged("CheckDate"); }
            get { return _CheckDate; }
        }
        public string ImageID
        {
            set { _ImageID = value; OnPropertyChanged("ImageID"); }
            get { return _ImageID; }
        }
    }
}
