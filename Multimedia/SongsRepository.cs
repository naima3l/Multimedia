using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multimedia
{
    class SongsRepository : IDBrepository<Songs>
    {
        public static List<Songs> songs = new List<Songs>
        {
            new Songs("Bienvenidos",new Author("Luke","Hemmings",new DateTime(1996,02,03)),EnumGenre.Jazz),
            new Songs("Addios",new Author("Ashton","Irwin",new DateTime(1993,12,13)),EnumGenre.Latin),
            new Songs("Hello xxx",new Author("Calum","Hood",new DateTime(1997,02,15)),EnumGenre.Metal),
            new Songs("Paparapa",new Author("Lewis","Capaldi",new DateTime(1995,09,08)),EnumGenre.Jazz),
            new Songs("Rock&Roll",new Author("Niall","Horan",new DateTime(1996,01,01)),EnumGenre.Rock)
        };
        public List<Songs> Fetch()
        {
            return songs;
        }

        public List<Songs> FetchStaticList()
        {
            return songs;
        }

        internal List<Songs> ShowSongsByGenre(EnumGenre g)
        {
            var list_s = songs.Where(t => t.Genre == g);
            List<Songs> s = new List<Songs>();

            if(list_s.Count() > 0)
            {
                foreach(var x in list_s)
                {
                    s.Add(x);
                }
            }

            return s;
             
        }
    }
}
