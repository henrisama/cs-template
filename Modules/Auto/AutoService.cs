using AutoMapper;

namespace CSTemplate.Auto;

public interface IAutoService<T, CreateDto, UpdateDto> where T : class
{
  Task<IEnumerable<T>> GetAll();
  Task<T?> GetById(int id);
  Task<T?> Create(CreateDto obj);
  Task<T?> Update(int id, UpdateDto obj);
  Task<T?> Delete(int id);
}

public class AutoService<T, CreateDto, UpdateDto> : IAutoService<T, CreateDto, UpdateDto> where T : class
{
  protected readonly IAutoRepository<T, CreateDto, UpdateDto> _repository;

  public AutoService(IAutoRepository<T, CreateDto, UpdateDto> repository)
  {
    _repository = repository;
  }

  public virtual async Task<IEnumerable<T>> GetAll()
  {
    return await _repository.GetAll();
  }

  public virtual async Task<T?> GetById(int id)
  {
    return await _repository.GetById(id);
  }

  public virtual async Task<T?> Create(CreateDto obj)
  {
    return await _repository.Create(obj);
  }

  public virtual async Task<T?> Update(int id, UpdateDto obj)
  {
    return await _repository.Update(id, obj);
  }

  public virtual async Task<T?> Delete(int id)
  {
    return await _repository.Delete(id);
  }
}