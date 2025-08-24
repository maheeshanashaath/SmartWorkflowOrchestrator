using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Orchestrator.Data;
using Orchestrator.Data.Models;

namespace Orchestrator.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkflowController : ControllerBase
    {
        private readonly OrchestratorDbContext _context;

        public WorkflowController(OrchestratorDbContext context)
        {
            _context = context;
        }

        // GET: api/workflow
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Workflow>>> GetWorkflows()
        {
            return await _context.Workflows.ToListAsync();
        }

        // GET: api/workflow/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Workflow>> GetWorkflow(int id)
        {
            var workflow = await _context.Workflows.FindAsync(id);

            if (workflow == null)
                return NotFound();

            return workflow;
        }

        // POST: api/workflow
        [HttpPost]
        public async Task<ActionResult<Workflow>> CreateWorkflow(Workflow workflow)
        {
            _context.Workflows.Add(workflow);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetWorkflow), new { id = workflow.Id }, workflow);
        }

        // PUT: api/workflow/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWorkflow(int id, Workflow workflow)
        {
            if (id != workflow.Id)
                return BadRequest();

            _context.Entry(workflow).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Workflows.Any(e => e.Id == id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/workflow/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkflow(int id)
        {
            var workflow = await _context.Workflows.FindAsync(id);
            if (workflow == null)
                return NotFound();

            _context.Workflows.Remove(workflow);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
