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
using Task = E_LOGO.Models.Task;

namespace E_LOGO.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class StimulisController : ControllerBase
    {
        private readonly E_LOGOContext _context;
        private readonly AppSettings _appSettings;

        public StimulisController(E_LOGOContext context, IOptions<AppSettings> appSettings)
        {
            _context = context;
            _appSettings = appSettings.Value;
        }


        // GET: api/Stimulis/getallstimulis
        [HttpGet("getallstimulis/{taskid}")]
        [HttpGet]

        public async Task<ActionResult<IEnumerable<StimuliDTO>>> GetStimulisFromTask(int taskid)
        {

            return (await _context.Stimulis.Where(p => p.TaskID == taskid).ToListAsync()).ToDTO();

        }

        // GET: api/Stimulis/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StimuliDTO>> GetOneStimuli(int id)
        {
            var stimuli = await _context.Stimulis.FindAsync(id);

            if (stimuli == null)
            {
                return NotFound();
            }

            return stimuli.ToDTO();
        }

        // PUT: api/Stimulis/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStimuli(int id, StimuliDTO stimuliDTO)
        {
            if (id != stimuliDTO.Id)
            {
                return BadRequest();
            }
            var st = await _context.Stimulis.Where(s => s.Id == id).SingleOrDefaultAsync();
            if (st == null)
                return NotFound();
            st.Name = stimuliDTO.Name;
            st.TaskID = stimuliDTO.TaskID;
            //st.Task = stimuliDTO.Task;
            // if (stimuliDTO.Responses != null)
            // {
            //     st.Responses.Clear();
            //     await _context.SaveChangesAsync();
            //     stimuliDTO.Responses.ForEach((s) =>
            //     {
            //         var news = new Response
            //         {
            //             Id = s.Id,
            //             Type = s.Type,
            //             StimuliID = s.StimuliID,
            //             isGoodAnswer = s.isGoodAnswer,
            //             Choice = s.Choice,
            //         };
            //         _context.Responses.Add(news);

            //     });
            // }
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetOneStimuli), new { id = st.Id }, st.ToDTO());
            // var res = await _context.SaveChangesAsyncWithValidation();
            // if (!res.IsEmpty)
            //     return BadRequest(res)
        }

        // POST: api/Stimulis
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<StimuliDTO>> PostStimuli(StimuliDTO stimuliDTO)
        {

            var st = await _context.Stimulis.FindAsync(stimuliDTO.Id);
            if (st != null)
            {
                return BadRequest();
            }

            var task = await _context.Tasks.Where(t => t.Id == stimuliDTO.TaskID).SingleOrDefaultAsync();
            if (task == null) { return BadRequest(); }
            var newST = new Stimuli()
            {
                Id = stimuliDTO.Id,
                Name = stimuliDTO.Name,
                TaskID = stimuliDTO.TaskID,


            };
            newST.Task = task;
            _context.Stimulis.Add(newST);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetOneStimuli), new { id = newST.Id }, newST.ToDTO());
        }

        // DELETE: api/SpeechTherapists/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Stimuli>> DeleteStimuli(int id)
        {
            var st = await _context.Stimulis.FindAsync(id);
            if (st == null)
            {
                return NotFound();
            }

            _context.Stimulis.Remove(st);
            await _context.SaveChangesAsync();

            return st;
        }
    }
}