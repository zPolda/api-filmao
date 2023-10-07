using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos
{
    public class UpdateAvaliacaoDto
    {
        [Required]
        public int Nota { get; set; }

        [Required]
        public int FilmeId { get; set; }

        [Required]
        public int UsuarioId { get; set; }
    }
}
