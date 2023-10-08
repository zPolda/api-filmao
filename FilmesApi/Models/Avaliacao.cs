using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models;

public class Avaliacao
{
    [Key]
    [Required]
    public int Id { get; set; }
    public int Nota { get; set; }
    public int FilmeId { get; set; }
    public virtual Filme Filme { get; set; }
    public int UsuarioId { get; set; }
    public virtual Usuario Usuario { get; set; }
}
