using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaPet.Dominio
{
    public class Pet
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Especie { get; set; } = string.Empty;
        public string Raca { get; set; } = string.Empty;
        public int Idade { get; set; }
        public decimal Peso { get; set; }
        public string Cor { get; set; } = string.Empty;
        public string Sexo { get; set; } = string.Empty;
        public bool EstaVacinado { get; set; }
        public string Observacoes { get; set; } = string.Empty;
        public string ObservacoesMedicas { get; set; } = string.Empty;
        public string? Foto { get; set; }
        
        // Relacionamento com Dono
        public int DonoId { get; set; }
        public Dono? Dono { get; set; }
        
        // Relacionamento com Vacinas
        public List<Vacina> Vacinas { get; set; } = new List<Vacina>();

        public bool PrecisaVacina()
        {
            return !EstaVacinado || Vacinas.Count == 0;
        }

        public bool EstaEmDiaComVacinas()
        {
            if (Vacinas.Count == 0) return false;
            
            var hoje = DateTime.Now;
            return Vacinas.Any(v => v.ProximaDose > hoje);
        }
    }
}

