using AutoBogus;
using AutoMapper;
using Core.Domain.Entities;
using Core.Interfaces.Repositories;
using Core.Services;
using FluentAssertions;
using Moq;
using Mvc.Controllers;
using Mvc.Models;
using Xunit;

namespace UnitTests
{
    public class ClientesControllerTests
    {
        private readonly Mock<IMapper> _mapper;
        private readonly Mock<ClienteService> _clienteService;
        private readonly ClientesController _clientesController;
        public ClientesControllerTests()
        {
            _mapper = new Mock<IMapper>();
            _clienteService = new Mock<ClienteService>();
            _clientesController = new ClientesController(_clienteService.Object, _mapper.Object);
        }
        [Fact(DisplayName = "Mapper.Map >> Should Sucess >> When Mapping Produto To ProdutoViewModel")]
        public void ClientesController()
        {
            var produto = new AutoFaker<Produto>().Generate();

            var produtoViewModel = new ProdutoViewModel()
            {
                Cliente = new ClienteViewModel()
                {
                    Ativo = true,
                    ClienteId = produto.Cliente!.ClienteId,
                    DataCadastro = produto.Cliente.DataCadastro,
                    Email = produto.Cliente.Email,
                    Nome = produto.Cliente.Nome,
                    Sobrenome = produto.Cliente.Sobrenome,
                },
                ClienteId = produto.ClienteId,
                Disponivel = produto.Disponivel,
                Nome = produto.Nome,
                ProdutoId = produto.ProdutoId,
                Valor = produto.Valor
            };

            _mapper.Setup(s => s.Map<Produto, ProdutoViewModel>(It.IsAny<Produto>())).Returns(produtoViewModel);

            var retorno = _clientesController.Index();

            produto.Should().BeEquivalentTo(produtoViewModel);
        }
    }
}