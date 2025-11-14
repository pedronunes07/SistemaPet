using SistemaPet.Dominio;
using SistemaPet.Repositorio;

namespace SistemaPet.Servico
{
    public class PetServico : IPetServico
    {
        private readonly IPetRepositorio _repositorio;
        private readonly IDonoRepositorio _donoRepositorio;

        public PetServico(IPetRepositorio repositorio, IDonoRepositorio donoRepositorio)
        {
            _repositorio = repositorio;
            _donoRepositorio = donoRepositorio;
        }

        public void Adicionar(Pet pet)
        {
            if (string.IsNullOrWhiteSpace(pet.Nome))
                throw new Exception("O nome do pet é obrigatório.");

            if (string.IsNullOrWhiteSpace(pet.Especie))
                throw new Exception("A espécie do pet é obrigatória.");

            // Verifica se o dono existe
            var dono = _donoRepositorio.BuscarPorId(pet.DonoId);
            if (dono == null)
                throw new Exception("Dono não encontrado.");

            _repositorio.Adicionar(pet);
        }

        public List<Pet> Listar()
        {
            return _repositorio.Listar();
        }

        public Pet? BuscarPorId(int id)
        {
            return _repositorio.BuscarPorId(id);
        }

        public void Atualizar(Pet pet)
        {
            if (string.IsNullOrWhiteSpace(pet.Nome))
                throw new Exception("O nome do pet é obrigatório.");

            if (string.IsNullOrWhiteSpace(pet.Especie))
                throw new Exception("A espécie do pet é obrigatória.");

            var petExistente = _repositorio.BuscarPorId(pet.Id);
            if (petExistente == null)
                throw new Exception("Pet não encontrado.");

            // Verifica se o dono existe
            var dono = _donoRepositorio.BuscarPorId(pet.DonoId);
            if (dono == null)
                throw new Exception("Dono não encontrado.");

            _repositorio.Atualizar(pet);
        }

        public void Remover(int id)
        {
            var pet = _repositorio.BuscarPorId(id);
            if (pet == null)
                throw new Exception("Pet não encontrado.");

            _repositorio.Remover(id);
        }
    }
}

