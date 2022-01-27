#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class XesController : ControllerBase
    {
        DDSXContext _context = new DDSXContext();



        // GET: api/Xes
        [HttpGet]
        public IActionResult GetXes()
        {
            return Ok(_context.Xes.ToList());
        }

        // GET: api/Xes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Xe>> GetXe(int id)
        {
            var xe = await _context.Xes.FindAsync(id);

            if (xe == null)
            {
                return NotFound();
            }

            return xe;
        }

        // PUT: api/Xes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutXe(int id, Xe xe)
        {
            if (id != xe.XeId)
            {
                return BadRequest();
            }

            _context.Entry(xe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!XeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Xes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Xe>> PostXe(Xe xe)
        {
            _context.Xes.Add(xe);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetXe", new { id = xe.XeId }, xe);
        }

        // DELETE: api/Xes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteXe(int id)
        {
            var xe = await _context.Xes.FindAsync(id);
            if (xe == null)
            {
                return NotFound();
            }

            _context.Xes.Remove(xe);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool XeExists(int id)
        {
            return _context.Xes.Any(e => e.XeId == id);
        }
    }
}
