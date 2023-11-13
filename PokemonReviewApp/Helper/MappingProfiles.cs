﻿using AutoMapper;
using PokemonReviewApp.Dto;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Pokemon, PokemonDto>()
                .ReverseMap();

            CreateMap<Category, CategoryDto>()
                .ReverseMap();

            CreateMap<Owner, OwnerDto>()
                .ReverseMap();

            CreateMap<Country, OwnerDto>()
                .ReverseMap();

            CreateMap<Review, ReviewDto>()
                .ReverseMap();

            CreateMap<Reviewer, ReviewerDto>()
                .ReverseMap();
        }
    }
}
