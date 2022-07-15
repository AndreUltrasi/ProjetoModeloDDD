using AutoBogus;
using Core.Domain.Entities;
using Core.Interfaces.Repositories;
using Core.UseCases;
using FluentAssertions;
using Moq;
using Xunit;

namespace UnitTests
{
    public class ClienteUseCaseTests
    {
        private readonly Mock<IClienteRepository> _clienteRepository;
        private readonly ClienteUseCase _clienteUseCase;
        public ClienteUseCaseTests()
        {
            _clienteRepository = new Mock<IClienteRepository>();
            _clienteUseCase = new ClienteUseCase(_clienteRepository.Object);
        }
        [Fact]
        public void Adicionar_ShouldSucess_WhenAddingClienteToDatabase()
        {
            //Arrange
            var cliente = new AutoFaker<Cliente>().Generate();

            //Act
            var retorno = _clienteUseCase.Adicionar(cliente);

            //Assert
            retorno.Should().Be(true);
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
            //Arrange
            var cliente = new AutoFaker<Cliente>().Generate();

            //Act
            var retorno = _clienteUseCase.Atualizar(cliente);

            //Assert
            retorno.Should().Be(true);
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
            //Arrange
            var cliente = new AutoFaker<Cliente>().Generate();
            _clienteRepository.Setup(s => s.ObterPorId(It.IsAny<int>())).Returns(cliente);

            //Act
            var retorno = _clienteUseCase.Remover(cliente.ClienteId);

            //Assert
            retorno.Should().Be(true);
            _clienteRepository.Verify(s => s.Adicionar(It.IsAny<Cliente>()), Times.Never);
            _clienteRepository.Verify(s => s.Remover(It.IsAny<Cliente>()), Times.Once);
            _clienteRepository.Verify(s => s.ObterPorId(It.IsAny<int>()), Times.Once);
            _clienteRepository.Verify(s => s.Atualizar(It.IsAny<Cliente>()), Times.Never);
            _clienteRepository.Verify(s => s.BuscarPorNome(It.IsAny<string>()), Times.Never);
            _clienteRepository.Verify(s => s.ObterTodos(), Times.Never);
        }

        [Fact(DisplayName = "ObterTodos >> Should Sucess >> When Getting All Clientes From Database")]
        public void ObterTodos_ShouldSucess_WhenGettingAllClientesFromDatabase()
        {
            //Arrange
            var clientes = new AutoFaker<Cliente>().Generate(3);

            _clienteRepository.Setup(s => s.ObterTodos()).Returns(clientes);

            //Act
            var retorno = _clienteUseCase.ObterTodos();

            //Assert
            retorno.Should().BeEquivalentTo(clientes);
            _clienteRepository.Verify(s => s.Adicionar(It.IsAny<Cliente>()), Times.Never);
            _clienteRepository.Verify(s => s.Remover(It.IsAny<Cliente>()), Times.Never);
            _clienteRepository.Verify(s => s.ObterPorId(It.IsAny<int>()), Times.Never);
            _clienteRepository.Verify(s => s.Atualizar(It.IsAny<Cliente>()), Times.Never);
            _clienteRepository.Verify(s => s.BuscarPorNome(It.IsAny<string>()), Times.Never);
            _clienteRepository.Verify(s => s.ObterTodos(), Times.Once);
        }

        [Fact(DisplayName = "ObterClientesEspeciais >> Should Sucess >> When Getting All Clientes Especiais From Database")]
        public void ObterClientesEspeciais_ShouldSucess_WhenGettingAllClientesEspeciaisFromDatabase()
        {
            //Arrange
            var maioresDe18 = DateTime.Now.AddYears(-19);
            var menoresDe18 = DateTime.Now;

            var clientesMaioresDe18 = new AutoFaker<Cliente>()
                            .RuleFor(s => s.DataCadastro, maioresDe18)
                            .RuleFor(s => s.Ativo, true)
                            .Generate(3);

            var clientesMenoresDe18 = new AutoFaker<Cliente>()
                            .RuleFor(s => s.DataCadastro, menoresDe18)
                            .Generate(3);

            var clientes = new List<Cliente>();
            clientes.AddRange(clientesMenoresDe18);
            clientes.AddRange(clientesMaioresDe18);

            _clienteRepository.Setup(s => s.ObterTodos()).Returns(clientes);

            //Act
            var retorno = _clienteUseCase.ObterClientesEspeciais();

            //Assert
            retorno.Should().BeEquivalentTo(clientesMaioresDe18);
            _clienteRepository.Verify(s => s.Adicionar(It.IsAny<Cliente>()), Times.Never);
            _clienteRepository.Verify(s => s.Remover(It.IsAny<Cliente>()), Times.Never);
            _clienteRepository.Verify(s => s.ObterPorId(It.IsAny<int>()), Times.Never);
            _clienteRepository.Verify(s => s.Atualizar(It.IsAny<Cliente>()), Times.Never);
            _clienteRepository.Verify(s => s.BuscarPorNome(It.IsAny<string>()), Times.Never);
            _clienteRepository.Verify(s => s.ObterTodos(), Times.Once);
        }
    }
}