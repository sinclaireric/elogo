using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using E_Logo.Models;

namespace E_Logo.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpeechTherapistsController : ControllerBase
    {
        private readonly E_LogoContext _context;

        public SpeechTherapistsController(E_LogoContext context)
        {
            _context = context;
        }

        // GET: api/SpeechTherapists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SpeechTherapist>>> GetSpeechTherapists()
        {
            return await _context.SpeechTherapists.ToListAsync();
        }

        // GET: api/SpeechTherapists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SpeechTherapist>> GetSpeechTherapist(int id)
        {
            var speechTherapist = await _context.SpeechTherapists.FindAsync(id);

            if (speechTherapist == null)
            {
                return NotFound();
            }

            return speechTherapist;
        }

        // PUT: api/SpeechTherapists/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSpeechTherapist(int id, SpeechTherapist speechTherapist)
        {
            if (id != speechTherapist.Id)
            {
                return BadRequest();
            }

            _context.Entry(speechTherapist).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpeechTherapistExists(id))
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

        // POST: api/SpeechTherapists
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SpeechTherapist>> PostSpeechTherapist(SpeechTherapist speechTherapist)
        {
            _context.SpeechTherapists.Add(speechTherapist);
            await _context.SaveChangesAsync();

            //  return CreatedAtAction("GetSpeechTherapist", new { id = speechTherapist.Id }, speechTherapist);
            return CreatedAtAction(nameof(GetSpeechTherapist), new { id = speechTherapist.Id }, speechTherapist);
        }

        // DELETE: api/SpeechTherapists/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SpeechTherapist>> DeleteSpeechTherapist(int id)
        {
            var speechTherapist = await _context.SpeechTherapists.FindAsync(id);
            if (speechTherapist == null)
            {
                return NotFound();
            }

            _context.SpeechTherapists.Remove(speechTherapist);
            await _context.SaveChangesAsync();

            return speechTherapist;
        }

        private bool SpeechTherapistExists(int id)
        {
            return _context.SpeechTherapists.Any(e => e.Id == id);
        }
    }
}
