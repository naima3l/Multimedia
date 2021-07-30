using System;
using System.Collections.Generic;

namespace Multimedia
{
    internal class Menu
    {
        internal static SongsRepository sr = new SongsRepository();
        internal static PodcastRepository pr = new PodcastRepository();
        internal static PlaylistRepository plr = new PlaylistRepository();
        internal static void Start()
        {

            bool check = false;
            int choice;

            Console.WriteLine("Benvenuto!");
            do
            {
                Console.WriteLine("\nInserisci 1 per vedere tutte le canzoni \nInserisci 2 per vedere tutti i podcast (esclusi gli episodi) \nInserisci 3 per vedere le canzoni del genere scelto  \nInserisci 4 per vedere gli episodi di un certo podcast \nInserisci 5 per vedere tutti gli episodi con durata <= a quella inserita (anche titolo del podcast)  \nInserisci 6 per creare una playlist \nInserisci 7 per scegliere quale episodio riprodurre \nInserisci 0 per uscire");

                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > 7)
                {
                    Console.WriteLine("Scelta non valida! Riprova.");
                }

                switch (choice)
                {
                    case 1: //vedere tutte le canzoni
                        ShowSongs();
                        break;
                    case 2: //vedere tutti i podcast
                        ShowPodcast();
                        break;
                    case 3: //vedere le canzoni del genere scelto 
                        ShowSongsByGenre();
                        break;
                    case 4: //vedere gli episodi di un certo podcast
                        ShowEpisodesByPodcast();
                        break;
                    case 5: //vedere tutti gli episodi con durata <= a quella inserita
                        ShowEpisodesByDuration();
                        break;
                    case 6: //creare una playlist
                        CreatePlaylist();
                        break;
                    case 7: //scegliere quale episodio riprodurre 
                        EpisodeToPlay();
                        break;
                    case 0:
                        Console.WriteLine("Ciao ciao!");
                        check = true;
                        break;
                }


            } while (check == false);
        }

        private static void EpisodeToPlay()
        {
            Console.WriteLine("Quale tra questi episodi vuoi riprodurre? Inserisci il titolo.");
            foreach(var eps in PodcastRepository.episodes)
            {
                Console.WriteLine($"Episodio -> Titolo: {eps.Title} Durata: {eps.Duration} Ascoltato: {eps.Flag},");
            }
            string title = Console.ReadLine();
            while (title == null)
            {
                Console.WriteLine("Inserisci un titolo valido!");
            }
            int res = pr.EpisodesToPlay(title);
            if (res < 0)
            {
                Console.WriteLine($"Mi dispiace ma non c'è nessun espisodio con titolo {title}");
            }
            else Console.WriteLine($"L'episodio {title} è stato riprodotto correttamente");
        }

        private static void CreatePlaylist()
        {
            Console.WriteLine("Creaimo la playlist!");
            bool c = false;
            int scelta;
            do
            {
                Console.WriteLine("\nVuoi inserire una canzone nella playlist? Premi 1 per sì, 0 altrimenti");

                while (!int.TryParse(Console.ReadLine(), out scelta) || scelta < 0 || scelta > 1)
                {
                    Console.WriteLine("Riprova con un opzione valida!");
                }

                if (scelta == 0)
                {
                    c = true;
                    break;
                }
                else
                {
                    Console.WriteLine("\nQuale delle seguenti canzoni vuoi aggiungere alla tua playlist? Inserisci il titolo corrispondente!");
                    ShowSongs();

                    string title = Console.ReadLine();

                    while (title == null)
                    {
                        Console.WriteLine("Inserisci un titolo valido!");
                    }

                    int res = plr.CreatePlaylist(title);
                    if (res == -1)
                    {
                        Console.WriteLine("Hai inserito un titolo sbagliato o non presente nella lista di canzoni che ti ho mostrato");
                    }
                    else if(res == -2)
                    {
                        Console.WriteLine("La canzone che stai provando ad inserire è già nella playlist!");
                    }
                    else
                    {
                        List<Songs> playlist = plr.Fetch();
                        Console.WriteLine("La tua playlist contiene le seguenti canzoni : \n");
                        foreach(var s in playlist)
                        {
                            Console.WriteLine(s.Print());
                        }

                    }
                }
            } while (c == false);
        }

        private static void ShowEpisodesByDuration()
        {
            Console.WriteLine("\nInserisci durata in formato 'Hh:Mm:Ss'\n");
            TimeSpan duration;
            while (!TimeSpan.TryParse(Console.ReadLine(), out duration))
            {
                Console.WriteLine("Inserisci una durata valida in formato 'Hh:Mm:Ss'");
            }
            List<Episode> epDuration = pr.ShowEpisodesByDuration(duration);
            if (epDuration.Count >= 1)
            {
                Console.WriteLine("\nGli episodi con durata <= di quella inserita sono : \n");
                foreach (var eps in epDuration)
                {
                    pr.CheckPodcastByEpisode(eps);
                    //Console.WriteLine(eps.Print());
                }
            }
            else Console.WriteLine("Nessun episodio ha durata <= di quella inserita");
        }

        private static void ShowPodcast()
        {
            List<Podcast> podcasts = pr.Fetch();
            foreach (var p in podcasts)
            {
                Console.WriteLine(p.Print());
            }
        }
        private static void ShowSongs()
        {
            List<Songs> songs = sr.Fetch();
            foreach (var s in songs)
            {
                Console.WriteLine(s.Print());
            }
        }
        private static void ShowEpisodesByPodcast()
        {

            Console.WriteLine("Inserisci il titolo del podcast per cui vuoi visualizzare gli episodi");
            ShowPodcast();
            string title = Console.ReadLine();

            while (title == null)
            {
                Console.WriteLine("Inserisci un titolo valido!");
            }
            bool res = pr.ShowEpisodesByPodcast(title);
            if (res == false)
            {
                Console.WriteLine("Hai inserito un codice sbagliato");
            }
            else
            {
                List<Podcast> pe = pr.FetchEpisodes();
                foreach (var x in pe)
                {
                    x.PrintEpisodes();
                }
            }
        }

        private static void ShowSongsByGenre()
        {
            Console.WriteLine("Inserisci il genere per cui vuoi visualizzare la canzoni");
            EnumGenre g = GetGenre();

            List<Songs> songsByGenre = sr.ShowSongsByGenre(g);
            if (songsByGenre.Count >= 1)
            {
                Console.WriteLine($"Le canzoni con genere {g} sono :\n");
                foreach (var s in songsByGenre)
                {
                    Console.WriteLine(s.Print());
                }
            }
            else Console.WriteLine($"Nessuna canzone ha genere {g}.\n");
        }

        private static EnumGenre GetGenre()
        {
            Console.WriteLine($"Premi {(int)EnumGenre.Rock} per scegliere {EnumGenre.Rock}");
            Console.WriteLine($"Premi {(int)EnumGenre.Pop} per scegliere {EnumGenre.Pop}");
            Console.WriteLine($"Premi {(int)EnumGenre.Metal} per scegliere {EnumGenre.Metal}");
            Console.WriteLine($"Premi {(int)EnumGenre.Latin} per scegliere {EnumGenre.Latin}");
            Console.WriteLine($"Premi {(int)EnumGenre.Rap} per scegliere {EnumGenre.Rap}");
            Console.WriteLine($"Premi {(int)EnumGenre.Jazz} per scegliere {EnumGenre.Jazz}");

            int g;
            while (!int.TryParse(Console.ReadLine(), out g) || g < 0 || g > 6)
            {
                Console.WriteLine("Scelta non corretta, riprova");
            }

            return (EnumGenre)g;
        }
    }
}
