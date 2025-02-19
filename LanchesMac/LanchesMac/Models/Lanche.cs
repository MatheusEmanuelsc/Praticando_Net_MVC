namespace LanchesMac.Models;

public class Lanche
{
    public int LanchesId { get; set; }
    public string Nome { get; set; }= string.Empty;
    public string DescricaoCurta { get; set; } = string.Empty;
    public string DescricaoDetalhada { get; set; } = string.Empty;
    public decimal Preco { get; set; }

    public string ImagemUrl { get; set; } = string.Empty;
    public string ImagemThumbnailUrl { get; set; } = string.Empty;
    
    public bool IsLachePrefeirodo { get; set; }
    public bool EmEstoque { get; set; }
    
    public int CategoriaId { get; set; }
    public virtual Categoria Categoria { get; set; }
    
}