//using AutoBogus;
//using AutoMapper;
//using FluentAssertions;
//using Moq;
//using Xunit;

//namespace UnitTests
//{
//    public class ClientServiceTests
//    {
//        private readonly Mock<IMapper> _mapper;
//        private readonly Mock<IClienteRepository> _clienteRepository;
//        private readonly ClienteService _clienteService;
//        public ClientServiceTests()
//        {
//            _mapper = new Mock<IMapper>();
//            _clienteRepository = new Mock<IClienteRepository>();
//            _clienteService = new ClienteService(_clienteRepository.Object);
//        }
//        [Fact(DisplayName = "Mapper.Map >> Should Sucess >> When Mapping Produto To ProdutoViewModel")]
//        public void Teste()
//        {
//            var produto = new AutoFaker<Produto>().Generate();


//            var produtoViewModel = new ProdutoViewModel()
//            {
//                Cliente = new ClienteViewModel()
//                {
//                    Ativo = true,
//                    ClienteId = produto.Cliente.ClienteId,
//                    DataCadastro = produto.Cliente.DataCadastro,
//                    Email = produto.Cliente.Email,
//                    Nome = produto.Cliente.Nome,
//                    Sobrenome = produto.Cliente.Sobrenome,
//                },
//                ClienteId = produto.ClienteId,
//                Disponivel = produto.Disponivel,
//                Nome = produto.Nome,
//                ProdutoId = produto.ProdutoId,
//                Valor = produto.Valor
//            };

//            _mapper.Setup(s => s.Map<Produto, ProdutoViewModel>(It.IsAny<Produto>())).Returns(produtoViewModel);

//            produto.Should().BeEquivalentTo(produtoViewModel);
//        }
//    }
//}