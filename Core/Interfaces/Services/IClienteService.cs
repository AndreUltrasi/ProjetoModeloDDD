using ProjetoModeloDDD.Core.Domain.Entities;

namespace ProjetoModeloDDD.Core.Interfaces.Services
{
    public interface IClienteService
    {
        IEnumerable<Cliente> ObterClientesEspeciais();
        Cliente ObterPorId(int id);
        IEnumerable<Cliente> ObterTodos();
        bool Adicionar(Cliente cliente);
        bool Atualizar(Cliente cliente);
        bool Remover(int id);
    }
}
