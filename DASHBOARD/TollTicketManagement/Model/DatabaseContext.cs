using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TollTicketManagement.Model
{
    public class DatabaseContext
    {
        private static QLHPDataContext instance;
        public static QLHPDataContext Instance
        {
            get { if (instance == null) { instance = new QLHPDataContext(); } return instance; }
            private set { instance = value; }
        }
        
    }
}
