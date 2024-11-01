using System.ComponentModel.DataAnnotations;
using TestUnit.Interface;

namespace TestUnit.Service;

public class PedidoService: IPedidoService
{
    private readonly List<Pedido> _pedidos;

    public PedidoService(List<Pedido> pedidos)
    {
        _pedidos = pedidos;
    }


    public void Adicionar(Pedido pedido)
    {
        var validationResults = new List<ValidationResult>();
        var validationContext = new ValidationContext(pedido, null, null);

        // Validação do pedido usando DataAnnotations
        if (!Validator.TryValidateObject(pedido, validationContext, validationResults, true))
        {
            string errorMessage = string.Join("; ", validationResults.Select(e => e.ErrorMessage));
            throw new ArgumentException(errorMessage);
        }

        _pedidos.Add(pedido);
      
    }

    public IEnumerable<Pedido> ObterPedidos()
    {
       return _pedidos;
    }
}