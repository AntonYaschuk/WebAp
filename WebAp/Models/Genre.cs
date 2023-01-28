using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebAp.Models
{
    public class Genre
    {
        public Genre()
        {
            Songs = new List<Song>();
        }
        public int Id { get; set; }
        [Required(ErrorMessage ="Поле не может быть пустым")]
        [Display(Name ="Жанр")]

        public string Name { get; set; }
        [Display(Name = "Информация про жанр")]
        public string Info { get; set; }
        public virtual ICollection<Song> Songs { get; set; }
    }
}
