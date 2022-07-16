using Core.Domain.Entities;

namespace Core.Interfaces.UseCases
{
    public interface IClienteUseCase
    {
        IEnumerable<Cliente> ObterClientesEspeciais();
        Cliente ObterPorId(int id);
        IEnumerable<Cliente> ObterTodos();
        bool Adicionar(Cliente cliente);
        bool Atualizar(Cliente cliente);
        bool Remover(int id);
    }
}
