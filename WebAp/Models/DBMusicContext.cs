using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebAp.Models
{
    public class DBMusicContext : DbContext
    {
        public virtual DbSet<Musician> Musicians { get; set; }

        public virtual DbSet<MusiciansSongs> MusiciansSongs { get; set; }
        public virtual DbSet<Song> Songs { get; set; }

        public virtual DbSet<Genre> Genres { get; set; }

        public DBMusicContext ( DbContextOptions <DBMusicContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

    }

}
