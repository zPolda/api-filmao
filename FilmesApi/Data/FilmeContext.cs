using FilmesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesAPI.Data;

public class FilmeContext : DbContext

{
    public FilmeContext(DbContextOptions<FilmeContext> opts) : base(opts)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Endereco>().HasOne(endereco => endereco.Cinema).WithOne(cinema => cinema.Endereco).OnDelete(DeleteBehavior.Restrict);
    }

    public DbSet<Filme> Filmes { get; set; }
    public DbSet<Cinema> Cinemas { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }
    public DbSet<Sessao> Sessoes { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Avaliacao> Avaliacoes { get; set; }
    public DbSet<Comentario> Comentarios { get; set; }


}
