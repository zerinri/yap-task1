﻿using Server.Common.Entities;
using System.Collections.Generic;

namespace Server.Core.Entities
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal PurchaseQuantity { get; set; }
        public UnitMeasureEnum PurchaseUnitMeasure { get; set; }
        public decimal PurchasePrice { get; set; }

        public List<RecipeIngredient> RecipeIngredients { get; set; }
    }
}