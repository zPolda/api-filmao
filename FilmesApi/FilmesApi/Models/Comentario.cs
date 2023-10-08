using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models;

public class Comentario
{
    [Key]
    [Required]
    public int Id { get; set; }
    public string Conteudo { get; set; }
    public int FilmeId { get; set; }
    public virtual Filme Filme { get; set; }
    public int UsuarioId { get; set; }
    public virtual Usuario Usuario { get; set; }    
    public DateTime? Date { get; set; }
}
