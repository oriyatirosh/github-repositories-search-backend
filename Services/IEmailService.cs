using GithubSearchApi.Models;

namespace GithubSearchApi.Services
{
    public interface IEmailService
    {
        void SendRepositoryEmail(string toEmail, RepositoryModel repo);
    }
}
