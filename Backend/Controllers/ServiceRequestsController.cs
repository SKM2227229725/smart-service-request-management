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
    // GET: api/ServiceRequests?status=Pending
    // GET: api/ServiceRequests?priority=High
    // GET: api/ServiceRequests?status=Pending&priority=High
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ServiceRequest>>> GetServiceRequests(
        string? status,
        string? priority)
    {
        var query = _context.ServiceRequests
            .Include(sr => sr.User)
            .AsQueryable();

        if (!string.IsNullOrEmpty(status))
        {
            query = query.Where(sr => sr.Status == status);
        }

        if (!string.IsNullOrEmpty(priority))
        {
            query = query.Where(sr => sr.Priority == priority);
        }

        return await query.ToListAsync();
    }

    // GET: api/ServiceRequests/5
    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceRequest>> GetServiceRequest(int id)
    {
        var request = await _context.ServiceRequests
            .Include(sr => sr.User)
            .FirstOrDefaultAsync(sr => sr.Id == id);

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
        var userExists = await _context.Users
            .AnyAsync(u => u.Id == serviceRequest.UserId);

        if (!userExists)
        {
            return BadRequest("Invalid UserId.");
        }

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

    // PATCH: api/ServiceRequests/5/status
    [HttpPatch("{id}/status")]
    public async Task<IActionResult> UpdateStatus(
        int id,
        string status)
    {
        var request = await _context.ServiceRequests.FindAsync(id);

        if (request == null)
        {
            return NotFound();
        }

        if (status != "Pending" &&
            status != "In Progress" &&
            status != "Completed")
        {
            return BadRequest("Invalid status.");
        }

        request.Status = status;

        await _context.SaveChangesAsync();

        return Ok(request);
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