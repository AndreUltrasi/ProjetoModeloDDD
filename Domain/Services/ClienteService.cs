using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using ProjetoModeloDDD.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoModeloDDD.Domain.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public IEnumerable<Cliente> ObterClientesEspeciais()
        {
            var clientesTodos = _clienteRepository.ObterTodos();
            var clientesEspeciais = clientesTodos.Where(s => s.ClienteEspecial(s));
            return clientesEspeciais;
        }

        public Cliente ObterPorId(int id)
        {
            return _clienteRepository.ObterPorId(id);
        }

        public IEnumerable<Cliente> ObterTodos()
        {
            return _clienteRepository.ObterTodos();
        }

        public void Adicionar(Cliente cliente)
        {
            _clienteRepository.Adicionar(cliente);
        }
        public void Atualizar(Cliente cliente)
        {
            _clienteRepository.Atualizar(cliente);
        }
        public void Remover(Cliente cliente)
        {
            _clienteRepository.Remover(cliente);
        }
    }
}
