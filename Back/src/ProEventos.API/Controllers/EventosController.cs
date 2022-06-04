using Microsoft.AspNetCore.Mvc;
using ProEventos.Domain;
using ProEventos.Application.Contratos;

namespace ProEventos.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventosController : ControllerBase
{
    private readonly IEventosService _eventoService;
    public EventosController(IEventosService eventoService)
    {
        _eventoService = eventoService;
    }
    //Retorna todos os Eventos 
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var eventos = await _eventoService.GetAllEventosAsync(true);
            if (eventos == null)
            {
                return NotFound("Nenhum Evento Encontrado");
            }

            return Ok(eventos);

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            var evento = await _eventoService.GetAllEventoByIdAsync(id, true);
            if (evento == null)
            {
                return NotFound("Evento não Encontrados");
            }

            return Ok(evento);

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    [HttpGet("tema/{tema}")]
    public async Task<IActionResult> GetByTema(string tema)
    {
        try
        {
            var eventos = await _eventoService.GetAllEventosByTemaAsync(tema, true);
            if (eventos == null)
            {
                return NotFound("Evento não Encontrados");
            }

            return Ok(eventos);

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    [HttpPost]
    public async Task<IActionResult> Post(Evento model)
    {
        try
        {
            var evento = await _eventoService.AddEvento(model);
            if (evento == null)
            {
                return BadRequest("Erro ao tentar adiconar");
            }

            return Ok(evento);

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Evento model)
    {
        try
        {
            var evento = await _eventoService.UpdateEvento(id, model);
            if (evento == null)
            {
                return BadRequest("Erro ao tentar adiconar");
            }

            return Ok(evento);

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
           return (await _eventoService.DeleteEvento(id))? Ok(): BadRequest("Erro ao excluir Evento");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}

