using SistemaPet.Dominio;

namespace SistemaPet.Repositorio
{
    public interface IDonoRepositorio
    {
        void Adicionar(Dono dono);
        List<Dono> Listar();
        Dono? BuscarPorId(int id);
        void Atualizar(Dono dono);
        void Remover(int id);
    }
}

