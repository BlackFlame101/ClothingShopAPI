﻿namespace ClothingShopAPI.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public Item Item { get; set; } = new Item();
    }
}
