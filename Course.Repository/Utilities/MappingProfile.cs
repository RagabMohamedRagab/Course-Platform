using AutoMapper;
using Course.Domain.Domains;
using Course.Repository.ViewModeles;

public class MappingProfile : Profile {
    public MappingProfile()
    {
        CreateMap<Title, TitleFormViewModel>().ReverseMap();
    }
}