using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.API.Models
{
    public class Page<T>
    {
        [JsonProperty("count")]
        public string Count { get; set; }

        [JsonProperty("value")]
        public List<T> Value { get; set; }

    }
}
