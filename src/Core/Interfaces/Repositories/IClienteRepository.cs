using Core.Domain.Entities;

namespace Core.Interfaces.Repositories
{
    public interface IClienteRepository
    {
        IEnumerable<Cliente> BuscarPorNome(string nome);
        void Adicionar(Cliente cliente);
        Cliente ObterPorId(int id);
        IEnumerable<Cliente> ObterTodos();
        void Atualizar(Cliente cliente);
        void Remover(Cliente cliente);
    }
}
