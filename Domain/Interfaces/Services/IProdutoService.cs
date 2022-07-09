using ProjetoModeloDDD.Domain.Entities;
using System.Collections.Generic;

namespace ProjetoModeloDDD.Domain.Interfaces.Services
{
    public interface IProdutoService
    {
        IEnumerable<Produto> BuscarPorNome(string nome);
        Produto ObterPorId(int id);
        IEnumerable<Produto> ObterTodos();
        void Adicionar(Produto produto);
        void Atualizar(Produto produto);
        void Remover(Produto produto);
    }
}
