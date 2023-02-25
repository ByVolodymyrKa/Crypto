using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto.Entity
{
    internal class Coin_ : BaseEntity
    {
        public int symbol { get; set; }
        public string name { get; set; }

        public int price { get; set; }

        public int priceChange { get; set; }

        public int priceChangePercentage { get; set; }

        public int vilume { get; set; }

        public string url { get; set; }

        public string urlImage { get; set; }
    }
}
