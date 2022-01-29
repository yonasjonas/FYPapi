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
    [Route("/businessManagers")]
    public class BusinessManagersController : BaseController
    {
        public readonly DataContext _context;

        public BusinessManagersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BusinessManagerModel>>> GetBusinessManager()
        {
            return await _context.BusinessManager.ToListAsync();
        }

        // GET: api/BusinessManagers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BusinessManagerModel>> GetBusinessManagerService(int id)
        {
            var businessManagerService = await _context.BusinessManager.FindAsync(id);

            if (businessManagerService == null)
            {
                return NotFound();
            }

            return businessManagerService;
        }

        // PUT: api/BusinessManager/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBusinessManager(int id, BusinessManagerModel businessManagerService)
        {
            businessManagerService.id = id;
            _context.Entry(businessManagerService).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusinessManagerExists(id))
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

        // POST: api/BusinessManager
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BusinessManagerModel>> PostBusinessManager(BusinessManagerModel businessManagerService)
        {
            _context.BusinessManager.Add(businessManagerService);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBusinessManager", new { id = businessManagerService.id }, businessManagerService);
        }

        // DELETE: api/BusinessManager/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BusinessManagerModel>> DeleteBusinessManagerService(int id)
        {
            var businessManagerService = await _context.BusinessManager.FindAsync(id);
            if (businessManagerService == null)
            {
                return NotFound();
            }

            _context.BusinessManager.Remove(businessManagerService);
            await _context.SaveChangesAsync();

            return businessManagerService;
        }

        private bool BusinessManagerExists(int id)
        {
            return _context.BusinessManager.Any(e => e.id == id);
        }
    }
}

