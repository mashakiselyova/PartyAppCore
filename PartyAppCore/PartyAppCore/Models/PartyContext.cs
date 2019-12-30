using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PartyAppCore.Models
{
    public class PartyContext : DbContext
    {
        public DbSet<Party> Parties { get; set; }
        public DbSet<Participant> Participants { get; set; }

        public PartyContext(DbContextOptions<PartyContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PartyConfiguration());
            modelBuilder.ApplyConfiguration(new ParticipantConfiguration());
        }
    }

    public class PartyConfiguration : IEntityTypeConfiguration<Party>
    {
        public void Configure(EntityTypeBuilder<Party> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Location).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Date).IsRequired();
            builder.HasMany(p => p.Participants)
                .WithOne(p => p.Party)
                .HasForeignKey(p => p.PartyId);
        }
    }

    public class ParticipantConfiguration : IEntityTypeConfiguration<Participant>
    {
        public void Configure(EntityTypeBuilder<Participant> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Property(p => p.IsAttending).IsRequired();
            builder.Property(p => p.Avatar);
            builder.HasOne(p => p.Party)
                .WithMany(p => p.Participants)
                .HasForeignKey(p => p.PartyId);
        }
    }
}
