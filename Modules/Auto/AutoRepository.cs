using System.Linq.Expressions;
using AutoMapper;
using CSTemplate.Data;
using Microsoft.EntityFrameworkCore;

namespace CSTemplate.Auto;

public interface IAutoRepository<T, CreateDto, UpdateDto> where T : class
{
  Task<IEnumerable<T>> GetAll();
  Task<T?> GetById(int id);
  Task<T?> Create(CreateDto obj);
  Task<T?> Update(int id, UpdateDto obj);
  Task<T?> Delete(int id);
  Task<T?> GetByProperty(Expression<Func<T, bool>> expression);
}

public class AutoRepository<T, CreateDto, UpdateDto> : IAutoRepository<T, CreateDto, UpdateDto> where T : class
{
  protected readonly AppDbContext _context;
  protected readonly DbSet<T> _dbSet;
  protected readonly IMapper _mapper;

  public AutoRepository(AppDbContext context, IMapper mapper)
  {
    _mapper = mapper;
    _context = context;
    _dbSet = context.Set<T>();
  }

  public virtual async Task<IEnumerable<T>> GetAll()
  {
    return await _dbSet.ToListAsync();
  }

  public virtual async Task<T?> GetById(int id)
  {
    return await _dbSet.FindAsync(id);
  }

  public virtual async Task<T?> Create(CreateDto obj)
  {
    var result = await _dbSet.AddAsync(_mapper.Map<T>(obj));
    await _context.SaveChangesAsync();
    return result.Entity;
  }

  public virtual async Task<T?> Update(int id, UpdateDto obj)
  {
    var entity = await _dbSet.FindAsync(id);

    if (entity == null)
      return null;

    _mapper.Map(obj, entity);
    await _context.SaveChangesAsync();
    return entity;
  }

  public virtual async Task<T?> Delete(int id)
  {
    T? entity = await _dbSet.FindAsync(id);

    if (entity == null)
      return null;

    _dbSet.Remove(entity);
    await _context.SaveChangesAsync();
    return entity;
  }

  public virtual async Task<T?> GetByProperty(Expression<Func<T, bool>> expression)
  {
    return await _dbSet.FirstOrDefaultAsync(expression);
  }
}