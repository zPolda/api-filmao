using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models;

public class Usuario
{
    [Key]
    [Required]
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public Boolean? IsAdmin { get; set; }
}
