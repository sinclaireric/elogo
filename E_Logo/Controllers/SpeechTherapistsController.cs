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
        public async Task<ActionResult<IEnumerable<SpeechTherapistDTO>>> GetSpeechTherapists()
        {
            //return await _context.SpeechTherapists.ToListAsync();
            return (await _context.SpeechTherapists.ToListAsync()).ToDTO();

        }

        // GET: api/SpeechTherapists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SpeechTherapistDTO>> GetSpeechTherapist(int id)
        {
            var speechTherapist = await _context.SpeechTherapists.FindAsync(id);

            if (speechTherapist == null)
            {
                return NotFound();
            }

            return speechTherapist.ToDTO();
        }

        // PUT: api/SpeechTherapists/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSpeechTherapist(int id, SpeechTherapistDTO speechTherapistDTO)
        {
            if (id != speechTherapistDTO.Id)
            {
                return BadRequest();
            }
            var st = await _context.SpeechTherapists.Where(s => s.Id == id).SingleOrDefaultAsync();
            if (st == null)
                return NotFound();
            st.Username = speechTherapistDTO.Username;
            st.Firstname = speechTherapistDTO.Firstname;
            st.Lastname = speechTherapistDTO.Lastname;

            if (speechTherapistDTO.Password != null)
            {
                st.Password = speechTherapistDTO.Password;
            }
            // var res = await _context.SaveChangesAsyncWithValidation();
            // if (!res.IsEmpty)
            //     return BadRequest(res);
            return NoContent();
        }

        // POST: api/SpeechTherapists
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SpeechTherapistDTO>> PostSpeechTherapist(SpeechTherapistDTO speechTherapistDTO)
        {
            var st = await _context.SpeechTherapists.FindAsync(speechTherapistDTO.Id);
            if (st != null)
            {
                //var err = new ValidationErrors().Add("Pseudo already in use", nameof(member.Pseudo));
                return BadRequest();
            }
            var newST = new SpeechTherapist()
            {
                Username = speechTherapistDTO.Username,
                Lastname = speechTherapistDTO.Lastname,
                Firstname = speechTherapistDTO.Lastname,
            };
            _context.SpeechTherapists.Add(newST);
            await _context.SaveChangesAsync();
            // var res = await _context.SaveChangesAsync();
            // if(!res.IsEmpty)
            // return BadRequest();
            //  return CreatedAtAction("GetSpeechTherapist", new { id = speechTherapist.Id }, speechTherapist);
            return CreatedAtAction(nameof(GetSpeechTherapist), new { id = newST.Id }, newST.ToDTO());
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
