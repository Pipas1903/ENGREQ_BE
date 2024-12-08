﻿namespace AMAP_FARM.Models
{
    public class Producer
    {
        public int Id { get; set; }
        public required int UserId { get; set; }
        public required string FarmName { get; set; }
        public required string Location { get; set; }
        public required string ContactNumber { get; set; }
    }
}
