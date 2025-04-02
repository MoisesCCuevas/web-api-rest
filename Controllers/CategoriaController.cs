using Microsoft.AspNetCore.Mvc;
using web_api_rest.Models;

namespace web_api_rest;

[ApiController]
[Route("api/[controller]")]
public class CategoriaController : Controller {

    ICategoriaService _categoriaService;

    public CategoriaController(ICategoriaService categoriaService) {
        _categoriaService = categoriaService;
    }

    [HttpGet]
    public IActionResult Get() {
      return Ok(_categoriaService.Get());
    }

    [HttpPost]
    public IActionResult Post([FromBody]Categoria categoria) {
      _categoriaService.Save(categoria);
      return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody]Categoria categoria) {
      _categoriaService.Update(categoria, id);
      return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id) {
      _categoriaService.Delete(id);
      return Ok();
    }
}