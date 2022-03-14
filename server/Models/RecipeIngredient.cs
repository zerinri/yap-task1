﻿namespace server.Models
{
    public class RecipeIngredient
    {
        public int Id { get; set; }
        public UnitMeasure UnitMeasure { get; set; }
        public decimal Quantity { get; set; }

        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }
        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }


    }
}
