using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multimedia
{
    class Songs : Multimedia
    {
        public EnumGenre Genre { get; set; }

        public Songs(string title, Author author, EnumGenre genre):
            base(title,author)
        {
            Genre = genre;
        }

        public override string Print()
        {
            return $"Canzone -> {base.Print()}, Genere: {Genre}";
        }
    }

    enum EnumGenre
    {
        Rock,
        Pop,
        Metal,
        Latin,
        Rap,
        Jazz
    }
}
