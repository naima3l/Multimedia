using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multimedia
{
    class Podcast : Multimedia
    {
        public string Description { get; set; }
        public List<Episode> Episodes { get; set; }

        public Podcast(string title, Author author, string description, List<Episode> episodes):
            base(title, author)
        {
            Description = description;
            Episodes = episodes;
        }

        public override string Print()
        {
            return $"Podcast -> {base.Print()}, Descrizione: {Description}";
        }

        public void PrintEpisodes()
        {
            Console.WriteLine($"Podcast -> {base.Print()}, Descrizione: {Description} con episodi : ");
            foreach (var x in Episodes)
            {
                Console.WriteLine($"Titolo: {x.Title} Durata: {x.Duration} Ascoltato: {x.Flag},");
            }
        }
    }
}
