using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PollutionApi.Models;
using System; 
namespace PollutionApi.Controllers

{
    [Route("api/pollution")]
    [ApiController]
    public class MarkerController : ControllerBase
    {
        private readonly MarkerContext _context;

        public MarkerController(MarkerContext context)
        {
            _context = context;

            if (_context.Markers.Count() == 0)
            {
                // Create a new TodoItem if collection is empty,
                // which means you can't delete all TodoItems.
                _context.Markers.Add(new Marker { PollutionDate = new DateTime(), AddressName = "", Latitude = 0m, Longitude = 0m,
                NO2Mean = 0f, NO2MaxValue = 0, NO2MaxHour = 0, NO2AQI = 0,
                O3Mean = 0f, O3MaxValue = 0, O3MaxHour = 0, O3AQI = 0,
                SO2Mean = 0f, SO2MaxValue = 0, SO2MaxHour = 0, SO2AQI = 0, 
                COMean = 0f, COMaxValue = 0, COMaxHour = 0, COAQI = 0 });
                _context.SaveChanges();
            }
        }

        // GET: api/pollution
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Marker>>> GetTodoItems()
        {
            return await _context.Markers.ToListAsync();
        }

        // GET: api/pollution/"year"
        
        [HttpGet("{date}")] 
        public async Task<ActionResult<IEnumerable<Marker>>> GetTodoItem(string date)
        {

            var todoItem = await _context.Markers.Where(x => x.PollutionDate.ToString("yyyy-MM-dd").Contains(date)).ToListAsync();

            // var todoItem = await _context.Markers.FindAsync(date);

            // if (todoItem == null)
            // {
            //     return NotFound();
            // }

            return todoItem;
        }

    }
}