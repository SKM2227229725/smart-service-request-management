using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ServiceRequestsController : ControllerBase
{
    private readonly AppDbContext _context;

    public ServiceRequestsController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/ServiceRequests
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ServiceRequest>>> GetServiceRequests()
    {
        return await _context.ServiceRequests.ToListAsync();
    }

    // GET: api/ServiceRequests/5
    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceRequest>> GetServiceRequest(int id)
    {
        var request = await _context.ServiceRequests.FindAsync(id);

        if (request == null)
        {
            return NotFound();
        }

        return request;
    }

    // POST: api/ServiceRequests
    [HttpPost]
    public async Task<ActionResult<ServiceRequest>> CreateServiceRequest(
        ServiceRequest serviceRequest)
    {
        _context.ServiceRequests.Add(serviceRequest);
        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetServiceRequest),
            new { id = serviceRequest.Id },
            serviceRequest
        );
    }

    // PUT: api/ServiceRequests/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateServiceRequest(
        int id,
        ServiceRequest serviceRequest)
    {
        if (id != serviceRequest.Id)
        {
            return BadRequest();
        }

        _context.Entry(serviceRequest).State = EntityState.Modified;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    // DELETE: api/ServiceRequests/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteServiceRequest(int id)
    {
        var request = await _context.ServiceRequests.FindAsync(id);

        if (request == null)
        {
            return NotFound();
        }

        _context.ServiceRequests.Remove(request);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}