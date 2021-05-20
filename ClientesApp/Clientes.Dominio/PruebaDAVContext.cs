using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ClientesApp.Clientes.Dominio
{
    public partial class PruebaDAVContext : DbContext
    {
        public PruebaDAVContext()
        {
        }

        public PruebaDAVContext(DbContextOptions<PruebaDAVContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;port=3306;user=root;database=PruebaDAV", Microsoft.EntityFrameworkCore.ServerVersion.Parse("5.7.31-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.Idclientes)
                    .HasName("PRIMARY");

                entity.ToTable("clientes");

                entity.Property(e => e.Idclientes)
                    .HasColumnType("int(11)")
                    .HasColumnName("idclientes");

                entity.Property(e => e.Activo)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("activo");

                entity.Property(e => e.Estadocivil)
                    .HasMaxLength(45)
                    .HasColumnName("estadocivil");

                entity.Property(e => e.Fechanacimiento)
                    .HasColumnType("datetime")
                    .HasColumnName("fechanacimiento");

                entity.Property(e => e.Nombrel)
                    .HasMaxLength(45)
                    .HasColumnName("nombrel");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
