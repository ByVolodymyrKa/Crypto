using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto.Model
{
    public class BaseModel
    {
        [JsonProperty("id")]
        public string? Id { get; set; }
        [JsonProperty("item")]
        public object Item { get; set; }
    }
}
