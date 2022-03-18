using server.Dtos.Ingredient;
using System.Collections.Generic;

namespace server.Dtos.Recipe
{
    public class GetRecipeById
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public decimal TotalCost { get; set; }

    }
}
