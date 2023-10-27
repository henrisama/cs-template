using AutoMapper;
using CSTemplate.DTOs;
using CSTemplate.Schemas;

namespace CSTemplate.Auto;

public class AutoMapping : Profile
{
  public AutoMapping()
  {
    CreateMap<CreateUserDto, UserSchema>();
    CreateMap<UpdateUserDto, UserSchema>()
      .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null && !object.Equals(srcMember, GetDefault(srcMember.GetType()))));
    // Add other mappings as needed
  }

  private static object? GetDefault(Type type)
  {
    return type.IsValueType ? Activator.CreateInstance(type) : null;
  }
}
