﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stores.API.Data;
using Stores.Shared.Entities;

namespace Stores.API.Controllers
{
    [ApiController]
    [Route("/api/countries")]
    public class CountriesController:ControllerBase
    {
        private readonly DataContext _context;

        public CountriesController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult>Post(Country country)
        {

            _context.Add(country);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]

        public async Task<ActionResult>Get(){
            return Ok(await _context.Countries.ToListAsync());
        }
    }
}
