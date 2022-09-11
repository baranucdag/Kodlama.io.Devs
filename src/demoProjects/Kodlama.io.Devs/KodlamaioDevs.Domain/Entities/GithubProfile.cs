using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace KodlamaioDevs.Domain.Entities
{
    public class GithubProfile : Entity
    {
        public int UserId { get; set; }
        public string GithubUrl { get; set; }
        public virtual User? User { get; set; }
        public GithubProfile()
        {

        }
        public GithubProfile(int id,int userId, string githubUrl)
        {
            Id= id;
            UserId = userId;
            GithubUrl = githubUrl;
        }
    }
}
