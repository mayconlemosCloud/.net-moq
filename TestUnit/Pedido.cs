using System.ComponentModel.DataAnnotations;

namespace TestUnit;

public class Pedido
{
    
    public Guid Id { get; set; } = Guid.NewGuid();
    
    [Required(ErrorMessage = "O nome do produto é obrigatório.")]
    [StringLength(100, ErrorMessage = "O nome do produto deve ter entre 1 e 100 caracteres.", MinimumLength = 1)]
    public string Produto { get; set; } = string.Empty;
    
    [Range(0.01, double.MaxValue, ErrorMessage = "O valor do produto deve ser maior que zero.")]
    public Double Valor { get; set; }
    
    [Required(ErrorMessage = "A data do pedido é obrigatória.")]
    public DateTime Data { get; set; }
    
    
    public override string ToString()
    {
        return $"ID: {Id}, Produto: {Produto}, Data: {Data}, Valor: {Valor:C}";
    }
}