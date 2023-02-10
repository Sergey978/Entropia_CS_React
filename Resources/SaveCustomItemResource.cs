using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Entropia_CS_React.Resources
{
    //resource which recive from client
    public class SaveCustomItemResource
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}
