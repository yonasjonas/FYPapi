using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("/api/businessinfo")]
    public class BusinessInfoController : BaseController
    {
        

        public readonly DataContext _context;

        public BusinessInfoController(DataContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.BusinessInfoModel>>> GetBusinesses()
        {
            var accounts = await _context.BusinessInfo.ToListAsync();
            return Ok(accounts);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<BusinessInfoModel>>> GetBusinessServices(int id)
        {
            return await _context.BusinessInfo.Where(x => x.Id == id).ToListAsync();
        }
    }
}
