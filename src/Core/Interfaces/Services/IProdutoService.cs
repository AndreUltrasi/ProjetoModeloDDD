using Core.Domain.Entities;

namespace Core.Interfaces.Services
{
    public interface IProdutoService
    {
        IEnumerable<Produto> ObterPorNome(string nome);
        Produto ObterPorId(int id);
        IEnumerable<Produto> ObterTodos();
        bool Adicionar(Produto produto);
        bool Atualizar(Produto produto);
        bool Remover(Produto produto);
    }
}
