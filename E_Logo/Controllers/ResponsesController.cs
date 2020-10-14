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
    public class ResponsesController : ControllerBase
    {
        private readonly E_LOGOContext _context;
        private readonly AppSettings _appSettings;
        public ResponsesController(E_LOGOContext context, IOptions<AppSettings> appSettings)
        {
            _context = context;
            _appSettings = appSettings.Value;
        }



        // GET: api/Responses/getallresponses
        [HttpGet("getallresponses/{stimuliid}")]
        [HttpGet]

        public async Task<ActionResult<IEnumerable<ResponseDTO>>> GetResponsesFromStimuli(int stimuliid)
        {

            return (await _context.Responses.Where(p => p.StimuliID == stimuliid).ToListAsync()).ToDTO();

        }

        // GET: api/Responses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseDTO>> GetOneResponse(int id)
        {
            var response = await _context.Responses.FindAsync(id);

            if (response == null)
            {
                return NotFound();
            }

            return response.ToDTO();
        }

        // PUT: api/Response/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutResponse(int id, ResponseDTO responseDTO)
        {
            if (id != responseDTO.Id)
            {
                return BadRequest();
            }
            var st = await _context.Responses.Where(s => s.Id == id).SingleOrDefaultAsync();
            if (st == null)
                return NotFound();
            st.Choice = responseDTO.Choice;
            st.isGoodAnswer = responseDTO.isGoodAnswer;
            st.Type = responseDTO.Type;
            st.StimuliID = responseDTO.StimuliID;
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetOneResponse), new { id = st.Id }, st.ToDTO());
            // var res = await _context.SaveChangesAsyncWithValidation();
            // if (!res.IsEmpty)
            //     return BadRequest(res)
        }

        // POST: api/Responses
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ResponseDTO>> PostResponse(ResponseDTO responseDTO)
        {

            var st = await _context.Responses.FindAsync(responseDTO
            .Id);
            if (st != null)
            {
                return BadRequest();
            }

            var stimuli = await _context.Stimulis.Where(t => t.Id == responseDTO.StimuliID).SingleOrDefaultAsync();
            if (stimuli == null) { return BadRequest(); }
            var newR = new Response()
            {
                Id = responseDTO.Id,
                Choice = responseDTO.Choice,
                isGoodAnswer = responseDTO.isGoodAnswer,


            };
            newR.Stimuli = stimuli;
            _context.Responses.Add(newR);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetOneResponse), new { id = newR.Id }, newR.ToDTO());
        }

        // DELETE: api/Response/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Response>> DeleteResponse(int id)
        {
            var st = await _context.Responses.FindAsync(id);
            if (st == null)
            {
                return NotFound();
            }

            _context.Responses.Remove(st);
            await _context.SaveChangesAsync();

            return st;
        }
    }
}