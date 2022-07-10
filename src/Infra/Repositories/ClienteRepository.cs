using Core.Domain.Entities;
using Core.Interfaces.Repositories;
using Infra.Contexto;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ProjetoModeloContext _context;
        public ClienteRepository(ProjetoModeloContext context)
        {
            _context = context;
        }

        public void Adicionar(Cliente cliente)
        {
            var emailJaExistente = _context.Set<Cliente>().FirstOrDefault(s => s.Email == cliente.Email);

            if (emailJaExistente != null)
            {
                throw new ArgumentException("Este email já foi cadastrado para um cliente !");
            }

            var clienteJaExistente = _context.Set<Cliente>().ToList().FirstOrDefault(s => s.Nome + s.Sobrenome == cliente.Nome + cliente.Sobrenome);

            if (clienteJaExistente != null)
            {
                throw new ArgumentException("Já existe um cliente com este nome !");
            }

            if (cliente.DataCadastro == default(DateTime))
            {
                cliente.DataCadastro = DateTime.Now;
            }

            _context.Set<Cliente>().Add(cliente);
            _context.SaveChanges();
        }

        public Cliente ObterPorId(int id)
        {
            var cliente = _context.Set<Cliente>().Find(id);

            if (cliente == null)
            {
                throw new ArgumentException("O cliente não existe na base!");
            }

            return cliente;
        }

        public IEnumerable<Cliente> ObterTodos()
        {
            var clientes = _context.Set<Cliente>().ToList();

            return clientes;
        }

        public void Atualizar(Cliente cliente)
        {
            _context.Entry(cliente).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Remover(Cliente cliente)
        {
            _context.Set<Cliente>().Remove(cliente);
            _context.SaveChanges();
        }

        public IEnumerable<Cliente> BuscarPorNome(string nome)
        {
            var clientes = _context.Set<Cliente>().Where(s => $"{s.Nome} {s.Sobrenome}".Contains(nome));

            if (!clientes.Any())
            {
                throw new ArgumentException("Não foi encontrado nenhum cliente na base !");
            }

            return clientes;
        }
    }
}
