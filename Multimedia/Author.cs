using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multimedia
{
    class Author
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthYear { get; set; }

        public Author(string name, string surname, DateTime birthYear)
        {
            Name = name;
            Surname = surname;
            BirthYear = birthYear;
        }
    }
}
