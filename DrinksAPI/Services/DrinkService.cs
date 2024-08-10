using DrinksAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Collections.Concurrent;

namespace DrinksAPI.Services
{
    public class DrinkService : IDrinkService
    {
        private readonly List<Drink> _drinks = new();

        public Task AddDrink(Drink drink)
        {
            _drinks.Add(drink);
            return Task.CompletedTask;
        }

        public Task UpdateDrink(Drink drink)
        {
            var existingDrink = _drinks.FirstOrDefault(d => d.Id == drink.Id);
            if (existingDrink != null)
            {
                existingDrink.Description = drink.Description;
                existingDrink.DrinkTypes = drink.DrinkTypes;
                existingDrink.CountryOfOrigin = drink.CountryOfOrigin;
                existingDrink.Size = drink.Size;
            }
            return Task.CompletedTask;
        }

        public Task DeleteDrink(int id)
        {
            var drink = _drinks.FirstOrDefault(d => d.Id == id);
            if (drink != null)
            {
                _drinks.Remove(drink);
            }
            return Task.CompletedTask;
        }

        public Task<IEnumerable<DrinkType>> GetDrinkTypes(int drinkId)
        {
            var drink = _drinks.FirstOrDefault(d => d.Id == drinkId);
            if (drink != null)
            {
                return Task.FromResult(drink.DrinkTypes.AsEnumerable());
            }
            return Task.FromResult(Enumerable.Empty<DrinkType>());
        }

        public Task AddDrinkType(int drinkId, DrinkType drinkType)
        {
            // Add drink type to drink
            var drink = _drinks.FirstOrDefault(d => d.Id == drinkId);
            if (drink != null)
            {
                drink.DrinkTypes.Add(drinkType);
            }
            return Task.CompletedTask;
        }

        public Task DeleteDrinkType(int drinkId, int drinkTypeId)
        {
            // Remove drink type from drink
            var drink = _drinks.FirstOrDefault(d => d.Id == drinkId);
            if (drink != null)
            {
                var drinkType = drink.DrinkTypes.FirstOrDefault(dt => dt.Id == drinkTypeId);
                if (drinkType != null)
                {
                    drink.DrinkTypes.Remove(drinkType);
                }
            }
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Drink>> GetAllDrinks()
        {
            // Return all drinks
            return Task.FromResult(_drinks.AsEnumerable());
        }

        public Task<Drink> GetDrinkById(int id)
        {
            // Return drink by id
            return Task.FromResult(_drinks.FirstOrDefault(d => d.Id == id));
        }

        public Task UpdateDrinkType(int drinkId, DrinkType drinkType)
        {
            // Update drink type
            var drink = _drinks.FirstOrDefault(d => d.Id == drinkId);
            if (drink != null)
            {
                var existingDrinkType = drink.DrinkTypes.FirstOrDefault(dt => dt.Id == drinkType.Id);
                if (existingDrinkType != null)
                {
                    existingDrinkType.Description = drinkType.Description;
                }
            }
            return Task.CompletedTask;
        }
    }
}
