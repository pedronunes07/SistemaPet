using System;

namespace SistemaPet.Dominio
{
    public class Vacina
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public DateTime DataAplicacao { get; set; }
        public DateTime? ProximaDose { get; set; }
        public string Veterinario { get; set; } = string.Empty;
        
        // Relacionamento com Pet
        public int PetId { get; set; }
        public Pet? Pet { get; set; }

        public bool PrecisaRenovar()
        {
            if (ProximaDose == null) return false;
            return ProximaDose.Value <= DateTime.Now;
        }
    }
}

