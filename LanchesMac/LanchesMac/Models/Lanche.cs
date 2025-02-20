using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanchesMac.Models;

public class Lanche
{
    
    public int LancheId { get; set; }
    [StringLength(50, MinimumLength = 3,ErrorMessage = "O nome deve ter entre 3 e 50 caracteres")]
    [Required(ErrorMessage = "O nome é obrigatório.")]
    public string Nome { get; set; }= string.Empty;
    [StringLength(50,ErrorMessage = "Deve ter no maximo 50 caracteres")]
    [Display(Name = "Descrição curta")]
    public string DescricaoCurta { get; set; } = string.Empty;
    [StringLength(200,ErrorMessage = "Deve ter no maximo 200 caracteres")]
    [Display(Name = "Descrição longa")]
    public string DescricaoDetalhada { get; set; } = string.Empty;
    
    [Required (ErrorMessage = "O preço é obrigatório.") ]
    [Display(Name="Preço")]
    [Column(TypeName = "decimal(10,2)")]
    [Range(0, 10000, ErrorMessage = "O preço deve ter entre 0 e 10.000.")]
    public decimal Preco { get; set; }

    [StringLength(200,ErrorMessage = "Deve ter no maximo 200 caracteres")]
    public string ImagemUrl { get; set; } = string.Empty;
    [StringLength(200,ErrorMessage = "Deve ter no maximo 200 caracteres")]
    public string ImagemThumbnailUrl { get; set; } = string.Empty;
    [Display(Name = "Preferido?")]
    public bool IsLachePrefeirodo { get; set; }
    [Display(Name = "Em estoque??")]
    public bool EmEstoque { get; set; }
    
    public int CategoriaId { get; set; }
    public virtual Categoria Categoria { get; set; }
    
}