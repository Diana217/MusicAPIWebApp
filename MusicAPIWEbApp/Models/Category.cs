using System.ComponentModel.DataAnnotations;

namespace MusicAPIWebApp.Models
{
    public class Category
    {
        public Category()
        {
            MusicalInstruments = new List<MusicalInstrument>();
        }
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Категорія")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Опис категорії")]
        public string Description { get; set; }

        public virtual ICollection<MusicalInstrument> MusicalInstruments { get; set; }
    }
}
