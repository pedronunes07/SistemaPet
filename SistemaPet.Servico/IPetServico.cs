using SistemaPet.Dominio;

namespace SistemaPet.Servico
{
    public interface IPetServico
    {
        void Adicionar(Pet pet);
        List<Pet> Listar();
        Pet? BuscarPorId(int id);
        void Atualizar(Pet pet);
        void Remover(int id);
    }
}

