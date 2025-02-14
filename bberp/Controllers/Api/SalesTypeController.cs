﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BBERP.Data;
using BBERP.Models;
using BBERP.Models.SyncfusionViewModels;
using Microsoft.AspNetCore.Authorization;

namespace BBERP.Controllers.Api
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/SalesType")]
    public class SalesTypeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SalesTypeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/SalesType
        [HttpGet]
        public async Task<IActionResult> GetSalesType()
        {
            List<SalesType> Items = await _context.SalesType.ToListAsync();
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }


        [HttpPost("[action]")]
        public IActionResult Insert([FromBody]CrudViewModel<SalesType> payload)
        {
            SalesType salesType = payload.value;
            _context.SalesType.Add(salesType);
            _context.SaveChanges();
            return Ok(salesType);
        }

        [HttpPost("[action]")]
        public IActionResult Update([FromBody]CrudViewModel<SalesType> payload)
        {
            SalesType salesType = payload.value;
            _context.SalesType.Update(salesType);
            _context.SaveChanges();
            return Ok(salesType);
        }

        [HttpPost("[action]")]
        public IActionResult Remove([FromBody]CrudViewModel<SalesType> payload)
        {
            SalesType salesType = _context.SalesType
                .Where(x => x.SalesTypeId == (int)payload.key)
                .FirstOrDefault();
            _context.SalesType.Remove(salesType);
            _context.SaveChanges();
            return Ok(salesType);

        }
    }
}