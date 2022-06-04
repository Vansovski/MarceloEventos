using ProEventos.Application.Contratos;
using ProEventos.Domain;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Application;
public class EventoService : IEventosService
{

    private readonly IGeralPersistence _geralPersistence;
    private readonly IEventosPersistence _eventosPersistence;


    public EventoService(IGeralPersistence geralPersistence, IEventosPersistence eventosPersistence)
    {
        _geralPersistence = geralPersistence;
        _eventosPersistence = eventosPersistence;
    }


    public async Task<Evento> AddEvento(Evento model)
    {
        try
        {
            _geralPersistence.Add<Evento>(model);

            if (await _geralPersistence.SaveChangesAsync())
            {
                return await _eventosPersistence.GetAllEventoByIdAsync(model.Id, false);
            }

            return null;
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }
    public async Task<Evento> UpdateEvento(int idEvento, Evento model)
    {
        try
        {
            var evento = await _eventosPersistence.GetAllEventoByIdAsync(idEvento, false);
            if (evento == null)
            {
                return null;
            }

            model.Id = evento.Id;

            _geralPersistence.Update<Evento>(model);

            if (await _geralPersistence.SaveChangesAsync())
            {
                return await _eventosPersistence.GetAllEventoByIdAsync(model.Id, false);
            }

            return null;

        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

    public async Task<bool> DeleteEvento(int idEvento)
    {
        try
        {
            var evento = await _eventosPersistence.GetAllEventoByIdAsync(idEvento, false);

            if (evento == null) throw new Exception("Evento não Encontrado");

            _geralPersistence.Delete<Evento>(evento);

            return await _geralPersistence.SaveChangesAsync();

        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }
    //Persistence
    public async Task<Evento[]> GetAllEventosAsync(bool includePalestrante = false)
    {
        try
        {
            var eventos = await _eventosPersistence.GetAllEventosAsync(includePalestrante);
            if (eventos == null) return null;

            return eventos;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrante = false)
    {
        try
        {
            var eventos = await _eventosPersistence.GetAllEventosByTemaAsync(tema, includePalestrante);
            if (eventos == null) return null;

            return eventos;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    public async Task<Evento> GetAllEventoByIdAsync(int eventoId, bool includePalestrante = false)
    {
        try
        {
            var evento = await _eventosPersistence.GetAllEventoByIdAsync(eventoId,includePalestrante);
            if (evento == null) return null;

            return evento;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
