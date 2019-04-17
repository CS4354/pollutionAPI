using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PollutionApi.Models;

namespace PollutionApi.Controllers
{
    [Route("api/todo")] // convention: controller class name (StateController)
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly StateContext _context;

        public StateController(StateContext context)
        {
            _context = context;

            if (_context.States.Count() == 0)
            {
                // Create a new TodoItem if collection is empty,
                // which means you can't delete all TodoItems.
                _context.States.Add(new State { STATEID = 1, STATENAME = "Annie" });
                _context.SaveChanges();
            }
        }

        // To provide an API that retrieves to-do items
        // GET: api/Todo
        [HttpGet] // denotes a method that responds to an HTTP GET request
        public async Task<ActionResult<IEnumerable<State>>> GetStates()
        {
            return await _context.States.ToListAsync();
        }

        // GET: api/Todo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<State>> GetState(long id)
        {
            var state = await _context.States.FindAsync(id);

            if (state == null)
            {
                return NotFound();
            }

            return state;
        }

    }
}