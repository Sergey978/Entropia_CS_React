using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entropia_CS_React.Entities
{
    public class UserStandartItem
    {
        public int Id {get; set;}
        public int  UserId {get; set;}
        public int StandartItemId {get; set;}
        public bool Selected { get; set; }
        public int BeginQuantity { get; set; }
        public decimal Markup { get; set; }
        public decimal PurchasePrice { get; set; }
        public int Step { get; set; }
    }
}