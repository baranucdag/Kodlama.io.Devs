namespace KodlamaioDevs.Application.Features.GithubProfiles.Dtos
{
    public class GithubProfileListDto
    {
        public int Id { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserFullName { get; set; }
        public string GithubUrl { get; set; }
    }
}
