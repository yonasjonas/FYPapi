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
    [Route("api")]
    public class ServicesController : BaseController
    {
        public readonly DataContext _context;

        public ServicesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BusinessServiceModel>>> GetBusinessServices()
        {
            return await _context.BusinessServices.ToListAsync();
        }

        // GET: api/BusinessServices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BusinessServiceModel>> GetBusinessService(int id)
        {
            var businessService = await _context.BusinessServices.FindAsync(id);

            if (businessService == null)
            {
                return NotFound();
            }

            return businessService;
        }

        // PUT: api/BusinessServices/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBusinessService(int id, BusinessServiceModel businessService)
        {
            businessService.id = id;
            _context.Entry(businessService).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusinessServiceExists(id))
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
        public async Task<ActionResult<BusinessServiceModel>> PostBusinessService(BusinessServiceModel businessService)
        {
            _context.BusinessServices.Add(businessService);
            await _context.SaveChangesAsync();

            var local = CreatedAtAction("GetBusinessService", new { id = businessService.id }, businessService);

            return local;
        }

        // DELETE: api/BusinessServices/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BusinessServiceModel>> DeleteBusinessService(int id)
        {
            var businessService = await _context.BusinessServices.FindAsync(id);
            if (businessService == null)
            {
                return NotFound();
            }

            _context.BusinessServices.Remove(businessService);
            await _context.SaveChangesAsync();

            return businessService;
        }

        private bool BusinessServiceExists(int id)
        {
            return _context.BusinessServices.Any(e => e.id == id);
        }
    }
}

