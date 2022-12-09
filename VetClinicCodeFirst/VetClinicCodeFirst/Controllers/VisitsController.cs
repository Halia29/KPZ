using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VetClinicCodeFirst.Data;
using VetClinicCodeFirst.Models;

namespace VetClinicCodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitsController : ControllerBase
    {
        private readonly VetClinicContext _context;

        public VisitsController(VetClinicContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Visit>>> GetVisit()
        {
            return await _context.Visit.Include(pet => pet.patient).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Visit>> GetVisit(int id)
        {
            var visit = await _context.Visit.Include(pet => pet.patient).FirstOrDefaultAsync(ids => ids.VisitId == id);

			if (visit == null)
            {
                return NotFound();
            }

            return visit;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutVisit(int id, Visit visit)
        {
            if (id != visit.VisitId)
            {
                return BadRequest();
            }

            _context.Entry(visit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VisitExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(visit);
        }

        [HttpPost]
        public async Task<ActionResult<Visit>> PostVisit(Visit visit)
        {
            _context.Visit.Add(visit);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVisit", new { id = visit.VisitId }, visit);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<IEnumerable<Visit>>> DeleteVisit(int id)
        {
            var visit = await _context.Visit.FindAsync(id);
            if (visit == null)
            {
                return NotFound();
            }

            _context.Visit.Remove(visit);
            await _context.SaveChangesAsync();

            return await _context.Visit.Include(pet => pet.patient).ToListAsync();
		}

        private bool VisitExists(int id)
        {
            return _context.Visit.Any(e => e.VisitId == id);
        }
    }
}
