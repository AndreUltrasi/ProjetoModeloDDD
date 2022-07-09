
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using ProjetoModeloDDD.Infra.Data.Contexto;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ProjetoModeloDDD.Infra.Data.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        protected ProjetoModeloContext Db = new ProjetoModeloContext();
        public IEnumerable<Produto> BuscarPorNome(string nome)
        {
            return Db.Produtos.Where(p => p.Nome == nome);
        }

        public void Adicionar(Produto obj)
        {
            Db.Set<Produto>().Add(obj);
            Db.SaveChanges();
        }

        public Produto ObterPorId(int id)
        {
            var entity = Db.Set<Produto>().Find(id);
            return entity;
        }

        public IEnumerable<Produto> ObterTodos()
        {
            var todosProdutos = Db.Set<Produto>().ToList();
            return todosProdutos;
        }

        public void Atualizar(Produto produto)
        {
            Db.Entry(produto).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public void Remover(Produto produto)
        {
            Db.Set<Produto>().Remove(produto);
            Db.SaveChanges();
        }
    }
}
