using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ModernHttpClient;

namespace ExampleApp
{
    public static class GitHubApi
    {
        public static async Task<List<string>> GetAsync(string user)
        {
            List<string> repositories = new List<string>();
            if (!string.IsNullOrWhiteSpace(user))
            {
                string url = string.Format("https://api.github.com/users/{0}/repos", user);

                using (HttpClient client = new HttpClient(new NativeMessageHandler()))
                {
                    client.DefaultRequestHeaders.Add("User-Agent", "Other");

                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    string content = await response.Content.ReadAsStringAsync();

                    if (!string.IsNullOrWhiteSpace(content))
                    {
                        JArray json = JArray.Parse(content);

                        foreach (var item in json)
                        {
                            string repository = item.Value<string>("full_name");
                            repositories.Add(repository);
                        }
                    }
                }
            }
            return repositories;
        }
    }
}
