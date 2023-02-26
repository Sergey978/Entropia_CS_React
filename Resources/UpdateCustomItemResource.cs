using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Entropia_CS_React.Resources
{
    public class UpdateCustomItemResource
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool Selected { get; set; }
        public int BeginQuantity { get; set; }
        public decimal Markup { get; set; }
        public decimal PurchasePrice { get; set; }
        public int Step { get; set; }
    }
}
