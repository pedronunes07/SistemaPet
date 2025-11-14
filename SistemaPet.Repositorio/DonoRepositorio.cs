using Microsoft.EntityFrameworkCore;
using SistemaPet.Dominio;

namespace SistemaPet.Repositorio
{
    public class DonoRepositorio : IDonoRepositorio
    {
        private readonly PetDbContext _context;

        public DonoRepositorio(PetDbContext contexto)
        {
            _context = contexto;
        }

        public void Adicionar(Dono dono)
        {
            _context.Donos.Add(dono);
            _context.SaveChanges();
        }

        public List<Dono> Listar()
        {
            return _context.Donos
                .Include(d => d.Pets)
                .ThenInclude(p => p.Vacinas)
                .ToList();
        }

        public Dono? BuscarPorId(int id)
        {
            return _context.Donos
                .Include(d => d.Pets)
                .ThenInclude(p => p.Vacinas)
                .FirstOrDefault(d => d.Id == id);
        }

        public void Atualizar(Dono dono)
        {
            _context.Donos.Update(dono);
            _context.SaveChanges();
        }

        public void Remover(int id)
        {
            var dono = _context.Donos
                .Include(d => d.Pets)
                .FirstOrDefault(d => d.Id == id);
            
            if (dono != null)
            {
                // Remove os pets associados
                _context.Pets.RemoveRange(dono.Pets);
                _context.Donos.Remove(dono);
                _context.SaveChanges();
            }
        }
    }
}

