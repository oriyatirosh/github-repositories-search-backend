using GithubSearchApi.Models;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace GithubSearchApi.Services
{
    public class GitHubService
    {
        private static readonly HttpClient _http = new HttpClient();

        public async Task<List<RepositoryModel>> SearchRepositories(string q)
        {
            var url = $"https://api.github.com/search/repositories?q={System.Net.WebUtility.UrlEncode(q)}";
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("User-Agent", "MyAspNetApp"); // GitHub requires User-Agent

            var resp = await _http.SendAsync(request);
            resp.EnsureSuccessStatusCode();

            var json = await resp.Content.ReadAsStringAsync();
            var j = JObject.Parse(json);
            var items = j["items"];

            var list = new List<RepositoryModel>();
            foreach (var item in items)
            {
                var repo = new RepositoryModel
                {
                    Name = (string)item["name"],
                    FullName = (string)item["full_name"],
                    HtmlUrl = (string)item["html_url"],
                    Description = (string)item["description"],
                    Owner = new Owner
                    {
                        Login = (string)item["owner"]?["login"],
                        AvatarUrl = (string)item["owner"]?["avatar_url"]
                    }
                };
                list.Add(repo);
            }
            return list;
        }
    }
}