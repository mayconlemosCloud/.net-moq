namespace TestUnit.Interface;

public interface IPedidoService
{
    void Adicionar(Pedido pedido);
    IEnumerable<Pedido> ObterPedidos();
}