using AutoMapper;
using OpticaService.Models.DTO;

namespace OpticaService.Models.Mapper
{
    public class OpticoProfile : Profile
    {
        public OpticoProfile()
        {
            CreateMap<Optico, OpticoDTO>();
        }
    }
}
