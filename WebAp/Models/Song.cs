using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAp.Models
{
    public class Song
    {
        public Song()
        {
            MusiciansSongs = new List<MusiciansSongs>();
        }
        public int Id { get; set; }

        public string Name { get; set; }
        public string Info { get; set; }

        public int GenreId { get; set; }

        public virtual Genre Genre { get; set; }
        public virtual ICollection<MusiciansSongs> MusiciansSongs { get; set; }
    }
}
