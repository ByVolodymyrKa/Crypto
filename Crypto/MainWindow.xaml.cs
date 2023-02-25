using Crypto.Entity;
using Crypto.Services;
using System;
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

            

        }
            

        private  List<Coin_> Top7Coins24()
        {
           
            List<Coin_> coins = new List<Coin_>();



            return coins;
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Status.Fill = await GetJson.CheckAPIStatus();
            await GetJson.GetTop7();
        }

    }
}
