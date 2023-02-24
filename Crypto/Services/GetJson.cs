using Crypto.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace Crypto.Services
{
    internal class GetJson
    {
        private static HttpClient httpClient;
        private static readonly string APIUrl = "https://api.coingecko.com/api/v3";




        public static async Task<List<Coin_>> GetTop7()
        {
            string top7Url = "/search/trending";
            CheckAPIStatus();
            List<Coin_> coins = new List<Coin_>();
            var response = await RequestAndGetJson(APIUrl+top7Url);
            
           List<string> st =  GetCoinIds(response);


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
        //TODO: get id 
        private static List<string> GetCoinIds(string jsonResponse)
        {
            List<string> listIds = new List<string>();
          /*  while (jsonResponse.EndsWith("\"exchanges\""))
            {
                string line = jsonResponse;
                if (line.Contains("\"id\""))
                {
                    string id = line.Split(',')[0].Split(':')[1].Split('\"')[1].Split('\"')[0];
                listIds.Add(id);
                }               
            }*/

            return listIds;
        }

        private static async Task<Coin_> GetCoin(string id)
        {
            string getCoinUrl = $"/coins/{id}";
            CheckAPIStatus();
            GetHttpClient();
            var respone = await httpClient.GetAsync(APIUrl + getCoinUrl);
            return null;
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
