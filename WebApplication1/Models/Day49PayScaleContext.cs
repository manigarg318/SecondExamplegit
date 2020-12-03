using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication1.Models
{
    public partial class Day49PayScaleContext : DbContext
    {
        public Day49PayScaleContext()
        {
        }

        public Day49PayScaleContext(DbContextOptions<Day49PayScaleContext> options)
            : base(options)
        {
        }

        public virtual DbSet<PayScale> PayScale { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-QUR9TJK;database=Day49PayScale;trusted_connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PayScale>(entity =>
            {
                entity.HasKey(e => e.PayBand)
                    .HasName("PK__PayScale__66B0F53FF32E35B4");

                entity.Property(e => e.PayBand)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
