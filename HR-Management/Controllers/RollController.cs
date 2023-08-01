using HR_Management.Models;
using HR_Management.Network;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HR_Management.Services;

namespace HR_Management.Controllers;

[ApiController]
[Route("[controller]")]
public class RollController : ControllerBase
{
    private readonly HRContext _context;

    public RollController(HRContext context)
    {
        this._context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Roll>>> Get()
    {
        return await this._context.Rolls.ToListAsync();
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Roll>> Get(int id)
    {
        var roll = await this._context.Rolls.SingleOrDefaultAsync(e => e.Id == id);
        if (roll is null) return NotFound();

        return roll;
    }

    [HttpPost]
    public async Task<ActionResult<Roll>> Post(RollRequest request)
    {
        if (request.PeriodMoths == 0 || request.Augment == 0) return BadRequest();
        
        var r = await this._context.Rolls.SingleOrDefaultAsync(r => r.Name == request.Name);
        if (r is not null) return BadRequest();

        var roll = request.Roll();

        this._context.Rolls.Add(roll);
        await this._context.SaveChangesAsync();

        return roll;
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<Roll>> Put(int id, RollRequest request)
    {
        if (request.PeriodMoths == 0 || request.Augment == 0) return BadRequest();

        var roll = request.Roll();
        roll.Id = id;

        var r1 = await this._context.Rolls.SingleOrDefaultAsync(e => e.Id == id);
        if (r1 is null) return NotFound();

        var r2 = await this._context.Rolls.SingleOrDefaultAsync(r => r.Name == request.Name && r.Id != id);
        if (r2 is not null) return BadRequest();

        _context.Entry(r1).State = EntityState.Detached;

        this._context.Rolls.Update(roll);
        await this._context.SaveChangesAsync();

        return roll;
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var roll = await this._context.Rolls.SingleOrDefaultAsync(e => e.Id == id);

        if (roll is null) return NotFound();

        this._context.Rolls.Remove(roll);
        await this._context.SaveChangesAsync();

        return Ok();
    }
}