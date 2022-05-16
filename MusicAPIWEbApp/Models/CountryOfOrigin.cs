using System.ComponentModel.DataAnnotations;

namespace MusicAPIWebApp.Models
{
    public class CountryOfOrigin
    {
        public CountryOfOrigin()
        {
            MusicalInstruments = new List<MusicalInstrument>();
        }
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Країна")]
        public string Name { get; set; }

        public virtual ICollection<MusicalInstrument> MusicalInstruments { get; set; }
    }
}
