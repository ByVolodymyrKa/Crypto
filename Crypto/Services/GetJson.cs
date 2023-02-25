using Crypto.Entity;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
            string top7Url = $"{APIUrl}/search/trending";
            CheckAPIStatus();
            List<Coin_> coins = new List<Coin_>();
            var response = await RequestAndGetJson(top7Url);

            List<string> st = GetCoinIds(response);


            return coins;
        }

        public static async Task<Brush> CheckAPIStatus()
        {

        TryItAgain:

            string checkApiUrl = $"{APIUrl}/ping";
            GetHttpClient();
            var respone = await httpClient.GetAsync(checkApiUrl);
            if (respone.IsSuccessStatusCode)
            {
                return Brushes.Green;
            }
            else
            {
                Task.Delay(3000).Wait();
                goto TryItAgain;
            }
        }
        //TODO: get id 
        private static List<string> GetCoinIds(string jsonResponse)
        {
            List<string> listIds = new List<string>();

            var jToken = JToken.Parse(jsonResponse);

            var item = jToken["coins"];

            List<BaseEntity> baseEntities = new List<BaseEntity>();
            baseEntities = JsonConvert.DeserializeObject<List<BaseEntity>>(item.ToString());
      
            return listIds;
        }

        private static async Task<BaseEntity> GetCoin(string id)
        {
            string getCoinUrl = $"{APIUrl}/coins/{id}?localization=false&tickers=false&market_data=true&community_data=false&developer_data=false&sparkline=false";
            CheckAPIStatus();
            GetHttpClient();
            var response = RequestAndGetJson(getCoinUrl);
            return JsonConvert.DeserializeObject<BaseEntity>(await response);
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
