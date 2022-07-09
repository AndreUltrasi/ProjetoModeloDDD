using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using ProjetoModeloDDD.Infra.Data.Contexto;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ProjetoModeloDDD.Infra.Data.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        protected ProjetoModeloContext Db = new ProjetoModeloContext();

        public void Adicionar(Cliente obj)
        {
            Db.Set<Cliente>().Add(obj);
            Db.SaveChanges();
        }

        public Cliente ObterPorId(int id)
        {
            var entity = Db.Set<Cliente>().Find(id);
            return entity;
        }

        public IEnumerable<Cliente> ObterTodos()
        {
            var entities = Db.Set<Cliente>().ToList();
            return entities;
        }

        public void Atualizar(Cliente obj)
        {
            Db.Entry(obj).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public void Remover(Cliente obj)
        {
            Db.Set<Cliente>().Remove(obj);
            Db.SaveChanges();
        }

        public void Dispose()
        {
            ;
        }

        public IEnumerable<Cliente> BuscarPorNome(string nome)
        {
            var clientes = Db.Set<Cliente>().Where(s => $"{s.Nome} {s.Sobrenome}".Contains(nome));
            return clientes;
        }
    }
}
