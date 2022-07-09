
using ProjetoModeloDDD.Domain.Entities;
using System.Collections.Generic;

namespace ProjetoModeloDDD.Domain.Interfaces.Services
{
    public interface IClienteService
    {
        IEnumerable<Cliente> ObterClientesEspeciais();
        Cliente ObterPorId(int id);
        IEnumerable<Cliente> ObterTodos();
        void Adicionar(Cliente cliente);
        void Atualizar(Cliente cliente);
        void Remover(Cliente cliente);
    }
}
