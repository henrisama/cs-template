using CSTemplate.Auto;
using CSTemplate.DTOs;
using CSTemplate.Schemas;
namespace CSTemplate.Services;

public class UserService : AutoService<UserSchema, CreateUserDto, UpdateUserDto>
{
  public UserService(IAutoRepository<UserSchema, CreateUserDto, UpdateUserDto> repository) : base(repository) { }

  public override async Task<UserSchema?> Create(CreateUserDto obj)
  {
    obj.Password = PasswordService.HashPassword(obj.Password);
    return await _repository.Create(obj);
  }

  public override async Task<UserSchema?> Update(int id, UpdateUserDto obj)
  {
    if (obj.Password != null)
    {
      obj.Password = PasswordService.HashPassword(obj.Password);
    }
    return await _repository.Update(id, obj);
  }

  public async Task<UserSchema?> GetUserByEmail(string email)
  {
    return await _repository.GetByProperty(user => user.Email == email);
  }
}
