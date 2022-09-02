using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
