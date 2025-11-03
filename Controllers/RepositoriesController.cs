using GithubSearchApi.Services;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace GithubSearchApi.Controllers
{
    [RoutePrefix("api/Repositories")]
    public class RepositoriesController : ApiController
    {
        private readonly GitHubService _gitHubService = new GitHubService();

        [HttpGet, Route("search")]
        public async Task<IHttpActionResult> Search([FromUri] string q)
        {
            if (string.IsNullOrEmpty(q))
                return BadRequest("q is required");

            var results = await _gitHubService.SearchRepositories(q);
            return Ok(results);
        }
    }
}