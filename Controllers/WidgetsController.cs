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
    [Route("/widgets")]
    public class WidgetsController : BaseController
    {
        public readonly DataContext _context;

        public WidgetsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WidgetModel>>> GetWidgetServices()
        {
            return await _context.Widget.ToListAsync();
        }

        // GET: api/Widgets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WidgetModel>> GetWidgetService(int id)
        {
            var widgetService = await _context.Widget.FindAsync(id);

            if (widgetService == null)
            {
                return NotFound();
            }

            return widgetService;
        }

        // PUT: api/WidgetsService/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWidget(int id, WidgetModel widgetService)
        {
            widgetService.id = id;
            _context.Entry(widgetService).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WidgetExists(id))
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

        // POST: api/WidgetsService
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<WidgetModel>> PostWidget(WidgetModel widgetService)
        {
            _context.Widget.Add(widgetService);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWidget", new { id = widgetService.id }, widgetService);
        }

        // DELETE: api/WidgetsService/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WidgetModel>> DeleteWidgetService(int id)
        {
            var widgetService = await _context.Widget.FindAsync(id);
            if (widgetService == null)
            {
                return NotFound();
            }

            _context.Widget.Remove(widgetService);
            await _context.SaveChangesAsync();

            return widgetService;
        }

        private bool WidgetExists(int id)
        {
            return _context.Widget.Any(e => e.id == id);
        }
    }
}

