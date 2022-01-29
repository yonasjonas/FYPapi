using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Helpers;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("/businesses")]
    public class BusinessesController : BaseController
    {
        public readonly DataContext _context;

        public BusinessesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BusinessModel>>> GetBusinessServices()
        {
            return await _context.Businesses.ToListAsync();
        }

        // GET: api/Businesss/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BusinessModel>> GetBusinessService(int id)
        {
            var businesses = await _context.Businesses.FindAsync(id);

            if (businesses == null)
            {
                return NotFound();
            }

            return businesses;
        }

        /* [HttpGet("business/{businessId}")]
        public async Task<ActionResult<BusinessModel>> GetBusinessServiceByBusinessID(int businessId)
        {
            var businessService = await _context.BusinessServices.FirstOrDefaultAsync(i => i.businessId == businessId);

            if (businessService == null)
            {
                return NotFound();
            }

            return businessService;
        } */

        // PUT: api/BusinessServices/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBusiness(int id, BusinessModel businessService)
        {
            businessService.id = id;
            _context.Entry(businessService).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusinessExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        // POST: api/BusinessServices
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BusinessModel>> PostBusiness(BusinessModel businesses)
        {
            _context.Businesses.Add(businesses);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBusiness", new { id = businesses.id }, businesses);
        }

        // DELETE: api/BusinessServices/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BusinessModel>> DeleteBusinessService(int id)
        {
            var businesses = await _context.Businesses.FindAsync(id);
            if (businesses == null)
            {
                return NotFound();
            }

            _context.Businesses.Remove(businesses);
            await _context.SaveChangesAsync();

            return businesses;
        }

        private bool BusinessExists(int id)
        {
            return _context.BusinessServices.Any(e => e.id == id);
        }
    }
}

