using Crypto.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Media;

namespace Crypto.Services
{
    internal class GetJson
    {
        private static HttpClient httpClient;

        private static readonly string APIUrl = "https://api.coingecko.com/api/v3";

        private static List<CoinObject> listOFCoins;

        public static async Task<List<Coin>> GetTop7()
        {
            string top7Url = $"{APIUrl}/search/trending";

            List<Coin> coins = new();

            var response = await RequestAndGetJson(top7Url);

            List<string> ids = GetCoinIds(response);

            foreach (string coin in ids)
            {
                await Task.Delay(500);
                coins.Add(await GetCoin(coin));
            }
            //coins.Sort();
            return coins;
        }

        public static async void GetListOfCoins()
        {
            string listOfCoinUrl = $"{APIUrl}/coins/list";

            var response = await RequestAndGetJson(listOfCoinUrl);

            listOFCoins = JsonConvert.DeserializeObject<List<CoinObject>>(response);
        }

        public static async Task<Coin> SearchCoinAsync(string coin)
        {
            var item = listOFCoins.Where(x => x.Id.Equals(coin) || x.Name.Equals(coin) || x.Symbol.Equals(coin)).FirstOrDefault();

            return item != null ? await GetCoin(item.Id) : null;
        }

        public static async Task<bool> CheckAPIStatus()
        {
            string checkApiUrl = $"{APIUrl}/ping";

            GetHttpClient();

            var respone = await httpClient.GetAsync(checkApiUrl);

            return respone.IsSuccessStatusCode;
        }

        private static List<string> GetCoinIds(string jsonResponse)
        {
            List<string> listIds = new();

            var jObject = JObject.Parse(jsonResponse);

            var item = jObject["coins"];

            foreach (JToken coin in item)
            {
                listIds.Add((string)coin["item"]["id"]);
            }

            return listIds;
        }

        private static async Task<Coin> GetCoin(string id)
        {
            string getCoinUrl = $"{APIUrl}/coins/{id}?localization=false&tickers=false&community_data=false&developer_data=false&sparkline=false";

            var response = await RequestAndGetJson(getCoinUrl);

            return JsonConvert.DeserializeObject<Coin>(response);
        }

        private static async Task<string> RequestAndGetJson(string urlRequest)
        {
            GetHttpClient();

            string response;

            while (true)
            {
                try
                {
                    response = await httpClient.GetStringAsync(urlRequest);
                    break;
                }
                catch (Exception)
                {
                    await Task.Delay(10000);
                }
            }

            return response;
        }

        private static HttpClient GetHttpClient()
        {
            httpClient ??= new HttpClient();

            return httpClient;
        }

    }
}


