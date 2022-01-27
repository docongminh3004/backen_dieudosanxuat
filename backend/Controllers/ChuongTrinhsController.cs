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
    public class ChuongTrinhsController : ControllerBase
    {
        DDSXContext _context = new DDSXContext();

        // GET: api/ChuongTrinhs
        [HttpGet]
        public IActionResult GetChuongTrinhs()
        {
            return Ok(_context.ChuongTrinhs.ToList());
        }

        // GET: api/ChuongTrinhs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ChuongTrinh>> GetChuongTrinh(int id)

        {
            var chuongTrinh = await _context.ChuongTrinhs.FindAsync(id);

            if (chuongTrinh == null)
            {
                return NotFound();
            }

            return chuongTrinh;
        }

        // PUT: api/ChuongTrinhs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChuongTrinh(int id, ChuongTrinh chuongTrinh)
        {
            if (id != chuongTrinh.ChuongTrinhId)
            {
                return BadRequest();
            }

            _context.Entry(chuongTrinh).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChuongTrinhExists(id))
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

        // POST: api/ChuongTrinhs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ChuongTrinh>> PostChuongTrinh(ChuongTrinh chuongTrinh)
        {
            _context.ChuongTrinhs.Add(chuongTrinh);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChuongTrinh", new { id = chuongTrinh.ChuongTrinhId }, chuongTrinh);
        }

        // DELETE: api/ChuongTrinhs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChuongTrinh(int id)
        {
            var chuongTrinh = await _context.ChuongTrinhs.FindAsync(id);
            if (chuongTrinh == null)
            {
                return NotFound();
            }

            _context.ChuongTrinhs.Remove(chuongTrinh);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChuongTrinhExists(int id)
        {
            return _context.ChuongTrinhs.Any(e => e.ChuongTrinhId == id);
        }
    }
}
