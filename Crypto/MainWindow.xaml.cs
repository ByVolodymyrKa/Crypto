using Crypto.Entity;
using Crypto.Services;
using System.Collections.Generic;
using System.Windows;

namespace Crypto
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //Status.Fill = GetJson.CheckAPIStatus();

            Top7Coins24();

        }

        private List<Coin_> Top7Coins24()
        {
            List<Coin_> coins = new List<Coin_>();



            return coins;
        }


    }
}
