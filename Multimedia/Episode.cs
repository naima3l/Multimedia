using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multimedia
{
    class Episode
    {
        public string Title { get; set; }
        public TimeSpan Duration { get; set; }
        public bool Flag { get; set; }


        public Episode(string title, TimeSpan duration)
        {
            Title = title;
            Duration = duration;
            Flag = false;
        }
    }
}
