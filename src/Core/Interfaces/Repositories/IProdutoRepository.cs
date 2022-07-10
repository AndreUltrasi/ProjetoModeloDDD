using Core.Domain.Entities;

namespace Core.Interfaces.Repositories
{
    public interface IProdutoRepository
    {
        IEnumerable<Produto> BuscarPorNome(string nome);
        void Adicionar(Produto produto);
        Produto ObterPorId(int id);
        IEnumerable<Produto> ObterTodos();
        void Atualizar(Produto produto);
        void Remover(Produto produto);
    }
}
