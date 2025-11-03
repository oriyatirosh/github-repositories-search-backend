using GithubSearchApi.Models;
using GithubSearchApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace GithubSearchApi.Controllers
{
    [RoutePrefix("api/Email")]
    public class EmailController : ApiController
    {
        private EmailService _emailService = new EmailService();

        public class SendEmailRequest
        {
            public string To { get; set; }
            public RepositoryModel Repository { get; set; }
        }

        [HttpPost, Route("send")]
        public IHttpActionResult Send([FromBody] SendEmailRequest req)
        {
            if (req == null || string.IsNullOrEmpty(req.To) || req.Repository == null)
                return BadRequest("Invalid request");

            try
            {
                _emailService.SendRepositoryEmail(req.To, req.Repository);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}