﻿namespace InGreed_API.Models
{
    public class Opinion
    {
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
        public Product Product { get; set; }
        public User User { get; set; }
    }
}
