﻿using AutoMapper;
using Course.Domain.Domains;
using Course.Repository.ViewModeles;
namespace Course.Service.Utilities {
    public class MappingProfile : Profile {
        public MappingProfile()
        {
            CreateMap<Title, TitleFormViewModel>().ReverseMap();
        }
    }
}