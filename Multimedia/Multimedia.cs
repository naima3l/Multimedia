using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multimedia
{
    abstract class Multimedia
    {
        public string Title { get; set; }
        public Author Author { get; set; }

        public Multimedia(string title, Author author)
        {
            Title = title;
            Author = author;
        }

        public virtual string Print()
        {
            return $"Titolo: {Title}, Autore: {Author.Name} {Author.Surname}";
        }
    }
}
