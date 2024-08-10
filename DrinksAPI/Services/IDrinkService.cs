using DrinksAPI.Models;

namespace DrinksAPI.Services
{
    public interface IDrinkService
    {
        Task<IEnumerable<Drink>> GetAllDrinks();
        Task<Drink> GetDrinkById(int id);
        Task AddDrink(Drink drink);
        Task UpdateDrink(Drink drink);
        Task DeleteDrink(int id);

        Task<IEnumerable<DrinkType>> GetDrinkTypes(int drinkId);
        Task AddDrinkType(int drinkId, DrinkType drinkType);
        Task UpdateDrinkType(int drinkId, DrinkType drinkType);
        Task DeleteDrinkType(int drinkId, int drinkTypeId);


        /*Task<IEnumerable<Drink>> GetDrinksAsync();
        Task<Drink> GetDrinkByIdAsync(int id);
        Task<Drink> CreateDrinkAsync(Drink drink);
        Task UpdateDrinkAsync(int id, Drink drink);
        Task DeleteDrinkAsync(int id);

        Task<IEnumerable<DrinkType>> GetDrinkTypesByDrinkIdAsync(int drinkId);
        Task<DrinkType> AddDrinkTypeToDrinkAsync(int drinkId, DrinkType drinkType);
        Task RemoveDrinkTypeFromDrinkAsync(int drinkId, int drinkTypeId);
        Task UpdateDrinkTypeAsync(int drinkId, int drinkTypeId, DrinkType drinkType);*/
    }
}
