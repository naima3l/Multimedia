using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multimedia
{
    class PodcastRepository : IDBrepository<Podcast>
    {
        static Episode e1 = new Episode("e1", new TimeSpan(02, 03, 05));
        static Episode e2 = new Episode("e2", new TimeSpan(03, 53, 50));
        static Episode e3 = new Episode("e3", new TimeSpan(01, 21, 56));
        static Episode e4 = new Episode("e4", new TimeSpan(02, 33, 57));
        static Episode e5 = new Episode("e5", new TimeSpan(04, 12, 00));

        public static List<Episode> episodes = new List<Episode>
        {
            e1,
            e2,
            e3,
            e4,
            e5
        };

        static List<Podcast> podcasts = new List<Podcast>
        {
            new Podcast("p1",new Author("ciccio","pasticcio",new DateTime(1991,3,2)),"podcast bellissimo",new List<Episode>{ e1,e2}),
            new Podcast("p2",new Author("pasta","asciutta",new DateTime(1989,2,25)),"podcast fantastico",new List<Episode>{ e3,e4}),
            new Podcast("p3",new Author("bebe","rexha",new DateTime(2000,11,1)),"podcast magnifico",new List<Episode>{ e1,e5})

        };

        public static List<Podcast> Pepisodes = new List<Podcast>();
        public List<Podcast> Fetch()
        {
            return podcasts;
        }

        public List<Podcast> FetchStaticList()
        {
            return podcasts;
        }

        internal bool ShowEpisodesByPodcast(string title)
        {
            int check = podcasts.Count(t => t.Title == title);
            if (check == 0)
            {
                return false;
            }
            else
            {

                var ep = from p in podcasts
                         where p.Title == title
                         select p;


                foreach (var x in ep)
                {
                    Pepisodes.Add(x);
                }
                return true;
            }

        }


        public List<Podcast> FetchEpisodes()
        {
            return Pepisodes;
        }

        internal List<Episode> ShowEpisodesByDuration(TimeSpan duration)
        {
            var ep = episodes.Where(t => t.Duration <= duration);
            List<Episode> listEps = new List<Episode>();
            if (ep.Count() > 0)
            {
                foreach (var e in ep)
                {
                    listEps.Add(e);
                }
            }
            return listEps;
        }

        internal void CheckPodcastByEpisode(Episode eps)
        {
            foreach(var p in podcasts)
            {
                {
                    foreach(var e in p.Episodes)
                    {
                        if (eps.Title == e.Title)
                        {
                            Console.WriteLine(p.Print());
                            Console.Write($"Episodio -> Titolo: {eps.Title} Durata: {eps.Duration} Ascoltato: {eps.Flag},  \n");
                        }
                    }
                }
               
            }
        }

        internal int EpisodesToPlay(string title)
        {
            var ep = episodes.Where(t => t.Title == title);
            List<Episode> listEps = new List<Episode>();
            if (ep.Count() > 0)
            {
                foreach (var e in ep)
                {
                    e.Flag = true;
                }
                return 0;
            }
            return -1;
        }
    }
}
