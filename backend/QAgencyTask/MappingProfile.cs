using AutoMapper;
using QAgencyTask.Dtos;
using QAgencyTask.Models;

namespace QAgencyTask
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Email, EmailDto>().ReverseMap();
        }
    }
}
