using System;
using System.Collections.Generic;

namespace Entropia_CS_React.Domain.Models
{
    public class CustomItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool Selected { get; set; }
        public int BeginQuantity { get; set; }
        public decimal Markup { get; set; }
        public decimal PurchasePrice { get; set; }
        public int Quantity { get; set; }
        public int Step { get; set; }
        public int AccountId { get; set; }
    }
}
