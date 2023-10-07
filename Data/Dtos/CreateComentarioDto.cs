using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos
{
    public class CreateComentarioDto
    {
        [Required]
        public string Conteudo { get; set; }

        [Required]
        public int FilmeId { get; set; }

        [Required]
        public int UsuarioId { get; set; }

        public DateTime? Date { get; set; }
    }
}
