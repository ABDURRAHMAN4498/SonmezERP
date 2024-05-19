using AutoMapper;
using SonmezERP.Dtos;
using SonmezERP.Models;
namespace SonmezERP.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserDtoForUpdate,AppUser>().ReverseMap();
        }
    }
}
