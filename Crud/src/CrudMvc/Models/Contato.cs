using System.ComponentModel.DataAnnotations;

namespace CrudMvc.Models;

public class Contato
{
    public int ContatoId { get; set; }
    
    [Required(ErrorMessage = "O nome é obrigatório.")]
    [StringLength(50,ErrorMessage = "O nome deve ter no maximo 50 caracteres.")]
    public string Nome { get; set; } = string.Empty;
    
    [Phone]
    [StringLength(15, MinimumLength = 10, ErrorMessage = "O número de telefone deve ter entre 10 e 15 caracteres.")]
    [Required(ErrorMessage = "O numero do telefone é obrigatório.")]
    public string Telefone { get; set; } =string.Empty;
    
    [EmailAddress]
    [StringLength(30)]
    [Required(ErrorMessage = "O Email é obrigatório.")]
    public string Email { get; set; }= string.Empty;

    public DateTime DataCriacao { get; set; } = DateTime.Now;
   
    
}