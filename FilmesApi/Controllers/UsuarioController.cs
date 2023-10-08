using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
    private  FilmeContext _context;
    private  IMapper _mapper;

    public UsuarioController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AdicionaUsuario([FromBody] CreateUsuarioDto usuarioDto)
    {
        Usuario usuario = _mapper.Map<Usuario>(usuarioDto);
        _context.Usuarios.Add(usuario);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaUsuarioPorId), new { Id = usuario.Id }, usuarioDto);
    }

    [HttpGet]
    public IEnumerable<ReadUsuarioDto> RecuperaUsuarios()
    {
        var usuarios = _context.Usuarios.ToList();
        return _mapper.Map<List<ReadUsuarioDto>>(usuarios);
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaUsuarioPorId(int id)
    {
        Usuario usuario = _context.Usuarios.FirstOrDefault(usuario => usuario.Id == id);
        if (usuario != null)
        {
            ReadUsuarioDto usuarioDto = _mapper.Map<ReadUsuarioDto>(usuario);
            return Ok(usuarioDto);
        }
        return NotFound();
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaUsuario(int id, [FromBody] UpdateUsuarioDto usuarioDto)
    {
        Usuario usuario = _context.Usuarios.FirstOrDefault(usuario => usuario.Id == id);
        if (usuario == null)
        {
            return NotFound();
        }
        _mapper.Map(usuarioDto, usuario);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult AtualizaUsuarioParcial(int id, JsonPatchDocument<UpdateUsuarioDto> patch)
    {
        var usuario = _context.Usuarios.FirstOrDefault(u => u.Id == id);
        if (usuario == null) return NotFound();

        var usuarioParaAtualizar = _mapper.Map<UpdateUsuarioDto>(usuario);

        patch.ApplyTo(usuarioParaAtualizar, ModelState);

        if (!TryValidateModel(usuarioParaAtualizar))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(usuarioParaAtualizar, usuario);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletaUsuario(int id)
    {
        Usuario usuario = _context.Usuarios.FirstOrDefault(usuario => usuario.Id == id);
        if (usuario == null)
        {
            return NotFound();
        }
        _context.Remove(usuario);
        _context.SaveChanges();
        return NoContent();
    }
}
