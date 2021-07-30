using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multimedia
{
    class PlaylistRepository :IDBrepository<Songs>
    {
        internal List<Songs> playlist = new List<Songs>();
        internal int CreatePlaylist(string title)
        {
            int check = 0;
            var s = SongsRepository.songs.Where(t => t.Title == title);

            if (s.Count() > 0)
            {
                foreach (var x in s)
                {
                    foreach(var y in playlist)
                    {
                        if(x.Title == y.Title)
                        {
                            check++;
                        }
                    }
                    if (check == 0)
                    {
                        playlist.Add(x);
                    }
                    else return -2;
                }
                return 0;
            }
            else return -1;
        }

        public List<Songs> Fetch()
        {
            return playlist;
        }

        public List<Songs> FetchStaticList()
        {
            return playlist;
        }

        
    }
}
