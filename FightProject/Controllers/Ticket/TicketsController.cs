using AutoMapper;
using Flight.Core.Entities;
using Flight.Repository;
using FlightProject.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlightProject.Controllers.Ticket
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public TicketsController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/tickets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TicketDto>>> GetTickets()
        {
            var tickets = await _context.Tickets
                .Include(t => t.Flight)
                .Include(t => t.User)
                .Where(t => !t.IsDeleted)
                .ToListAsync();

            var result = _mapper.Map<List<TicketDto>>(tickets);
            return Ok(result);
        }

        // GET: api/tickets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TicketDto>> GetTicket(int id)
        {
            var ticket = await _context.Tickets
                .Include(t => t.Flight)
                .Include(t => t.User)
                .FirstOrDefaultAsync(t => t.Id == id && !t.IsDeleted);

            if (ticket == null)
                return NotFound();

            var result = _mapper.Map<TicketDto>(ticket);
            return Ok(result);
        }

        // POST: api/tickets
        [HttpPost]
        public async Task<ActionResult<TicketDto>> CreateTicket([FromBody] TicketDto dto)
        {
            var entity = _mapper.Map<Flight.Core.Entities.Ticket>(dto);
            _context.Tickets.Add(entity);
            await _context.SaveChangesAsync();

            dto.Id = entity.Id;
            return CreatedAtAction(nameof(GetTicket), new { id = dto.Id }, dto);
        }

        // PUT: api/tickets/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTicket(int id, [FromBody] TicketDto dto)
        {
            if (id != dto.Id)
                return BadRequest();

            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket == null || ticket.IsDeleted)
                return NotFound();

            _mapper.Map(dto, ticket);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/tickets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicket(int id)
        {
            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket == null || ticket.IsDeleted)
                return NotFound();

            ticket.IsDeleted = true;
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
