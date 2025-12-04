using LetsDo.API.Dtos.Event;
using LetsDo.BLL.Services.Abstract;
using LetsDo.DAL.DataContext.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace LetsDo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IGenericService<Event> _eventService;


        public EventsController(IGenericService<Event> eventService)
        {
            _eventService = eventService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll(
             bool withOrganizer = false,
             bool withCategory = false,
             DateTime? afterDate = null)
        {
            Expression<Func<Event, bool>>? filter = null;
            if (afterDate.HasValue)
                filter = e => e.EventDate >= afterDate.Value;

            var includes = new List<Expression<Func<Event, object>>>();
            if (withCategory) includes.Add(e => e.Category);

            var events = await _eventService.GetAllAsync(
                filter: filter,
                includes: includes.ToArray());

            return Ok(events);
        }

        // GET: api/events/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id) // ← Guid oldu!
        {
            var ev = await _eventService.GetByIdAsync(
                id: id, // artık int değil Guid
                e => e.Organizer,
                e => e.Category);

            return ev == null ? NotFound() : Ok(ev);
        }

       
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEventDto dto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var newEvent = new Event 
            { 
                Title = dto.Title,
                Description = dto.Description,
                EventDate = dto.EventDate.ToUniversalTime(), 
                MaxParticipants = dto.MaxParticipants,
                OrganizerId = dto.OrganizerId
            };

            await _eventService.CreateAsync(newEvent);
            return Ok(newEvent);

        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Event updatedEvent)
        {
            if (id != updatedEvent.Id) return BadRequest("ID is not doesn't fit!");

            var exists = await _eventService.AnyAsync(e => e.Id == id);
            if (!exists) return NotFound();

            await _eventService.UpdateAsync(updatedEvent);
            return NoContent();
        }

       
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var exists = await _eventService.AnyAsync(e => e.Id == id);
            if (!exists) return NotFound();

            await _eventService.DeleteAsync(id);
            return Ok("Event Deleted");
        }
    }
}
