using AutoMapper;
using BikeStoreAPI.Dtos.CategoriesDtos;
using BikeStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeStoreAPI.Profiles
{
    public class CategoriesProfile : Profile
    {

        public CategoriesProfile()
        {
            // Source -> Target
            CreateMap<Categories, CategoriesReadDto>();
            CreateMap<CategoriesCreateDto, Categories>();
            CreateMap<CategoriesUpdateDto, Categories>();
            CreateMap<Categories, CategoriesUpdateDto>();



        }

    }
}
