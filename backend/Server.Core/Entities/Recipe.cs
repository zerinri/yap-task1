using System.Collections.Generic;

namespace Server.Core.Entities
{
    public class Recipe : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public List<RecipeIngredient> RecipeIngredients { get; set; }

    }
}