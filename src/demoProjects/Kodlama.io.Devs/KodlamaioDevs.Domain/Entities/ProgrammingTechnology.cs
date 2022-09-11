using Core.Persistence.Repositories;

namespace KodlamaioDevs.Domain.Entities
{
    public class ProgrammingTechnology : Entity
    {
        public int ProgrammingLanguageId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ProgrammingLanguage? ProgrammingLanguage { get; set; }
        public ProgrammingTechnology()
        {

        }

        public ProgrammingTechnology(int id,int programmingLanguageId, string name, string description)
        {
            Id = id;
            ProgrammingLanguageId = programmingLanguageId;
            Name = name;
            Description = description;
        }
    }
}
