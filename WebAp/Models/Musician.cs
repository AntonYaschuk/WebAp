using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAp.Models
{
    public class Musician
    {
        public Musician()
        {
            MusiciansSongs = new List<MusiciansSongs>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
        public virtual ICollection<MusiciansSongs> MusiciansSongs { get; set; }
    }
}
