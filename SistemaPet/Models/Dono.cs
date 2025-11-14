using System.ComponentModel.DataAnnotations;

namespace SistemaPet.Models
{
    public class Dono
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(200)]
        public string NomeCompleto { get; set; } = string.Empty;
        
        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; } = string.Empty;
        
        [Required]
        [StringLength(20)]
        public string Telefone { get; set; } = string.Empty;
        
        [Required]
        [StringLength(100)]
        public string Cidade { get; set; } = string.Empty;
        
        [StringLength(200)]
        public string? Endereco { get; set; }
        
        [StringLength(10)]
        public string? Cep { get; set; }
        
        [StringLength(50)]
        public string? Estado { get; set; }
        
        [StringLength(200)]
        public string? ContatoEmergencia { get; set; }
        
        [StringLength(20)]
        public string? TelefoneEmergencia { get; set; }
        
        public string? Observacao { get; set; }
        
        public List<Pet>? Pets { get; set; }
    }
}

