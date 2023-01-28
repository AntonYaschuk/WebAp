using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAp.Models
{
    public class MusiciansSongs
    {
        public int SongId { get; set; }
        public int MusicianId { get; set; }
        public int Id { get; set; }
        public virtual Musician Musician { get; set; }
        public virtual Song Song { get; set; }
    }
}
