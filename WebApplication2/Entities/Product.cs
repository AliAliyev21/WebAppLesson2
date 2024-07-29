﻿namespace WebApplication2.Entities
{
    public class Product
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Discount {  get; set; }
        public string Image { get; set; }
    }
}
