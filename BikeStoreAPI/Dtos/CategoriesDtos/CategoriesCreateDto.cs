﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BikeStoreAPI.Dtos.CategoriesDtos
{
    public class CategoriesCreateDto
    {
        //public int CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; }
    }
}
