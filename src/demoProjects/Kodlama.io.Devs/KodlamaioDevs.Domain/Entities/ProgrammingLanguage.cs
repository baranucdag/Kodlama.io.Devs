using Core.Persistence.Repositories;

namespace KodlamaioDevs.Domain.Entities
{
    public class ProgrammingLanguage : Entity
    {
        public string Name { get; set; }
        public ProgrammingLanguage()
        {

        }
        public ProgrammingLanguage(int id,string name):this()
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
