﻿namespace ECommerce.API.Dtos
{
    public class BaseDto
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}
