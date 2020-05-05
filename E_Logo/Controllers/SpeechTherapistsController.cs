using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using E_LOGO.Models;
using Microsoft.AspNetCore.Authorization;
using System.Text;
using System.Security.Claims;
using E_LOGO.Helpers;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace E_LOGO.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpeechTherapistsController : ControllerBase
    {
        private readonly E_LOGOContext _context;

        public SpeechTherapistsController(E_LOGOContext context,IOptions<AppSettings> appSettings)
        {
            _context = context;
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<ActionResult<SpeechTherapist>> Authenticate(SpeechTherapistDTO data)
        {
            var st = await Authenticate(data.Email, data.Password);
            if (st == null)
                return BadRequest(new { message = "Email is incorrect" });
            if (st.Token == null)
                return BadRequest(new { message = "Password is incorrect" });
            return Ok(st.AuthenticateDTO());
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
            st.Email = speechTherapistDTO.Email;
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
                Email = speechTherapistDTO.Email,
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



        //JWT AUTHENTICATE
        private readonly AppSettings _appSettings;
        public async Task<SpeechTherapist> Authenticate(string Email, string password)
        {
            var st = await _context.SpeechTherapists.SingleOrDefaultAsync(x => x.Email == Email && x.Password == password);

            // return null if user not found
            if (st == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("my-super-secret-key");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, st.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            st.Token = tokenHandler.WriteToken(token);

            return st.WithoutPassword();
        }

    }
}
