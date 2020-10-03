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
    public class PatientsController : ControllerBase
    {
        private readonly E_LOGOContext _context;

        public PatientsController(E_LOGOContext context, IOptions<AppSettings> appSettings)
        {
            _context = context;
            // _appSettings = appSettings.Value;
        }

        // [AllowAnonymous]
        // [HttpPost("authenticate")]
        // public async Task<ActionResult<SpeechTherapist>> Authenticate(SpeechTherapistDTO data)
        // {
        //     var st = await Authenticate(data.Email, data.Password);
        //     if (st == null)
        //         return BadRequest(new { message = "Email is incorrect" });
        //     if (st.Token == null)
        //         return BadRequest(new { message = "Password is incorrect" });
        //     return Ok(st.AuthenticateDTO());
        // }

        // GET: api/Patients/getallpatients/2
        [HttpGet("getallpatients/{speechtherapistid}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientDTO>>> GetAllPatients(int SpeechTherapistID)
        {
            return (await _context.Patients.Where(p => p.SpeechTherapistID == SpeechTherapistID).ToListAsync()).ToDTO();

        }

        // GET: api/Patients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PatientDTO>> GetOnePatient(int id)
        {
            var patient = await _context.Patients.FindAsync(id);

            if (patient == null)
            {
                return NotFound();
            }

            return patient.ToDTO();
        }

        // PUT: api/SpeechTherapists/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPatient(int id, PatientDTO patientDTO)
        {
            if (id != patientDTO.Id)
            {
                return BadRequest();
            }
            var st = await _context.Patients.Where(s => s.Id == id).SingleOrDefaultAsync();
            if (st == null)
                return NotFound();
            st.Fullname = patientDTO.Fullname;
            //  st.Results = patientDTO.Results;
            st.Diagnostique = patientDTO.Diagnostique;
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetOnePatient), new { id = st.Id }, st.ToDTO());
        }


        // POST: api/SpeechTherapists
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PatientDTO>> PostSpeechTherapist(PatientDTO patientDTO)
        {
            var st = await _context.Patients.FindAsync(patientDTO.Id);
            if (st != null)
            {
                //var err = new ValidationErrors().Add("Pseudo already in use", nameof(member.Pseudo));
                return BadRequest();
            }
            var newPatient = new Patient()
            {
                Fullname = patientDTO.Fullname,
                //  Results = patientDTO.Results,
                Diagnostique = patientDTO.Diagnostique,
                LastTaskDone = patientDTO.LastTaskDone,
                SpeechTherapistID = patientDTO.SpeechTherapistID,
            };
            _context.Patients.Add(newPatient);
            await _context.SaveChangesAsync();
            // var res = await _context.SaveChangesAsync();
            // if(!res.IsEmpty)
            // return BadRequest();
            //  return CreatedAtAction("GetSpeechTherapist", new { id = speechTherapist.Id }, speechTherapist);
            return CreatedAtAction(nameof(GetOnePatient), new { id = newPatient.Id }, newPatient.ToDTO());
        }

        // DELETE: api/SpeechTherapists/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Patient>> DeletePatient(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient == null)
            {
                return NotFound();
            }

            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();

            return patient;
        }

        private bool SpeechTherapistExists(int id)
        {
            return _context.SpeechTherapists.Any(e => e.Id == id);
        }



    }
}
