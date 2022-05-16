using Microsoft.EntityFrameworkCore;

namespace MusicAPIWebApp.Models
{
    public class MusicAPIContext : DbContext
    {
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<CountryOfOrigin> CountryOfOrigins { get; set; }
        public virtual DbSet<InstrumentPerformer> InstrumentPerformers { get; set; }
        public virtual DbSet<MusicalInstrument> MusicalInstruments { get; set; }
        public virtual DbSet<Performer> Performers { get; set; }
        public virtual DbSet<Size> Sizes { get; set; }

        public MusicAPIContext(DbContextOptions<MusicAPIContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
