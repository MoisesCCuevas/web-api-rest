using Microsoft.AspNetCore.Mvc;
using web_api_rest.Models;

namespace web_api_rest;

[ApiController]
[Route("api/[controller]")]
public class TareaController : Controller {
    ITareasService _tareaService;

    public TareaController(ITareasService tareaService) {
      _tareaService = tareaService;
    }

    [HttpGet]
    public IActionResult Get() {
      return Ok(_tareaService.Get());
    }

    [HttpPost]
    public IActionResult Post([FromBody]Tarea tarea) {
      _tareaService.Save(tarea);
      return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody]Tarea tarea) {
      _tareaService.Update(tarea, id);
      return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id) {
      _tareaService.Delete(id);
      return Ok();
    }
}