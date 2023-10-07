using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos
{
    public class UpdateEnderecoDto
    {

        public string Logradouro { get; set; }
        public int Numero { get; set; }
    }
}
