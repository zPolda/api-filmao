using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos
{
    public class CreateCinemaDto
    {
        [Required(ErrorMessage = "O Campo de nome é obrigatório.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O Campo de endereco é obrigatório")]
        public int EnderecoId { get; set; }
    }
}
