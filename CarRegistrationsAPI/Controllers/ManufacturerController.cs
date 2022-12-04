using CarRegistrationsAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarRegistrationsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ManufacturerController : Controller
    {
        private readonly DataContext context;

        public ManufacturerController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [Route("All_Manufacturers")]
        public async Task<ActionResult<List<Manufacturer>>> GetAllManufacturers()
        {
            var allManufacturers = await context.Manufacturers
                .ToListAsync();

            return allManufacturers;
        }

        [HttpGet]
        [Route("One_Manufacturer")]
        public async Task<ActionResult<List<Manufacturer>>> GetOne(int Id)
        {
            var manufacturers = await context.Manufacturers
                .Where(m => m.Id == Id)
                .ToListAsync();

            return manufacturers;
        }

        [HttpGet]
        [Route("Manufacturer_AllCars")]
        public async Task<ActionResult<List<Car>>> Get(int manufacturerId)
        {
            var cars = await context.Cars
                .Where(c => c.ManufacturerId == manufacturerId)
                .ToListAsync();

            return cars;
        }

        [HttpPost]
        [Route("Add_Manufacturer")]
        public async Task<ActionResult<List<Manufacturer>>> AddManufacturer(AddManufacturer request)
        {
            var newManufacturer = new Manufacturer
            {
                Name = request.Name,
                Address = request.Address,
                Phone = request.Phone,
                Year_of_foundation = request.Year_of_foundation
            };

            context.Manufacturers.Add(newManufacturer);
            await context.SaveChangesAsync();

            return await GetOne(newManufacturer.Id);
        }

        [HttpPut]
        [Route("Update_Manufacturer")]
        public async Task<IActionResult> UpdateManufacturer(int id, UpdateManufacturer request)
        {
            var updateManufacturer = await context.Manufacturers.FindAsync(id);

            if (updateManufacturer != null)
            {
                updateManufacturer.Name = request.Name;
                updateManufacturer.Address = request.Address;
                updateManufacturer.Phone = request.Phone;
                updateManufacturer.Year_of_foundation = request.Year_of_foundation;

                await context.SaveChangesAsync();

                return Ok(updateManufacturer);
            }

            return NotFound();
        }

        [HttpDelete]
        [Route("Delete_Manufacturer")]
        public async Task<IActionResult> DeleteManufacturer(int id)
        {
            var deleteManufacturer = await context.Manufacturers.FindAsync(id);

            if (deleteManufacturer == null)
                return NotFound();

            context.Remove(deleteManufacturer);
            await context.SaveChangesAsync();

            return Ok(deleteManufacturer);
        }
    }
}
