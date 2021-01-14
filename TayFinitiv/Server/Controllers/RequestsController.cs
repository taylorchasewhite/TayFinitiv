using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TayFinitiv.Database;
using TayFinitiv.Shared;

namespace TayFinitiv.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly TellerService _tellerService;
        public RequestsController(ApplicationDbContext context, TellerService tellerService)
        {
            _context = context;
            _tellerService = tellerService;
        }

        // GET: api/requests
        /// <summary>
        /// Get the history of withdrawal requests at this ATM
        /// </summary>
        /// <returns>IEnumerable collection of withdraw requests</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WithdrawRequest>>> GetRequests()
        {
            return await _context.Requests.ToListAsync();
        }

        // GET: api/requests/overview
        /// <summary>
        /// Get the overview of the remaining bills in the ATM, in order to understand how much money can be requested.
        /// </summary>
        /// <returns>IEnumerable collection of withdraw requests</returns>
        [HttpGet("overview")]
        public async Task<ActionResult<Dictionary<Denomination,int>>> GetOverview()
        {
            return Ok(_tellerService.GetOverview());
        }

        // POST: api/requests/reset
        /// <summary>
        /// Reset the ATM such that there are 10 bills of each denomination in the ATM and the withdraw
        /// history is erased clean.
        /// </summary>
        /// <returns>IEnumerable collection of withdraw requests</returns>
        [HttpPost("reset")]
        public async Task<ActionResult<Dictionary<Denomination, int>>> PostReset()
        {
            return Ok(_tellerService.FactoryReset());
        }

        // POST: api/requests/restock
        /// <summary>
        /// Restock the bills in the ATM
        /// </summary>
        /// <returns>IEnumerable collection of withdraw requests</returns>
        [HttpPost("restock")]
        public async Task<ActionResult<Dictionary<Denomination,int>>> PostRestock(RestockRequest bills)
        {
            return Ok(_tellerService.Restock(bills));
        }

        // GET: api/requests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WithdrawRequest>> GetWithdrawRequest(string id)
        {
            var withdrawRequest = await _context.Requests.FindAsync(id);

            if (withdrawRequest == null)
            {
                return NotFound();
            }

            return withdrawRequest;
        }

        // POST: api/requests
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WithdrawRequest>> PostWithdrawRequest(WithdrawRequest withdrawRequest)
        {
            string response;
            try
            {
                response = _tellerService.Withdraw(withdrawRequest);
            }
            catch (DbUpdateException)
            {
                if (WithdrawRequestExists(withdrawRequest.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetWithdrawRequest", new { id = withdrawRequest.Id }, withdrawRequest);
        }

        // DELETE: api/requests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWithdrawRequest(string id)
        {
            var withdrawRequest = await _context.Requests.FindAsync(id);
            if (withdrawRequest == null)
            {
                return NotFound();
            }

            _context.Requests.Remove(withdrawRequest);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WithdrawRequestExists(string id)
        {
            return _context.Requests.Any(e => e.Id == id);
        }
    }
}
