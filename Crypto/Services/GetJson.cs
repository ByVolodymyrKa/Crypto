using Crypto.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Crypto.Services
{
    internal class GetJson
    {
        private static HttpClient httpClient;
        private static readonly string APIUrl = "https://api.coingecko.com/api/v3";




        public static async Task<List<Coin_>> GetTop7()
        {
            string top7Url = "/search/trending";
            var respone = await RequestAndGetJson(APIUrl+top7Url);
            List<Coin_> coins= new List<Coin_>();


            return coins;
        }

        public static async Task<Brush> CheckAPIStatus()
        {
        OneMore:
            string checkApiUrl = "/ping";
            GetHttpClient();
            var respone = await httpClient.GetAsync(APIUrl + checkApiUrl);
            if (respone.IsSuccessStatusCode)
            {
                return Brushes.Green;
            }
            else
            {
                Task.Delay(3000).Wait();
                goto OneMore;
            }
        }

        private static async Task<string> RequestAndGetJson(string urlRequest)
        {
            GetHttpClient();
            string response = await httpClient.GetStringAsync(urlRequest);
            Console.WriteLine(response);
            return response;
        }

        private static HttpClient GetHttpClient()
        {
            if (httpClient == null)
            {
                httpClient = new HttpClient();
            }
            return httpClient;
        }

    }

}
