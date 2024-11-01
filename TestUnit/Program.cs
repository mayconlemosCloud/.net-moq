
using TestUnit.Interface;
using TestUnit.Service;

namespace TestUnit;

 
public class Program
{
    public static void Main(string[] args)
    {
        List<Pedido> pedidos = new List<Pedido>();
        IPedidoService pedidoService = new PedidoService(pedidos);
        
        var novoPedido = new Pedido()
        {
            Produto = "ProdutoA",
            Data = DateTime.Now,
            Valor = 32.50
        };
        
        
        pedidoService.Adicionar(novoPedido);

        var lista = pedidoService.ObterPedidos();

        foreach (var item in lista)
        {
            Console.WriteLine(item);
        }
       
    }
}