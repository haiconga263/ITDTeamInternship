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

namespace TollTicketManagement.ViewModel
{
    public class TransDetailsViewModel : INotifyPropertyChanged
    {
        private WhiteList whiteList;

        public WhiteList WhiteList
        {
            get { return whiteList; }
            set { whiteList = value; OnPropertyChanged(); }
        }
        
        public TransDetailsViewModel(WhiteList wl)
        {
            whiteList = wl;
        }

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
    }
}
