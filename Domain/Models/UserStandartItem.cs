using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entropia_CS_React.Domain.Models
{
    public class UserStandartItem
    {
        public int Id { get; set; }
        public int StandartItemId { get; set; }
        public StandartItem StandartItem { get; set; }
        public bool Selected { get; set; }
        public int BeginQuantity { get; set; }
        public int Quantity { get; set; }
        public decimal Markup { get; set; }
        public decimal PurchasePrice { get; set; }
        public int Step { get; set; }
        public int AccountId { get; set; }
    }
}
