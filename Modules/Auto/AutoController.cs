using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CSTemplate.Auto;

public interface IAutoController<T, CreateDto, UpdateDto>
{
  Task<IActionResult> GetAll();
  Task<IActionResult> GetById(int id);
  Task<IActionResult> Create(CreateDto obj);
  Task<IActionResult> Update(int id, UpdateDto obj);
  Task<IActionResult> Delete(int id);
}

public class AutoController<T, CreateDto, UpdateDto> : ControllerBase, IAutoController<T, CreateDto, UpdateDto> where T : class
{
  private readonly IAutoService<T, CreateDto, UpdateDto> _service;

  public AutoController(IAutoService<T, CreateDto, UpdateDto> service)
  {
    _service = service;
  }

  [HttpGet]
  [SwaggerResponse(200, "Returns all items")]
  public virtual async Task<IActionResult> GetAll()
  {
    var entities = await _service.GetAll();
    return Ok(entities);
  }

  [HttpGet("{id}")]
  [SwaggerResponse(200, "Returns the item with the specified ID")]
  [SwaggerResponse(404, "Item not found")]
  public virtual async Task<IActionResult> GetById([FromRoute] int id)
  {
    var entity = await _service.GetById(id);
    if (entity == null)
    {
      return NotFound();
    }
    return Ok(entity);
  }

  [HttpPost]
  [SwaggerResponse(201, "Item created successfully")]
  public virtual async Task<IActionResult> Create(CreateDto obj)
  {
    var entity = await _service.Create(obj);
    return CreatedAtAction(nameof(GetById), new { id = entity }, entity);
  }

  [HttpPut("{id}")]
  [SwaggerResponse(200, "Item updated successfully")]
  [SwaggerResponse(404, "Item not found")]
  public virtual async Task<IActionResult> Update([FromRoute] int id, UpdateDto obj)
  {
    var entity = await _service.Update(id, obj);
    if (entity == null)
    {
      return NotFound();
    }
    return Ok(entity);
  }

  [HttpDelete("{id}")]
  [SwaggerResponse(200, "Item deleted successfully")]
  [SwaggerResponse(404, "Item not found")]
  public virtual async Task<IActionResult> Delete([FromRoute] int id)
  {
    var entity = await _service.Delete(id);
    if (entity == null)
    {
      return NotFound();
    }
    return Ok(entity);
  }
}