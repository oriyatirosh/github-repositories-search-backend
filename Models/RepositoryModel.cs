using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GithubSearchApi.Models
{
    public class RepositoryModel
    {
        public string Name { get; set; }
        public string FullName { get; set; }
        public string HtmlUrl { get; set; }
        public string Description { get; set; }
        public Owner Owner { get; set; }
    }
}