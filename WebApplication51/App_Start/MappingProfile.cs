using AutoMapper;
using WebApplication51.Dtos;
using WebApplication51.Models;

namespace WebApplication51.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Dto
            CreateMap<Studente, StudenteDto>();
           
            CreateMap<StudenteDetail, StudenteDetailDto>();
           


            // Dto to Domain
            CreateMap<StudenteDto, Studente>()
                .ForMember(c => c.Id, opt => opt.Ignore());

        }
    }
}