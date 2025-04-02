using web_api_rest.Models;

namespace web_api_rest;

public class TareasService : ITareasService {
  TareasContext _context;

  public TareasService(TareasContext context) {
    _context = context;
  }

  public IEnumerable<Tarea> Get() {
    return _context.Tareas;
  }

  public async Task Save(Tarea tarea) {
    _context.Add(tarea);
    await _context.SaveChangesAsync();
  }

  public async Task Update(Tarea tarea, Guid id) {
    Tarea _tarea = await _context.Tareas.FindAsync(id);
    if (_tarea == null) {
    throw new Exception("Tarea no encontrada");
    }
    _tarea.CategoriaId = tarea.CategoriaId;
    _tarea.Descripcion = tarea.Descripcion;
    _tarea.FechaCreacion = tarea.FechaCreacion;
    _tarea.PrioridadTarea = tarea.PrioridadTarea;
    _tarea.Resumen = tarea.Resumen;
    _tarea.Titulo = tarea.Titulo;
    _context.Update(_tarea);
    await _context.SaveChangesAsync();
  }

  public async Task Delete(Guid id) {
    Tarea tarea = await _context.Tareas.FindAsync(id);
    if (tarea == null) {
      throw new Exception("Tarea no encontrada");
    }
    _context.Remove(tarea);
    await _context.SaveChangesAsync();
  }
}

public interface ITareasService {
  IEnumerable<Tarea> Get();
  Task Save(Tarea tarea);
  Task Update(Tarea tarea, Guid id);
  Task Delete(Guid id);
}
