using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaPet.Models
{
    public class Vacina
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string NomeVacina { get; set; } = string.Empty;
        
        [Required]
        public DateTime DataAplicacao { get; set; }
        
        public DateTime? ProximaDose { get; set; }
        
        [StringLength(100)]
        public string? NomeVeterinario { get; set; }
        
        public int PetId { get; set; }
        
        [ForeignKey("PetId")]
        public Pet? Pet { get; set; }
    }

    public class Pet
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Nome { get; set; } = string.Empty;
        
        [Required]
        [StringLength(50)]
        public string Especie { get; set; } = string.Empty;
        
        [StringLength(50)]
        public string? Raca { get; set; }
        
        [Required]
        public int Idade { get; set; }
        
        [StringLength(20)]
        public string? Peso { get; set; }
        
        [StringLength(30)]
        public string? Cor { get; set; }
        
        [StringLength(10)]
        public string? Sexo { get; set; }
        
        [StringLength(10)]
        public string? Vacinado { get; set; }
        
        public string? Observacoes { get; set; }
        
        public string? ObservacoesMedicas { get; set; }
        
        public string? Fotos { get; set; } // JSON array de strings
        
        public int? DonoId { get; set; }
        
        [ForeignKey("DonoId")]
        public Dono? Dono { get; set; }
        
        public List<Vacina>? Vacinas { get; set; }
        
        public bool EhAdulto()
        {
            return Idade >= 1;
        }
    }
}

