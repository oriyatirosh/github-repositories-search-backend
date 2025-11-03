using GithubSearchApi.Services;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace GithubSearchApi.Controllers
{
    [RoutePrefix("api/Repositories")]
    public class RepositoriesController : ApiController
    {
        private readonly IGitHubService _githubService;

        public RepositoriesController(IGitHubService githubService)
        {
            _githubService = githubService;
        }
        [HttpGet, Route("search")]
        public async Task<IHttpActionResult> Search([FromUri] string q)
        {
            if (string.IsNullOrEmpty(q))
                return BadRequest("q is required");

            var results = await _githubService.SearchRepositories(q);
            return Ok(results);
        }
    }
}