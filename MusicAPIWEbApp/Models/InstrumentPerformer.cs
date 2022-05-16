using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicAPIWebApp.Models
{
    public class InstrumentPerformer
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("MusicalInstrument")]
        public int MusicalInstrumentId { get; set; }
        [ForeignKey("Performer")]
        public int PerformerId { get; set; }

        public virtual MusicalInstrument MusicalInstrument { get; set; }
        public virtual Performer Performer { get; set; }
    }
}

