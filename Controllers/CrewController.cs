
using combineDayTenAPICont.Models;
using Microsoft.AspNetCore.Mvc;

namespace combineDayTenAPICont.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // -> api/crew
    public class CrewController : ControllerBase
    {
        //Our Database for today
        //A Static List means one shared copy for the whole application, so the data survives between requests

       private static List<CrewMember> Crew = [
            new CrewMember { Id = 1, Name = "Callen Thomason", Rank = "Student", Sector = "Cargo", IsOnDuty = true},
            new CrewMember {Id = 2, Name = "Chris Estrada", Rank = "Engineer", Sector = "Engineering", IsOnDuty = true},
            new CrewMember {Id = 3, Name = "Zackary Santos", Rank = "Medic", Sector = "Meidcal", IsOnDuty = false}
        ]; 
        //This tracks the next Id to hand out
        private static int _nextId = 4; 

        [HttpGet("GetAllMembers")]
        public ActionResult<List<CrewMember>> GetAll()
        {
            //return a 200 Ok with the whole listy

            return Ok(Crew);
        }
        [HttpGet("getmember/{id}")]
        public ActionResult<CrewMember> GetById(int id)
        {
            //FirstOrDefault returns null when nothing matches
            //=> is a one liner for a method that returns the conditioned value. 
            CrewMember? member = Crew.FirstOrDefault(c => c.Id == id); //simple for loop

            if(member == null)
            {
                //404 - The client asked for an id that does not exist
                return NotFound($"No crew member with id {id}"); 
            }

            return Ok(member); 
        }

        [HttpPost("Create")]
        public ActionResult<CrewMember> Create([FromBody] CrewMember incoming)
        {
           incoming.Id = _nextId;
           _nextId ++; 

           Crew.Add(incoming); 

            //201 Created is the correct status for "I made something new"
            //
           return CreatedAtAction(
                actionName: nameof(GetById), //which action can GET the new thing
                routeValues: new {id = incoming.Id}, //fill the {id} parameter in that action route
                value: incoming                      //the body to be sent back
           ); 
        }

        //REPLACE - UP

        //Put replaces the whole record(CrewMember). The Client sends every field.
        [HttpPut("Update/{id}")]
        public ActionResult<bool> Update(int id, [FromBody] CrewMember incoming)
        {                                           //c is the parameter and we return the first result if the Ids match
            CrewMember? member = Crew.FirstOrDefault(c => c.Id == id); 
        if(member == null)
            {
                return NotFound($"No crew member with id {id}");
            }
            //Copy each field across. We deliberatly do NOT copy the Id
            member.Name = incoming.Name;
            member.Rank = incoming.Rank; 
            member.Sector = incoming.Sector; 
            member.IsOnDuty = incoming.IsOnDuty;

            return Ok(true); 
        }

        [HttpDelete("delete/{id}")]
        public ActionResult<bool> Delete(int id)
        {
            //? means that member can be null
            CrewMember? member = Crew.FirstOrDefault(c => c.Id == id);
                
            if(member == null)
            {
                return NotFound($"No crew member with id: {id}");
            }
            
            Crew.Remove(member); 
            return Ok(true); 
        }
    }
}