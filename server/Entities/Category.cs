using System.Collections.Generic;

namespace server.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Recipe> Recipes { get; set; }
    }
}
