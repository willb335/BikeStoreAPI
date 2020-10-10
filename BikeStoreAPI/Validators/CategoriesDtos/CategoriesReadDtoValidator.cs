using BikeStoreAPI.Dtos.CategoriesDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeStoreAPI.Validators.CategoriesDtos
{
    
        public class CategoriesReadDtoValidator : AbstractValidator<CategoriesReadDto>
        {

            public CategoriesReadDtoValidator()
            {
            RuleFor(x => x.CategoryId).NotNull();
            RuleFor(x => x.CategoryName).NotNull();
            }

        }
    
}
