using GithubSearchApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace GithubSearchApi.Controllers
{

    [RoutePrefix("api/Bookmarks")]
    public class BookmarksController : ApiController
    {
        private const string SESSION_KEY = "Bookmarks";

        private List<RepositoryModel> GetSessionList()
        {
            var session = HttpContext.Current.Session;
            if (session[SESSION_KEY] == null)
            {
                session[SESSION_KEY] = new List<RepositoryModel>();
            }
            return session[SESSION_KEY] as List<RepositoryModel>;
        }

        [HttpGet, Route("")]
        public IHttpActionResult Get()
        {
            var list = GetSessionList();
            return Ok(list);
        }

        [HttpPost, Route("")]
        public IHttpActionResult Add([FromBody] RepositoryModel repo)
        {
            if (repo == null || string.IsNullOrEmpty(repo.FullName))
                return BadRequest("Invalid repository");

            var list = GetSessionList();
            if (!list.Any(r => r.FullName == repo.FullName))
            {
                list.Add(repo);
            }
            return Ok();
        }

        [HttpDelete, Route("{fullName}")]
        public IHttpActionResult Remove(string fullName)
        {
            if (string.IsNullOrEmpty(fullName))
                return BadRequest("fullName required");

            var list = GetSessionList();
            var existing = list.FirstOrDefault(r => r.FullName == fullName);
            if (existing != null)
            {
                list.Remove(existing);
            }
            return Ok();
        }
    }
}