using GithubSearchApi.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace GithubSearchApi.Services
{
    public class EmailService: IEmailService
    {
        public void SendRepositoryEmail(string toEmail, RepositoryModel repo)
        {
            var host = ConfigurationManager.AppSettings["SmtpHost"];
            var port = int.Parse(ConfigurationManager.AppSettings["SmtpPort"]);
            var user = ConfigurationManager.AppSettings["SmtpUser"];
            var pass = ConfigurationManager.AppSettings["SmtpPass"];
            var from = ConfigurationManager.AppSettings["SmtpFrom"];

            var client = new SmtpClient(host, port)
            {
                Credentials = new System.Net.NetworkCredential(user, pass),
                EnableSsl = true
            };

            var body = $@"
Repository: {repo.FullName}
Name: {repo.Name}
Url: {repo.HtmlUrl}
Description: {repo.Description}
Owner: {repo.Owner?.Login}
";

            var mail = new MailMessage(from, toEmail)
            {
                Subject = $"Repository details: {repo.FullName}",
                Body = body
            };

            client.Send(mail);
        }
    }
}