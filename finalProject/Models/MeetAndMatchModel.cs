namespace finalProject.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MeetAndMatchModel : DbContext
    {
        public MeetAndMatchModel()
            : base("name=MAMModel")
        {
        }

        public virtual DbSet<MatchMaker> MatchMaker { get; set; }
        public virtual DbSet<Meetings> Meetings { get; set; }
        public virtual DbSet<Participants> Participants { get; set; }
        public virtual DbSet<Status> Status { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MatchMaker>()
                .Property(e => e.userName)
                .IsUnicode(false);

            modelBuilder.Entity<MatchMaker>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<MatchMaker>()
                .Property(e => e.mail)
                .IsUnicode(false);

            modelBuilder.Entity<MatchMaker>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<Meetings>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<Participants>()
                .Property(e => e.firstName)
                .IsUnicode(false);

            modelBuilder.Entity<Participants>()
                .Property(e => e.lastName)
                .IsUnicode(false);

            modelBuilder.Entity<Participants>()
                .Property(e => e.gender)
                .IsUnicode(false);

            modelBuilder.Entity<Participants>()
                .Property(e => e.origin)
                .IsUnicode(false);

            modelBuilder.Entity<Participants>()
                .Property(e => e.resume)
                .IsUnicode(false);

            modelBuilder.Entity<Participants>()
                .Property(e => e.mail)
                .IsUnicode(false);

            modelBuilder.Entity<Participants>()
                .Property(e => e.phone)
                .IsFixedLength();

            modelBuilder.Entity<Participants>()
                .HasMany(e => e.Meetings)
                .WithOptional(e => e.Participants)
                .HasForeignKey(e => e.firstParticipantId);

            modelBuilder.Entity<Participants>()
                .HasMany(e => e.Meetings1)
                .WithOptional(e => e.Participants1)
                .HasForeignKey(e => e.secondParticipantId);

            modelBuilder.Entity<Participants>()
                .HasMany(e => e.Meetings2)
                .WithOptional(e => e.Participants2)
                .HasForeignKey(e => e.secondParticipantId);

            modelBuilder.Entity<Status>()
                .Property(e => e.statusDesc)
                .IsUnicode(false);

            modelBuilder.Entity<Status>()
                .HasMany(e => e.Participants)
                .WithOptional(e => e.Status1)
                .HasForeignKey(e => e.status);
        }
    }
}
