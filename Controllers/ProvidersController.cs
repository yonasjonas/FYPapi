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
    [Route("/providers")]
    public class ProvidersController : BaseController
    {
        public readonly DataContext _context;

        public ProvidersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProviderModel>>> GetProviderServices()
        {
            return await _context.ProviderServices.ToListAsync();
        }

        // GET: api/Providers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProviderModel>> GetProviderService(int id)
        {
            var providerService = await _context.ProviderServices.FindAsync(id);

            if (providerService == null)
            {
                return NotFound();
            }

            return providerService;
        }

        [HttpGet("business/{businessId}")]
        public async Task<ActionResult<ProviderModel>> GetProviderServiceByBusinessID(int businessId)
        {
            var providerService = await _context.ProviderServices.FirstOrDefaultAsync(i => i.businessId == businessId);

            if (providerService == null)
            {
                return NotFound();
            }

            return providerService;
        }

        // PUT: api/ProviderServices/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProvider(int id, ProviderModel providerService)
        {
            providerService.id = id;
            _context.Entry(providerService).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProviderExists(id))
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

        // POST: api/ProviderServices
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ProviderModel>> PostProvider(ProviderModel providerService)
        {
            _context.ProviderServices.Add(providerService);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProvider", new { id = providerService.id }, providerService);
        }

        // DELETE: api/ProviderServices/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProviderModel>> DeleteProviderService(int id)
        {
            var providerService = await _context.ProviderServices.FindAsync(id);
            if (providerService == null)
            {
                return NotFound();
            }

            _context.ProviderServices.Remove(providerService);
            await _context.SaveChangesAsync();

            return providerService;
        }

        private bool ProviderExists(int id)
        {
            return _context.ProviderServices.Any(e => e.id == id);
        }
    }
}

