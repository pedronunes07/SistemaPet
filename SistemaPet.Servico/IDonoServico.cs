using SistemaPet.Dominio;

namespace SistemaPet.Servico
{
    public interface IDonoServico
    {
        void Adicionar(Dono dono);
        List<Dono> Listar();
        Dono? BuscarPorId(int id);
        void Atualizar(Dono dono);
        void Remover(int id);
    }
}

