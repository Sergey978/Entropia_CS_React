using System;
using System.Collections.Generic;

namespace Entropia_CS_React.Domain.Models
{
    public class CustomItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool Selected { get; set; } = true;
        public int BeginQuantity { get; set; } = 1;
        public decimal Markup { get; set; } = 1;
        public decimal PurchasePrice { get; set; } = 100;
        public int Quantity { get; set; } = 100;
        public int Step { get; set; } = 1;
        public int AccountId { get; set; }
    }
}
