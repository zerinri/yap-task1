﻿namespace server.Dtos.Recipe
{
    public class GetTotalCostDto
    {
        public decimal BaseQuantity { get; set; }
        public decimal UsedQuantity { get; set; }
        public decimal Price { get; set; }
    }
}
