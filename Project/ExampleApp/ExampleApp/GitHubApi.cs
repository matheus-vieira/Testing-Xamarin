using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ExampleApp
{
    public static class GitHubApi
    {
        public static async Task<List<string>> GetAsync(string user)
        {
            string url = string.Format("https://api.github.com/users/{0}/repos", user);

            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "Other");

            var response = await client.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            var json = JArray.Parse(content);

            var repositories = new List<string>();
            foreach (var item in json)
            {
                var repository = item.Value<string>("full_name");
                repositories.Add(repository);
            }
            return repositories;
        }
    }
}
