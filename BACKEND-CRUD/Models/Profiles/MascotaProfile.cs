using AutoMapper;
using BACKEND_CRUD.Models.DTO;

namespace BACKEND_CRUD.Models.Profiles
{
    public class MascotaProfile : Profile
    {
        public MascotaProfile() 
        {
            CreateMap<Mascota, MascotaDTO>();
            CreateMap<MascotaDTO, Mascota>();
        }
    }
}
