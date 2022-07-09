using ProjetoModeloDDD.Domain.Entities;
using System.Collections.Generic;

namespace ProjetoModeloDDD.Domain.Interfaces.Repositories
{
    public interface IClienteRepository
    {
        IEnumerable<Cliente> BuscarPorNome(string nome);
        void Adicionar(Cliente obj);
        Cliente ObterPorId(int id);
        IEnumerable<Cliente> ObterTodos();
        void Atualizar(Cliente obj);
        void Remover(Cliente obj);
        void Dispose();
    }
}
