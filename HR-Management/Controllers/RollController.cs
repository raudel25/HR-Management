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
    private readonly HHRRContext _context;

    public RollController(HHRRContext context)
    {
        this._context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Roll>> Get()
    {
        return this._context.Rolls.ToList();
    }

    [HttpGet("{id:int}")]
    public ActionResult<Roll> Get(int id)
    {
        var roll = this._context.Rolls.SingleOrDefault(e => e.Id == id);
        if (roll is null) return NotFound();

        return roll;
    }

    [HttpPost]
    public ActionResult<Roll> Post(RollRequest request)
    {
        var r = this._context.Rolls.SingleOrDefault(r => r.Name == request.Name);
        if (r is null) return BadRequest();

        var roll = request.Roll();

        this._context.Rolls.Add(roll);
        this._context.SaveChanges();

        return roll;
    }

    [HttpPut("{id:int}")]
    public ActionResult<Roll> Put(int id, RollRequest request)
    {
        var roll = request.Roll();
        roll.Id = id;

        var r1 = this._context.Rolls.SingleOrDefault(e => e.Id == id);
        if (r1 is null) return NotFound();
        
        var r2 = this._context.Rolls.SingleOrDefault(r => r.Name == request.Name && r.Id != id);
        if (r2 is not null) return BadRequest();

        _context.Entry(r1).State = EntityState.Detached;

        this._context.Rolls.Update(roll);
        this._context.SaveChanges();

        return roll;
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        var roll = this._context.Rolls.SingleOrDefault(e => e.Id == id);

        if (roll is null) return NotFound();

        this._context.Rolls.Remove(roll);
        this._context.SaveChanges();

        return Ok();
    }
}