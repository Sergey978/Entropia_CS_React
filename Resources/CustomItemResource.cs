using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entropia_CS_React.Resources
{
    public class CustomItemResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool Selected { get; set; }
        public int BeginQuantity { get; set; }
        public decimal Markup { get; set; }
        public decimal PurchasePrice { get; set; }
        public int Step { get; set; }
    }
}
