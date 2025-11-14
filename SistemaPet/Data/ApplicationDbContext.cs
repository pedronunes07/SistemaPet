using Microsoft.EntityFrameworkCore;
using SistemaPet.Models;

namespace SistemaPet.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
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
                .OnDelete(DeleteBehavior.SetNull);

            // Configuração do relacionamento Pet-Vacina
            modelBuilder.Entity<Vacina>()
                .HasOne(v => v.Pet)
                .WithMany(p => p.Vacinas)
                .HasForeignKey(v => v.PetId)
                .OnDelete(DeleteBehavior.Cascade);

            // Seed data inicial
            modelBuilder.Entity<Dono>().HasData(
                new Dono
                {
                    Id = 1,
                    NomeCompleto = "João Silva",
                    Email = "joao.silva@email.com",
                    Telefone = "(11) 99999-9999",
                    Cidade = "São Paulo",
                    Estado = "SP"
                },
                new Dono
                {
                    Id = 2,
                    NomeCompleto = "Maria Santos",
                    Email = "maria.santos@email.com",
                    Telefone = "(21) 88888-8888",
                    Cidade = "Rio de Janeiro",
                    Estado = "RJ"
                }
            );

            modelBuilder.Entity<Pet>().HasData(
                new Pet
                {
                    Id = 1,
                    Nome = "Rex",
                    Especie = "Cão",
                    Raca = "Labrador",
                    Idade = 3,
                    Peso = "25kg",
                    Cor = "Dourado",
                    Sexo = "Macho",
                    Vacinado = "Sim",
                    DonoId = 1
                },
                new Pet
                {
                    Id = 2,
                    Nome = "Luna",
                    Especie = "Gato",
                    Raca = "Persa",
                    Idade = 2,
                    Peso = "4kg",
                    Cor = "Branco",
                    Sexo = "Fêmea",
                    Vacinado = "Sim",
                    DonoId = 2
                }
            );
        }
    }
}

