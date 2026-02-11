using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public StudentsController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _context.Students.ToListAsync());
    }

    [HttpPost]
    public async Task<IActionResult> Post(Student student)
    {
        _context.Students.Add(student);
        await _context.SaveChangesAsync();
        return Ok(student);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var student = await _context.Students.FindAsync(id);
        if (student == null) return NotFound();
        return Ok(student);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Student student)
    {
        if (id != student.Id) return BadRequest();
        _context.Entry(student).State = EntityState.Modified;
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await _context.Students.AnyAsync(s => s.Id == id)) return NotFound();
            throw;
        }
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var student = await _context.Students.FindAsync(id);
        if (student == null) return NotFound();
        _context.Students.Remove(student);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
