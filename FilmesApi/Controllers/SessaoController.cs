using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Data;
using FilmesAPI.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessaoController : ControllerBase
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public SessaoController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaSessao(CreateSessaoDto dto)
        {
            Sessao sessao = _mapper.Map<Sessao>(dto);
            _context.Sessoes.Add(sessao);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaSessaoPorId), new { id = sessao.Id }, dto);
        }

        [HttpGet]
        public IEnumerable<ReadSessaoDto> RecuperaSessoes()
        {
            return _mapper.Map<List<ReadSessaoDto>>(_context.Sessoes.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaSessaoPorId(int id)
        {
            Sessao sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.Id == id);
            if (sessao != null)
            {
                ReadSessaoDto sessaoDto = _mapper.Map<ReadSessaoDto>(sessao);
                return Ok(sessaoDto);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaSessao(int id, [FromBody] UpdateSessaoDto sessaoDto)
        {
            Sessao sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.Id == id);
            if (sessao == null)
            {
                return NotFound();
            }
            _mapper.Map(sessaoDto, sessao);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult AtualizaSessaoParcial(int id, JsonPatchDocument<UpdateSessaoDto> patch)
        {
            var sessao = _context.Sessoes.FirstOrDefault(s => s.Id == id);
            if (sessao == null) return NotFound();

            var sessaoParaAtualizar = _mapper.Map<UpdateSessaoDto>(sessao);

            patch.ApplyTo(sessaoParaAtualizar, ModelState);

            if (!TryValidateModel(sessaoParaAtualizar))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(sessaoParaAtualizar, sessao);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaSessao(int id)
        {
            Sessao sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.Id == id);
            if (sessao == null)
            {
                return NotFound();
            }
            _context.Remove(sessao);
            _context.SaveChanges();
            return NoContent();
        }
    }
}