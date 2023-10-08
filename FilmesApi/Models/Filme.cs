 using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models;

public class Filme
{

    [Key]
    [Required]
    public int Id { get; set; }
    
    public string Titulo { get; set; }
    
    public string Genero { get; set; }
    
    public int Duracao { get; set; }

    public virtual ICollection<Sessao> Sessoes { get; set; }

    public virtual ICollection<Comentario> Comentarios { get; set; }

    public virtual ICollection<Avaliacao> Avaliacao { get; set; }

}
