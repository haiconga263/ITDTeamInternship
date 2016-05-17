using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TollTicketManagement.Model
{
    public class CardType
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
    public class CardTypeList : List<CardType>
    {
        public CardTypeList()
        {
            this.Add(new CardType() { ID = 1, Name = "Thẻ PPC" });
            this.Add(new CardType() { ID = 2, Name = "Thẻ Lượt" });
        }
    }
}
