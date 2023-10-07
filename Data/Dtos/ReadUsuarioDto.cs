namespace FilmesAPI.Data.Dtos
{
    public class ReadUsuarioDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public bool? IsAdmin { get; set; }
    }
}
