namespace TollTicketManagement.Model
{
    public class DatabaseConfigModel
    {
        #region Properties
        public int ActiveServer { get; set; }
        public string Server1 { get; set; }
        public string Server2 { get; set; }

        public string Database1 { get; set; }
        public string Database2 { get; set; }

        public string Username1 { get; set; }
        public string Username2 { get; set; }

        public string Password1 { get; set; }
        public string Password2 { get; set; }

        public string Timeout1 { get; set; }
        public string Timeout2 { get; set; }
        #endregion Properties
    }
}
