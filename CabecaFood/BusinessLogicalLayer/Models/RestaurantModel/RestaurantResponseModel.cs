﻿namespace BusinessLogicalLayer.Models.RestaurantModel
{
    public class RestaurantResponseModel : RestaurantRequestModel
    {
        public int Id { get; set; }
        public int AddressId { get; set; }
        public string ImagePath { get; set; }
    }
}
