using AutoMapper;
using Course.Domain.Domains;
using Course.Repository.ViewModeles;
namespace Course.Service.Utilities {
    public class MappingProfile : Profile {
        public MappingProfile()
        {
            CreateMap<Title, TitleFormViewModel>().ReverseMap();
            CreateMap<Title, TitlesViewModel>().ReverseMap();
            CreateMap<Title, TitleDropDownListViewModel>().ReverseMap();
            CreateMap<Title, UpdateTitleViewModel>().ReverseMap();
            CreateMap<CourseFormViewModel, Course.Domain.Domains.Course>().ReverseMap();
            CreateMap<CoursesViewModel, Course.Domain.Domains.Course>().ReverseMap();
            CreateMap<VideoByIdViewModel, Course.Domain.Domains.Course>().ReverseMap();
        }
    }
}