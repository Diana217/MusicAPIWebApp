using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicAPIWebApp.Models
{
    public class MusicalInstrument
    {
        public MusicalInstrument()
        {
            InstrumentPerformers = new List<InstrumentPerformer>();
        }
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Назва музичного інструменту")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Опис")]
        public string Description { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        [ForeignKey("Size")]
        public int SizeId { get; set; }
        [ForeignKey("CountryOfOrigin")]
        public int CountryOfOriginId { get; set; }

        public Category Category { get; set; }
        public Size Size { get; set; }
        public CountryOfOrigin CountryOfOrigin { get; set; }

        public virtual ICollection<InstrumentPerformer> InstrumentPerformers { get; set; }
    }
}

