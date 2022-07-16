using Core.Domain.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.UseCases;

namespace Core.UseCases
{
    public class ClienteUseCase : IClienteUseCase
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteUseCase(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public IEnumerable<Cliente> ObterClientesEspeciais()
        {
            var clientesTodos = _clienteRepository.ObterTodos();
            var clientesEspeciais = clientesTodos.Where(s => s.ClienteEspecial());
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
                return clientesTodos;
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
