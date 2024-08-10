﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DrinksAPI.Models
{
    public class DrinkType
    {
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
