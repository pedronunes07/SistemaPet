using SistemaPet.Dominio;

namespace SistemaPet.Repositorio
{
    public interface IPetRepositorio
    {
        void Adicionar(Pet pet);
        List<Pet> Listar();
        Pet? BuscarPorId(int id);
        void Atualizar(Pet pet);
        void Remover(int id);
    }
}

