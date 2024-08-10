using DrinksAPI.Models;
using DrinksAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DrinksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrinkController : ControllerBase
    {
        private readonly IDrinkService _drinkService;

        public DrinkController(IDrinkService drinkService)
        {
            _drinkService = drinkService;
        }

        /// <summary>
        /// Obtiene todas las bebidas.
        /// </summary>
        /// <returns>Una lista de todas las bebidas registradas.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Drink>>> GetDrinks()
        {
            var drinks = await _drinkService.GetAllDrinks();
            return Ok(drinks);
        }

        /// <summary>
        /// Obtiene una bebida por su identificador.
        /// </summary>
        /// <returns>La bebida con el identificador especificado.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Drink>> GetDrinkById(int id)
        {
            var drink = await _drinkService.GetDrinkById(id);
            if (drink == null)
            {
                return NotFound();
            }
            return Ok(drink);
        }

        /// <summary>
        /// Agrega una nueva bebida.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult> AddDrink([FromBody] Drink drink)
        {
            await _drinkService.AddDrink(drink);
            return CreatedAtAction(nameof(GetDrinkById), new { id = drink.Id }, drink);
        }

        /// <summary>
        /// Actualiza una bebida.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateDrink(int id, [FromBody] Drink drink)
        {
            if (id != drink.Id)
            {
                return BadRequest();
            }
            await _drinkService.UpdateDrink(drink);
            return Ok();
        }

        /// <summary>
        /// Elimina una bebida.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDrink(int id)
        {
            await _drinkService.DeleteDrink(id);
            return Ok();
        }

        /// <summary>
        /// Obtiene los tipos de bebida de una bebida.
        /// </summary>
        /// <returns>Una lista de los tipos de bebida de la bebida especificada.</returns>
        [HttpGet("{drinkId}/types")]
        public async Task<ActionResult<IEnumerable<DrinkType>>> GetDrinkTypes(int drinkId)
        {
            var drinkTypes = await _drinkService.GetDrinkTypes(drinkId);
            return Ok(drinkTypes);
        }

        /// <summary>
        /// Agrega un tipo de bebida a una bebida.
        /// </summary>
        [HttpPost("{drinkId}/types")]
        public async Task<ActionResult> AddDrinkType(int drinkId, [FromBody] DrinkType drinkType)
        {
            await _drinkService.AddDrinkType(drinkId, drinkType);
            return Ok();
        }

        /// <summary>
        /// Agrega multiples tipos de bebida a una bebida.
        /// </summary>
        [HttpPost("{drinkId}/types/bulk")]
        public async Task<ActionResult> AddDrinkTypes(int drinkId, [FromBody] IEnumerable<DrinkType> drinkTypes)
        {
            foreach (var drinkType in drinkTypes)
            {
                await _drinkService.AddDrinkType(drinkId, drinkType);
            }
            return Ok();
        }

        /// <summary>
        /// Actualiza un tipo de bebida de una bebida.
        /// </summary>
        [HttpPut("{drinkId}/types/{drinkTypeId}")]
        public async Task<ActionResult> UpdateDrinkType(int drinkId, int drinkTypeId, [FromBody] DrinkType drinkType)
        {
            if (drinkTypeId != drinkType.Id)
            {
                return BadRequest();
            }
            await _drinkService.UpdateDrinkType(drinkId, drinkType);
            return Ok();
        }

        /// <summary>
        /// Elimina un tipo de bebida de una bebida.
        /// </summary>
        [HttpDelete("{drinkId}/types/{drinkTypeId}")]
        public async Task<ActionResult> DeleteDrinkType(int drinkId, int drinkTypeId)
        {
            await _drinkService.DeleteDrinkType(drinkId, drinkTypeId);
            return Ok();
        }
    }
}
