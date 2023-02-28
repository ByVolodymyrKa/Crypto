using Crypto.Commands;
using Crypto.Services;
using Crypto.Model;
using Crypto.ViewModel.Base;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Collections.Generic;
using System.Windows.Navigation;
using System.Diagnostics;
using System.Windows.Input;
using System;

namespace Crypto.ViewModel
{
    public class ApplicationViewModel : BaseViewModel
    {
        private List<Coin> listCoins;

        private Coin selectedCoin;

        private string searchCoinTextField { get; set; }

        public ObservableCollection<Coin> Coins { get; set; }

        public Brush StatusColor
        {
            get => statusColor;
            set
            {
                if (statusColor != value)
                {
                    statusColor = value;
                    OnPropertyChanged("StatusColor");
                }
            }
        }

        public Brush statusColor { set; get; }

        public Coin SelectedCoin
        {
            get { return selectedCoin; }
            set
            {
                selectedCoin = value;
                OnPropertyChanged("SelectedCoin");
            }
        }

        public string SearchCoinTextField
        {
            get => searchCoinTextField; set
            {
                if (searchCoinTextField != value && value != null)
                {
                    searchCoinTextField = value;
                    OnPropertyChanged("SearchCoinTextField");
                }
            }
        }

        public Command GetCoinCommand { get; set; }

        public Command SearchCoinCommand { get; set; }

        public ApplicationViewModel()
        {
            this.Coins = new ObservableCollection<Coin>();

            SearchCoinCommand = new Command(async obj => await SearchCoin());

            GetCoinCommand = new Command(async obj => await GetCoins());
        }

        public async Task GetAllCoins()
        {
            GetJson.GetListOfCoins();
        }

        public async Task GetCoins()
        {
            if (!await GetJson.CheckAPIStatus())
            {
                StatusColor = Brushes.Red;
                await Task.Delay(2000);
            }
            else { StatusColor = Brushes.Green; }

            listCoins = await GetJson.GetTop7();

            if (listCoins != null)
            {
                Coins.Clear();
                listCoins.ForEach(coin => Coins.Add(coin));
            }
        }

        private async Task SearchCoin()
        {
            Coin coin = await GetJson.SearchCoinAsync(searchCoinTextField);
            if (coin != null)
            {
                SelectedCoin = coin;
            }
        }
    }
}
