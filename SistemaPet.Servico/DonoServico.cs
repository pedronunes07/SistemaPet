using SistemaPet.Dominio;
using SistemaPet.Repositorio;

namespace SistemaPet.Servico
{
    public class DonoServico : IDonoServico
    {
        private readonly IDonoRepositorio _repositorio;

        public DonoServico(IDonoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public void Adicionar(Dono dono)
        {
            if (string.IsNullOrWhiteSpace(dono.Nome))
                throw new Exception("O nome do dono é obrigatório.");

            if (string.IsNullOrWhiteSpace(dono.Email))
                throw new Exception("O email do dono é obrigatório.");

            if (string.IsNullOrWhiteSpace(dono.Telefone))
                throw new Exception("O telefone do dono é obrigatório.");

            _repositorio.Adicionar(dono);
        }

        public List<Dono> Listar()
        {
            return _repositorio.Listar();
        }

        public Dono? BuscarPorId(int id)
        {
            return _repositorio.BuscarPorId(id);
        }

        public void Atualizar(Dono dono)
        {
            if (string.IsNullOrWhiteSpace(dono.Nome))
                throw new Exception("O nome do dono é obrigatório.");

            if (string.IsNullOrWhiteSpace(dono.Email))
                throw new Exception("O email do dono é obrigatório.");

            if (string.IsNullOrWhiteSpace(dono.Telefone))
                throw new Exception("O telefone do dono é obrigatório.");

            var donoExistente = _repositorio.BuscarPorId(dono.Id);
            if (donoExistente == null)
                throw new Exception("Dono não encontrado.");

            _repositorio.Atualizar(dono);
        }

        public void Remover(int id)
        {
            var dono = _repositorio.BuscarPorId(id);
            if (dono == null)
                throw new Exception("Dono não encontrado.");

            _repositorio.Remover(id);
        }
    }
}

