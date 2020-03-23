using AutoMapper;
using HeldNodig.Dtos;
using HeldNodig.Entities.HelpRequest;

namespace HeldNodig.Mapping.Profiles
{
    public class HelpRequestProfile : Profile
    {
        public HelpRequestProfile()
        {
            CreateMap<HelpRequestDto, HelpRequest>();
        }
    }
}