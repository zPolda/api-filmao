namespace FilmesAPI.Data.Dtos
{
    public class ReadComentarioDto
    {
        public int Id { get; set; }
        public string Conteudo { get; set; }
        public DateTime? Date { get; set; }
        public string NomeFilme { get; set; }
        public string NomeUsuario { get; set; }
    }
}
