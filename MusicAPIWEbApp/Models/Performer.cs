using System.ComponentModel.DataAnnotations;

namespace MusicAPIWebApp.Models
{
    public class Performer
    {
        public Performer()
        {
            InstrumentPerformers = new List<InstrumentPerformer>();
        }
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Ім'я виконавця")]
        public string Name { get; set; }

        public virtual ICollection<InstrumentPerformer> InstrumentPerformers { get; set; }
    }
}

