using web_api_rest.Models;

namespace web_api_rest;

public class CategoriaService : ICategoriaService {
    TareasContext _context;

    public CategoriaService(TareasContext context) {
       _context = context;
    }

    public IEnumerable<Categoria> Get() {
      return _context.Categorias;
    }

    public async Task Save(Categoria categoria) {
      _context.Add(categoria);
      await _context.SaveChangesAsync();
    }

    public async Task Update(Categoria categoria, Guid id) {
      Categoria _categoria = await _context.Categorias.FindAsync(id);
      if (_categoria == null) {
        throw new Exception("Categoria no encontrada");
      }
      _categoria.Nombre = categoria.Nombre;
      _categoria.Descripcion = categoria.Descripcion;
      _categoria.Peso = categoria.Peso;
      _context.Update(_categoria);
      await _context.SaveChangesAsync();
    }

    public async Task Delete(Guid id) {
      Categoria categoria = await _context.Categorias.FindAsync(id);
      if (categoria == null) {
        throw new Exception("Categoria no encontrada");
      }
      _context.Remove(categoria);
      await _context.SaveChangesAsync();
    }
}

public interface ICategoriaService {
    IEnumerable<Categoria> Get();
    Task Save(Categoria categoria);
    Task Update(Categoria categoria, Guid id);
    Task Delete(Guid id);
}