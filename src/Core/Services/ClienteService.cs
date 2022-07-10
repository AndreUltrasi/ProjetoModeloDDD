using Core.Domain.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;

namespace Core.Services
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
            try
            {
                return _clienteRepository.ObterPorId(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao obter o cliente da base | Erro: {ex.Message}");
            }
        }

        public IEnumerable<Cliente> ObterTodos()
        {
            try
            {
                var clientesTodos = _clienteRepository.ObterTodos();
                //return clientesTodos;
                return new List<Cliente>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao obter todos os clientes da base | Erro: {ex.Message}");
            }
        }

        public bool Adicionar(Cliente cliente)
        {
            try
            {
                _clienteRepository.Adicionar(cliente);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao adicionar o cliente na base | Erro: {ex.Message}");
            }
        }
        public bool Atualizar(Cliente cliente)
        {
            try
            {
                _clienteRepository.Atualizar(cliente);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao atualizar o cliente na base | Erro: {ex.Message}");
            }
        }
        public bool Remover(int id)
        {
            try
            {
                var cliente = _clienteRepository.ObterPorId(id);
                _clienteRepository.Remover(cliente);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao remover o cliente da base | Erro: {ex.Message}");
            }
        }
    }
}
