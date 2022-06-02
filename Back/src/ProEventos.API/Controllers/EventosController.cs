using Microsoft.AspNetCore.Mvc;
using ProEventos.API.Models;
using ProEventos.API.Data;

namespace ProEventos.API.Controllers;


[ApiController]
public class EventosController : ControllerBase
{
    //Injeção de dependecia do DbContext
    private readonly DataContext _context;
    public EventosController(DataContext context)
    {
        _context = context;
    }

    //Retorna todos os Eventos 
    [HttpGet]
    public IEnumerable<Evento> Get()
    {
       return _context.Eventos;
    }


    [HttpGet("{id}")]
    public Evento Get(int id)
    {
       return _context.Eventos.FirstOrDefault(evento => evento.EventoId == id);
    }

    [HttpPost]
    public string Post()
    {
       return "Utilizando o Metodo POST";
    }

    
    [HttpDelete]
    public string Delete()
    {
       return "Utilizando o Metodo DELETE";
    }
}

