using ProjetoModeloDDD.Domain.Commons;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using ProjetoModeloDDD.Infra.Data.Contexto;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ProjetoModeloDDD.Infra.Data.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        protected ProjetoModeloContext Db = new ProjetoModeloContext();

        public void Adicionar(Cliente cliente)
        {
            var emailJaExistente = Db.Set<Cliente>().FirstOrDefault(s => s.Email == cliente.Email);

            if(emailJaExistente != null)
            {
                throw new ArgumentException("Este email já foi cadastrado para um cliente !");
            }

            var clienteJaExistente = Db.Set<Cliente>().ToList().FirstOrDefault(s => s.Nome.RemoveWhitespace() + s.Sobrenome.RemoveWhitespace() == cliente.Nome.RemoveWhitespace() + cliente.Sobrenome.RemoveWhitespace());

            if (clienteJaExistente != null)
            {
                throw new ArgumentException("Já existe um cliente com este nome !");
            }

            Db.Set<Cliente>().Add(cliente);
            Db.SaveChanges();
        }

        public Cliente ObterPorId(int id)
        {
            var cliente = Db.Set<Cliente>().Find(id);

            if (cliente == null)
            {
                throw new ArgumentException("O cliente não existe na base!");
            }

            return cliente;
        }

        public IEnumerable<Cliente> ObterTodos()
        {
            var clientes = Db.Set<Cliente>().ToList();

            if (!clientes.Any())
            {
                throw new ArgumentException("Não foi encontrado nenhum cliente na base !");
            }

            return clientes;
        }

        public void Atualizar(Cliente cliente)
        {
            Db.Entry(cliente).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public void Remover(Cliente cliente)
        {
            throw new Exception("erro Genérico");
            Db.Set<Cliente>().Remove(cliente);
            Db.SaveChanges();
        }

        public IEnumerable<Cliente> BuscarPorNome(string nome)
        {
            var clientes = Db.Set<Cliente>().Where(s => $"{s.Nome} {s.Sobrenome}".Contains(nome));

            if (!clientes.Any())
            {
                throw new ArgumentException("Não foi encontrado nenhum cliente na base !");
            }

            return clientes;
        }
    }
}
