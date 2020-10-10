using BikeStoreAPI.Dtos.CategoriesDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeStoreAPI.Validators
{
    public class CategoriesCreateDtoValidator : AbstractValidator<CategoriesCreateDto>
    {
        public CategoriesCreateDtoValidator()
        {
            RuleFor(x => x.CategoryName).NotNull();
        }
    }
}
