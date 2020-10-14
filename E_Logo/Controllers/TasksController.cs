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
    public class TasksController : ControllerBase
    {
        private readonly E_LOGOContext _context;
        private readonly AppSettings _appSettings;

        public TasksController(E_LOGOContext context, IOptions<AppSettings> appSettings)
        {
            _context = context;
            _appSettings = appSettings.Value;
        }


        // GET: api/Task
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskDTO>>> GetTasks()
        {
            //return await _context.SpeechTherapists.ToListAsync();
            return (await _context.Tasks.ToListAsync()).ToDTO();

        }

        // GET: api/Task/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskDTO>> GetOneTask(int id)
        {
            var task = await _context.Tasks.FindAsync(id);

            if (task == null)
            {
                return NotFound();
            }

            return task.ToDTO();
        }

        // PUT: api/Task/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTask(int id, TaskDTO taskDTO)
        {
            if (id != taskDTO.Id)
            {
                return BadRequest();
            }
            var st = await _context.Tasks.Where(s => s.Id == id).SingleOrDefaultAsync();
            if (st == null)
                return NotFound();
            st.Name = taskDTO.Name;
            if (taskDTO.Stimulis != null)
            {
                st.Stimulis.Clear();
                await _context.SaveChangesAsync();
                taskDTO.Stimulis.ForEach((s) =>
                {
                    var news = new Stimuli
                    {
                        Id = s.Id,
                        Name = s.Name
                    };
                    _context.Stimulis.Add(news);

                });
            }
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetOneTask), new { id = st.Id }, st.ToDTO());
            // var res = await _context.SaveChangesAsyncWithValidation();
            // if (!res.IsEmpty)
            //     return BadRequest(res)
        }

        // POST: api/Task
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TaskDTO>> PostTask(TaskDTO taskDTO)
        {
            var st = await _context.Tasks.FindAsync(taskDTO.Id);
            if (st != null)
            {
                //var err = new ValidationErrors().Add("Pseudo already in use", nameof(member.Pseudo));
                return BadRequest();
            }
            var newST = new Task()
            {
                Id = taskDTO.Id,
                Name = taskDTO.Name,
            };
            _context.Tasks.Add(newST);
            await _context.SaveChangesAsync();
            // var res = await _context.SaveChangesAsync();
            // if(!res.IsEmpty)
            // return BadRequest();
            //  return CreatedAtAction("GetSpeechTherapist", new { id = speechTherapist.Id }, speechTherapist);
            return CreatedAtAction(nameof(GetOneTask), new { id = newST.Id }, newST.ToDTO());
        }

        // DELETE: api/SpeechTherapists/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Task>> DeleteTask(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();

            return task;
        }
    }
}
