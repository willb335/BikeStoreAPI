using BikeStoreAPI.Dtos.CategoriesDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeStoreAPI.Validators.CategoriesDtos
{
    public class CategoriesUpdateDtoValidator : AbstractValidator<CategoriesUpdateDto>
    {

        public CategoriesUpdateDtoValidator()
        {
            RuleFor(x => x.CategoryName).NotNull();

        }

    }
}
