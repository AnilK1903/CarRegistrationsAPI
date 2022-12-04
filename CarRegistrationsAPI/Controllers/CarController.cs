using CarRegistrationsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace CarRegistrationsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : Controller
    {
        private readonly DataContext context;

        public CarController(DataContext context)
        {
            this.context = context; 
        }

        [HttpGet]
        [Route("All_Cars")]
        public async Task<ActionResult<List<Car>>> GetAllCars()
        {
            var allCars = await context.Cars
                .ToListAsync();

            return allCars;
        }


        [HttpGet]
        [Route("One_Car")]
        public async Task<ActionResult<List<Car>>> Get(int Id)
        {
            var cars = await context.Cars
                .Where(c => c.Id == Id)
                .ToListAsync();

            return cars;
        }

        [HttpPost]
        [Route("Add_Car")]
        public async Task<ActionResult<List<Car>>> AddCar(AddCar request)
        {
            var manufacturer = await context.Manufacturers.FindAsync(request.ManufacturerId);
            if (manufacturer == null)
                return NotFound();

            var newCar = new Car
            {
                Brand = request.Brand,
                Model = request.Model,
                VIN = request.VIN,
                License_plate = request.License_plate,
                First_reg_date = request.First_reg_date,
                Power_kW = request.Power_kW,
                Body_type = request.Body_type,
                Color = request.Color,
                Manufacturer = manufacturer
            };

            context.Cars.Add(newCar);
            await context.SaveChangesAsync();

            return await Get(newCar.ManufacturerId);
        }

        [HttpPut]
        [Route("Update_Car")]
        public async Task<IActionResult> UpdateCar(int id, UpdateCar request)
        {
            var updateCar = await context.Cars.FindAsync(id);

            if (updateCar != null)
            {
                updateCar.Brand = request.Brand;
                updateCar.Model = request.Model;
                updateCar.VIN = request.VIN;
                updateCar.License_plate = request.License_plate;
                updateCar.First_reg_date = request.First_reg_date;
                updateCar.Power_kW = request.Power_kW;
                updateCar.Body_type = request.Body_type;
                updateCar.Color = request.Color;
                updateCar.ManufacturerId = request.ManufacturerId;

                await context.SaveChangesAsync();

                return Ok(updateCar);
            }

            return NotFound();
        }

        [HttpDelete]
        [Route("Delete_Car")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            var deleteCar = await context.Cars.FindAsync(id);

            if (deleteCar == null)
                return NotFound();

            context.Remove(deleteCar);
            await context.SaveChangesAsync();

            return Ok(deleteCar);
        }
    }
}
