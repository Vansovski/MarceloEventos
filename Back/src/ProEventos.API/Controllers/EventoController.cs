using Microsoft.AspNetCore.Mvc;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventoController : ControllerBase
{
    public EventoController()
    {
        
    }

    [HttpGet]
    public IEnumerable<Evento> Get()
    {
       return new Evento[]
       {new Evento(){
           EventoId = 1,
           Tema = "Angular",
           Local = "Belo Horizonte",
           Lote = "1",
           QtdPessoas = 250,
           DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy"),
           ImgURL ="Img/URL"
       },
       new Evento(){
           EventoId = 1,
           Tema = "React",
           Local = "Belo Horizonte",
           Lote = "1",
           QtdPessoas = 50,
           DataEvento = DateTime.Now.AddDays(5).ToString("dd/MM/yyyy"),
           ImgURL ="Img/URL"
       },
       new Evento(){
           EventoId = 1,
           Tema = "Engenharia de Controle e Automação",
           Local = "Belo Horizonte",
           Lote = "1",
           QtdPessoas = 250,
           DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy"),
           ImgURL ="Img/URL"
       }};
    }
}
