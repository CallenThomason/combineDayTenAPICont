using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using combineDayTenAPICont.Models;
using combineDayTenAPICont.Services;
using Microsoft.AspNetCore.Mvc;

namespace combineDayTenAPICont.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // / api/cargo
    public class CargoController : ControllerBase
    {
        
        //Constructor - runs once when the method is called
        private readonly ICargoServices _cargo; //Declaring our empty CargoServices
        //readonly means it can never be reassigned
        public CargoController(ICargoServices cargo)
        {
            _cargo = cargo; 
        }
        //We are injecting our Services into our controller to gain access to the methods

        [HttpGet("GetAll")]
        public ActionResult GetAllCargo()
        {
            return Ok(_cargo.GetAll()); 
        }

        [HttpGet("GetByCategory/{category}")]
        public ActionResult<List<CargoItem>> GetByCategory(string category)
        {
            List<CargoItem> item = _cargo.GetByCategory(category); 
            return Ok(item); 
        }

        [HttpGet("GetById/{id}")]

        public ActionResult<CargoItem> GetById(int id)
        {
            CargoItem item = _cargo.GetById(id); 
            if(item == null)
            {
                return NotFound($"That Id Isn't in our system: {id}");
            }
            return Ok(item); 
        }

        [HttpPost("create")]
        public ActionResult<CargoItem> Create([FromBody] CargoItem item)
        {
            CargoItem newItem = _cargo.Create(item);

            //nameOf points to where we can find our new created it
            //new setting the id inside our url. /api/getByid/(new id)
            //
            return CreatedAtAction(
                nameof(GetById),
                new{id = newItem.Id},
                newItem
            );
            
                // "id":2,
                // "name":"Plasma fuel",
                // "category":"Energy",
                // "masskg":1

        }
        [HttpPut("update/{id}")]

        public ActionResult<bool> Update(int id, CargoItem item)
        {
            bool updated = _cargo.Update(id, item);
            if (!updated)
            {
               return NotFound($"No Cargo was found with id: {id}");
            }
            //return Ok(true) also works
            return NoContent(); //204 - It worked and their is nothing to send back
        }

        [HttpDelete("Delete/{id}")]
        public ActionResult<bool> deleteItem(int id)
        {
            bool isDeleted = _cargo.Delete(id); 

            if(isDeleted == false)
            {
                return NotFound($"No cargo item with id: {id}");
            }
            return NoContent(); 
        }

    }
}