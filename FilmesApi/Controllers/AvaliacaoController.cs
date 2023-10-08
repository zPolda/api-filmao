using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AvaliacaoController : ControllerBase
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public AvaliacaoController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaAvaliacao([FromBody] CreateAvaliacaoDto avaliacaoDto)
        {
            Avaliacao avaliacao = _mapper.Map<Avaliacao>(avaliacaoDto);
            _context.Avaliacoes.Add(avaliacao);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaAvaliacoesPorId), new { Id = avaliacao.Id }, avaliacaoDto);
        }

        [HttpGet]
        public IEnumerable<ReadAvaliacaoDto> RecuperaAvaliacoes()
        {
            var avaliacoes = _context.Avaliacoes.ToList();
            return _mapper.Map<List<ReadAvaliacaoDto>>(avaliacoes);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaAvaliacoesPorId(int id)
        {
            Avaliacao avaliacao = _context.Avaliacoes.FirstOrDefault(avaliacao => avaliacao.Id == id);
            if (avaliacao != null)
            {
                ReadAvaliacaoDto avaliacaoDto = _mapper.Map<ReadAvaliacaoDto>(avaliacao);
                return Ok(avaliacaoDto);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaAvaliacao(int id, [FromBody] UpdateAvaliacaoDto avaliacaoDto)
        {
            Avaliacao avaliacao = _context.Avaliacoes.FirstOrDefault(avaliacao => avaliacao.Id == id);
            if (avaliacao == null)
            {
                return NotFound();
            }
            _mapper.Map(avaliacaoDto, avaliacao);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult AtualizaAvaliacaoParcial(int id, JsonPatchDocument<UpdateAvaliacaoDto> patch)
        {
            var avaliacao = _context.Avaliacoes.FirstOrDefault(a => a.Id == id);
            if (avaliacao == null) return NotFound();

            var avaliacaoParaAtualizar = _mapper.Map<UpdateAvaliacaoDto>(avaliacao);

            patch.ApplyTo(avaliacaoParaAtualizar, ModelState);

            if (!TryValidateModel(avaliacaoParaAtualizar))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(avaliacaoParaAtualizar, avaliacao);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaAvaliacao(int id)
        {
            Avaliacao avaliacao = _context.Avaliacoes.FirstOrDefault(avaliacao => avaliacao.Id == id);
            if (avaliacao == null)
            {
                return NotFound();
            }
            _context.Remove(avaliacao);
            _context.SaveChanges();
            return NoContent();
        }
    }
}