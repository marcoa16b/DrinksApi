using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text.Json.Serialization;

namespace DrinksAPI.Models
{
    public class Drink
    {
        public int Id { get; set; }
        
        [Required]
        public string Description { get; set; }
        
        [Required]
        public string Size { get; set; }
        
        [Required]
        public string CountryOfOrigin { get; set; }
        
        public List<DrinkType> DrinkTypes { get; set; } = new List<DrinkType>();
    }
}
