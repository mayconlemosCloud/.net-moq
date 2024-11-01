using FluentAssertions;
using Moq;
using TestUnit;
using TestUnit.Interface;


namespace Test;

public class PedidoServiceTest
{
    private readonly Mock<IPedidoService> _mockPedidoService;


    public PedidoServiceTest()
    {
        _mockPedidoService = new Mock<IPedidoService>();
    }

    [Fact]
    public void Adicionar_DeveRetornarComValidacao()
    {

        // Arrange
        var produtoInvalido = new Pedido { Produto = "", Valor = 0, Data = DateTime.Now };

        // Configurar mock para lançar exceção
        _mockPedidoService.Setup(p => p.Adicionar(produtoInvalido))
            .Throws(new ArgumentException(
                "O nome do produto é obrigatório; O valor do produto deve ser maior que zero."));

        // Criar PedidoService com o mock
        var pedidoService = _mockPedidoService.Object;

        // Act
        Action action = () => pedidoService.Adicionar(produtoInvalido);

        // Assert
        action.Should().Throw<ArgumentException>()
            .WithMessage("O nome do produto é obrigatório; O valor do produto deve ser maior que zero.");
    }
    
    [Fact]
    public void Adicionar_DeveAdicionarPedidoValido()
    {
        // Arrange
        var produtoValido = new Pedido { Produto = "ProdutoA", Valor = 32.50, Data = DateTime.Now };
        var pedidos = new List<Pedido>();

        // Configurar mock para adicionar pedido à lista
        _mockPedidoService.Setup(p => p.Adicionar(produtoValido))
            .Callback<Pedido>(p => pedidos.Add(p));

        // Configurar mock para retornar a lista de pedidos
        _mockPedidoService.Setup(p => p.ObterPedidos()).Returns(pedidos);

        // Criar PedidoService com o mock
        var pedidoService = _mockPedidoService.Object;

        // Act
        pedidoService.Adicionar(produtoValido);

        // Assert
        pedidoService.ObterPedidos().Should().Contain(produtoValido);
    }
}