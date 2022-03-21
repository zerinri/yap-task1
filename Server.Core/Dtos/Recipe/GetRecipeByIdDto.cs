﻿using Server.Core.Dtos.Ingredient;
using System;
using System.Collections.Generic;

namespace Server.Core.Dtos.Recipe
{
    public class GetRecipeByIdDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public decimal TotalCost { get; set; }
        public string CreatedDate { get; set; }

        public IEnumerable<GetIngredientDto> Ingredients { get; set; }


    }
}
