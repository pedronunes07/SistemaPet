using Microsoft.EntityFrameworkCore;
using SistemaPet.Dominio;

namespace SistemaPet.Repositorio
{
    public class PetDbContext : DbContext
    {
        public PetDbContext(DbContextOptions<PetDbContext> options)
            : base(options)
        {
        }

        public DbSet<Pet> Pets { get; set; }
        public DbSet<Dono> Donos { get; set; }
        public DbSet<Vacina> Vacinas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuração do relacionamento Pet-Dono
            modelBuilder.Entity<Pet>()
                .HasOne(p => p.Dono)
                .WithMany(d => d.Pets)
                .HasForeignKey(p => p.DonoId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configuração do relacionamento Pet-Vacina
            modelBuilder.Entity<Vacina>()
                .HasOne(v => v.Pet)
                .WithMany(p => p.Vacinas)
                .HasForeignKey(v => v.PetId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

