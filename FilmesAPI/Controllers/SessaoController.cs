using FilmesAPI.Data.Dtos.Sessao;
using FilmesAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessaoController : ControllerBase
    {
        private SessaoService _sessaoService;

        public SessaoController(SessaoService sessaoService)
        {
            _sessaoService = sessaoService;
        }

        [HttpPost]
        public IActionResult AdicionarSessao([FromBody] CreateSessaoDto dto)
        {
            ReadSessaoDto readDto = _sessaoService.AdicionarSessao(dto);
           
            return CreatedAtAction(nameof(RecuperarSessoesPorId), new { id = readDto.Id }, readDto);

        }

        [HttpGet("{id}")]
        public IActionResult RecuperarSessoesPorId(int id)
        {
            ReadSessaoDto readDto = _sessaoService.RecuperarSessoesPorId(id);

            if (readDto !=  null)
            {
                return Ok(readDto);
            }
            return NotFound();
        }
    }

}