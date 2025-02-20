using System.ComponentModel.DataAnnotations;

namespace LanchesMac.Models;

public class Categoria
{
    
    public int CategoriaId { get; set; }
    [StringLength(50, MinimumLength = 3,ErrorMessage = "O nome deve ter entre 3 e 50 caracteres")]
    [Required(ErrorMessage = "O nome  é obrigatório.")]
    public string Nome { get; set; } = string.Empty;
    [StringLength(200)]
    public string Descricao { get; set; } = string.Empty;

    public List<Lanche> Lanches { get; set; } = [];
    
}