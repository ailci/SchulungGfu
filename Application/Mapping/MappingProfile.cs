﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModels.Author;
using Application.ViewModels.Qotd;
using Application.ViewModels.Quote;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Quote, QuoteOfTheDayViewModel>();
        CreateMap<Author, AuthorViewModel>();

        CreateMap<Quote, QuoteViewModel>()
            .ForMember(dest => dest.AuthorName, opt =>
            {
                opt.PreCondition(c => c.Author is not null);
                opt.MapFrom(src => src.Author!.Name);
            });

        CreateMap<AuthorForCreateViewModel, Author>()
            .ForMember(dest => dest.Photo, opt => opt.Ignore())
            .ForMember(dest => dest.PhotoMimeType, opt => opt.Ignore());
    }
}