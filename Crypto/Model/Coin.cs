using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using static System.Net.WebRequestMethods;

namespace Crypto.Model
{
    public class Coin : BaseModel, INotifyPropertyChanged, IComparable<Coin>
    {
        private readonly string urlForCoin = "https://www.coingecko.com/en/coins/";

        private string url;

        private string symbol;

        private string name;

        public double Price { get => this.market_data.current_price.usd; }

        public double PriceChange { get => this.market_data.price_change_24h; }

        public double PriceChangePercentage { get => Math.Round(this.market_data.price_change_percentage_24h, 2); }

        public long Volume { get => this.market_data.total_volume.usd; }

        public double High24 { get => this.market_data.high_24h.usd; }

        public double Low24 { get => this.market_data.low_24h.usd; }

        public string UrlImage { get => this.image.large; }

        public MarketData market_data { get; set; }

        public Image image { get; set; }

        public string Url
        {
            get { return urlForCoin + this.Id; }
            set
            {
                url = value;
                OnPropertyChanged("Url");
            }
        }

        public string Symbol
        {
            get { return symbol; }
            set
            {
                symbol = value;
                OnPropertyChanged("Symbol");
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public class MarketData
        {
            public CurrentPrice current_price { get; set; }

            public TotalVolume total_volume { get; set; }

            public High24H high_24h { get; set; }

            public Low24H low_24h { get; set; }

            public double price_change_24h { get; set; }

            public double price_change_percentage_24h { get; set; }
        }
        public class High24H
        {
            public double usd { get; set; }
        }

        public class Low24H
        {
            public double usd { get; set; }
        }

        public class TotalVolume
        {
            public long usd { get; set; }
        }

        public class Image
        {
            public string thumb { get; set; }
            public string small { get; set; }
            public string large { get; set; }
        }

        public class CurrentPrice
        {
            public double usd { get; set; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public int CompareTo(Coin? coin)
        {
            if (coin is null) throw new ArgumentException("Error");
            return (int)coin.PriceChangePercentage - (int)PriceChangePercentage;

        }
    }
}
