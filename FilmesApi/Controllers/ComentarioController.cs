﻿using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ComentarioController : ControllerBase
{
    private  FilmeContext _context;
    private  IMapper _mapper;

    public ComentarioController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AdicionaComentario([FromBody] CreateComentarioDto comentarioDto)
    {
        Comentario comentario = _mapper.Map<Comentario>(comentarioDto);
        _context.Comentarios.Add(comentario);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaComentarioPorId), new { Id = comentario.Id }, comentarioDto);
    }

    [HttpGet]
    public IEnumerable<ReadComentarioDto> RecuperaComentarios()
    {
        var comentarios = _context.Comentarios.ToList();
        return _mapper.Map<List<ReadComentarioDto>>(comentarios);
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaComentarioPorId(int id)
    {
        Comentario comentario = _context.Comentarios.FirstOrDefault(comentario => comentario.Id == id);
        if (comentario != null)
        {
            ReadComentarioDto comentarioDto = _mapper.Map<ReadComentarioDto>(comentario);
            return Ok(comentarioDto);
        }
        return NotFound();
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaComentario(int id, [FromBody] UpdateComentarioDto comentarioDto)
    {
        Comentario comentario = _context.Comentarios.FirstOrDefault(comentario => comentario.Id == id);
        if (comentario == null)
        {
            return NotFound();
        }
        _mapper.Map(comentarioDto, comentario);
        _context.SaveChanges();
        return NoContent();
    }
    [HttpPatch("{id}")]
    public IActionResult AtualizaComentarioParcial(int id, JsonPatchDocument<UpdateComentarioDto> patch)
    {
        var comentario = _context.Comentarios.FirstOrDefault(c => c.Id == id);
        if (comentario == null) return NotFound();

        var comentarioParaAtualizar = _mapper.Map<UpdateComentarioDto>(comentario);

        patch.ApplyTo(comentarioParaAtualizar, ModelState);

        if (!TryValidateModel(comentarioParaAtualizar))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(comentarioParaAtualizar, comentario);
        _context.SaveChanges();
        return NoContent();
    }


    [HttpDelete("{id}")]
    public IActionResult DeletaComentario(int id)
    {
        Comentario comentario = _context.Comentarios.FirstOrDefault(comentario => comentario.Id == id);
        if (comentario == null)
        {
            return NotFound();
        }
        _context.Remove(comentario);
        _context.SaveChanges();
        return NoContent();
    }
}