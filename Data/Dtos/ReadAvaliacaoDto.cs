namespace FilmesAPI.Data.Dtos
{
    public class ReadAvaliacaoDto
    {
        public int Id { get; set; }
        public int Nota { get; set; }
        public int FilmeId { get; set; }
        public int UsuarioId { get; set; }
        public string NomeFilme { get; set; } 
        public string NomeUsuario { get; set; } 
    }
}
