using System.Collections.Generic;
using System.Threading.Tasks;
using GithubSearchApi.Models;

namespace GithubSearchApi.Services
{
    public interface IGitHubService
    {
        Task<List<RepositoryModel>> SearchRepositories(string q);
    }
}
