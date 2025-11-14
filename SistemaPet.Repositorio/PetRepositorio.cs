using Microsoft.EntityFrameworkCore;
using SistemaPet.Dominio;

namespace SistemaPet.Repositorio
{
    public class PetRepositorio : IPetRepositorio
    {
        private readonly PetDbContext _context;

        public PetRepositorio(PetDbContext contexto)
        {
            _context = contexto;
        }

        public void Adicionar(Pet pet)
        {
            _context.Pets.Add(pet);
            _context.SaveChanges();
        }

        public List<Pet> Listar()
        {
            return _context.Pets
                .Include(p => p.Dono)
                .Include(p => p.Vacinas)
                .ToList();
        }

        public Pet? BuscarPorId(int id)
        {
            return _context.Pets
                .Include(p => p.Dono)
                .Include(p => p.Vacinas)
                .FirstOrDefault(p => p.Id == id);
        }

        public void Atualizar(Pet pet)
        {
            _context.Pets.Update(pet);
            _context.SaveChanges();
        }

        public void Remover(int id)
        {
            var pet = _context.Pets.Find(id);
            if (pet != null)
            {
                _context.Pets.Remove(pet);
                _context.SaveChanges();
            }
        }
    }
}

