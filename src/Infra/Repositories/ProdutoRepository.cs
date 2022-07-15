using Core.Domain.Entities;
using Core.Interfaces.Repositories;
using Infra.Contexto;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ProjetoModeloContext _context;
        public ProdutoRepository(ProjetoModeloContext context)
        {
            _context = context;
        }

        public IEnumerable<Produto> BuscarPorNome(string nome)
        {
            return _context.Produtos.Where(p => p.Nome == nome);
        }

        public void Adicionar(Produto produto)
        {
            _context.Set<Produto>().Add(produto);
            _context.SaveChanges();
        }

        public Produto ObterPorId(int id)
        {
            var produto = _context.Set<Produto>().Find(id);

            var clienteProduto = _context.Set<Cliente>().First(s => s.ClienteId == produto.ClienteId);
            produto.Cliente = clienteProduto;

            return produto;
        }

        public IEnumerable<Produto> ObterTodos()
        {
            var produtos = _context.Set<Produto>().ToList();

            foreach (var produto in produtos)
            {
                var clientesProduto = _context.Set<Cliente>().First(s => s.ClienteId == produto.ClienteId);
                produto.Cliente = clientesProduto;
            }

            return produtos;
        }

        public void Atualizar(Produto produto)
        {
            var clienteProduto = _context.Set<Cliente>().First(s => s.ClienteId == produto.ClienteId);
            produto.Cliente = clienteProduto;
            _context.Entry(produto).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Remover(Produto produto)
        {
            _context.Set<Produto>().Remove(produto);
            _context.SaveChanges();
        }
    }
}
