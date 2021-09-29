using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.API.Models
{
    public class Item
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public float Price { get; set; }

    }
}
