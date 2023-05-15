using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entropia_CS_React.Resources
{
    public class SelectUserStandartItemResource
    {
        public int? Id { get; set; }
        public int StandartItemId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool? Selected { get; set; }
    }
}
