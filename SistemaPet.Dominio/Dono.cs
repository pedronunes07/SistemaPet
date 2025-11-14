using System.Collections.Generic;

namespace SistemaPet.Dominio
{
    public class Dono
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;
        public string Cidade { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
        public string CEP { get; set; } = string.Empty;
        public string ContatoEmergencia { get; set; } = string.Empty;
        public string Observacoes { get; set; } = string.Empty;
        
        // Relacionamento com Pets
        public List<Pet> Pets { get; set; } = new List<Pet>();

        public bool TemPets()
        {
            return Pets != null && Pets.Count > 0;
        }

        public int QuantidadePets()
        {
            return Pets?.Count ?? 0;
        }
    }
}

