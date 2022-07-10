using ProjetoModeloDDD.Core.Domain.Entities;
using ProjetoModeloDDD.Core.Interfaces.Repositories;
using ProjetoModeloDDD.Infra.Contexto;
using Microsoft.EntityFrameworkCore;

namespace ProjetoModeloDDD.Infra.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ProjetoModeloContext? _context;
        public ProdutoRepository(ProjetoModeloContext context)
        {
            _context = context;
        }

        public IEnumerable<Produto> BuscarPorNome(string nome)
        {
            return _context.Produtos.Where(p => p.Nome == nome);
        }

        public void Adicionar(Produto obj)
        {
            _context.Set<Produto>().Add(obj);
            _context.SaveChanges();
        }

        public Produto ObterPorId(int id)
        {
            var entity = _context.Set<Produto>().Find(id);
            return entity;
        }

        public IEnumerable<Produto> ObterTodos()
        {
            var todosProdutos = _context.Set<Produto>().ToList();
            return todosProdutos;
        }

        public void Atualizar(Produto produto)
        {
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
