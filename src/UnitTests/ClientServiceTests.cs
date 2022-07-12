using AutoBogus;
using Bogus;
using Core.Domain.Entities;
using Core.Interfaces.Repositories;
using Core.Services;
using Moq;
using Xunit;

namespace UnitTests
{
    public class ClientServiceTests
    {
        private readonly Mock<IClienteRepository> _clienteRepository;
        private readonly ClienteService _clienteService;
        public ClientServiceTests()
        {
            _clienteRepository = new Mock<IClienteRepository>();
            _clienteService = new ClienteService(_clienteRepository.Object);
        }
        [Fact(DisplayName = "Adicionar >> Should Sucess >> When Adding Cliente To Database")]
        public void Adicionar_ShouldSucess_WhenAddingClienteToDatabase()
        {
            var cliente = new AutoFaker<Cliente>().Generate();

            _clienteService.Adicionar(cliente);

            _clienteRepository.Verify(s => s.Adicionar(It.IsAny<Cliente>()), Times.Once);
            _clienteRepository.Verify(s => s.Remover(It.IsAny<Cliente>()), Times.Never);
            _clienteRepository.Verify(s => s.ObterPorId(It.IsAny<int>()), Times.Never);
            _clienteRepository.Verify(s => s.Atualizar(It.IsAny<Cliente>()), Times.Never);
            _clienteRepository.Verify(s => s.BuscarPorNome(It.IsAny<string>()), Times.Never);
            _clienteRepository.Verify(s => s.ObterTodos(), Times.Never);
        }

        [Fact(DisplayName = "Atualizar >> Should Sucess >> When Updating Cliente To Database")]
        public void Atualizar_ShouldSucess_WhenUpdatingClienteToDatabase()
        {
            var cliente = new AutoFaker<Cliente>().Generate();

            _clienteService.Atualizar(cliente);

            _clienteRepository.Verify(s => s.Adicionar(It.IsAny<Cliente>()), Times.Never);
            _clienteRepository.Verify(s => s.Remover(It.IsAny<Cliente>()), Times.Never);
            _clienteRepository.Verify(s => s.ObterPorId(It.IsAny<int>()), Times.Never);
            _clienteRepository.Verify(s => s.Atualizar(It.IsAny<Cliente>()), Times.Once);
            _clienteRepository.Verify(s => s.BuscarPorNome(It.IsAny<string>()), Times.Never);
            _clienteRepository.Verify(s => s.ObterTodos(), Times.Never);
        }

        [Fact(DisplayName = "Remover >> Should Sucess >> When Deleting Cliente From Database")]
        public void Remover_ShouldSucess_WhenDeletingClienteFromDatabase()
        {
            var clienteId = new Faker().Random.Int(1);

            _clienteService.Remover(clienteId);

            _clienteRepository.Verify(s => s.Adicionar(It.IsAny<Cliente>()), Times.Never);
            _clienteRepository.Verify(s => s.Remover(It.IsAny<Cliente>()), Times.Once);
            _clienteRepository.Verify(s => s.ObterPorId(It.IsAny<int>()), Times.Never);
            _clienteRepository.Verify(s => s.Atualizar(It.IsAny<Cliente>()), Times.Never);
            _clienteRepository.Verify(s => s.BuscarPorNome(It.IsAny<string>()), Times.Never);
            _clienteRepository.Verify(s => s.ObterTodos(), Times.Never);
        }

        [Fact(DisplayName = "ObterTodos >> Should Sucess >> When Getting All Clientes From Database")]
        public void ObterTodos_ShouldSucess_WhenGettingAllClientesFromDatabase()
        {
            _clienteService.ObterTodos();

            _clienteRepository.Verify(s => s.Adicionar(It.IsAny<Cliente>()), Times.Never);
            _clienteRepository.Verify(s => s.Remover(It.IsAny<Cliente>()), Times.Once);
            _clienteRepository.Verify(s => s.ObterPorId(It.IsAny<int>()), Times.Never);
            _clienteRepository.Verify(s => s.Atualizar(It.IsAny<Cliente>()), Times.Never);
            _clienteRepository.Verify(s => s.BuscarPorNome(It.IsAny<string>()), Times.Never);
            _clienteRepository.Verify(s => s.ObterTodos(), Times.Once);
        }

        [Fact(DisplayName = "ObterClientesEspeciais >> Should Sucess >> When Getting All Clientes Especiais From Database")]
        public void ObterClientesEspeciais_ShouldSucess_WhenGettingAllClientesEspeciaisFromDatabase()
        {
            _clienteService.ObterClientesEspeciais();

            _clienteRepository.Verify(s => s.Adicionar(It.IsAny<Cliente>()), Times.Never);
            _clienteRepository.Verify(s => s.Remover(It.IsAny<Cliente>()), Times.Never);
            _clienteRepository.Verify(s => s.ObterPorId(It.IsAny<int>()), Times.Never);
            _clienteRepository.Verify(s => s.Atualizar(It.IsAny<Cliente>()), Times.Never);
            _clienteRepository.Verify(s => s.BuscarPorNome(It.IsAny<string>()), Times.Never);
            _clienteRepository.Verify(s => s.ObterTodos(), Times.Once);
        }
    }
}