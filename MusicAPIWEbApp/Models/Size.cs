using System.ComponentModel.DataAnnotations;

namespace MusicAPIWebApp.Models
{
    public class Size
    {
        public Size()
        {
            MusicalInstruments = new List<MusicalInstrument>();
        }
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Розмір")]
        public string Name { get; set; }

        public virtual ICollection<MusicalInstrument> MusicalInstruments { get; set; }
    }
}

