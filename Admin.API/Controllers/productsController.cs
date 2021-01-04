using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Admin.API.Model;

namespace Admin.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class productsController : ControllerBase
    {
        private readonly TodoContext _context;

        public productsController(TodoContext context)
        {
            _context = context;
        }

        // GET: api/products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubCategoryMaster>>> GetSubCategoryMaster()
        {
            return await _context.SubCategoryMaster.ToListAsync();
        }

        // GET: api/products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SubCategoryMaster>> GetSubCategoryMaster(int id)
        {
            var subCategoryMaster = await _context.SubCategoryMaster.FindAsync(id);

            if (subCategoryMaster == null)
            {
                return NotFound();
            }

            return subCategoryMaster;
        }

        // PUT: api/products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubCategoryMaster(int id, SubCategoryMaster subCategoryMaster)
        {
            if (id != subCategoryMaster.Id)
            {
                return BadRequest();
            }

            _context.Entry(subCategoryMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubCategoryMasterExists(id))
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

        // POST: api/products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SubCategoryMaster>> PostSubCategoryMaster(SubCategoryMaster subCategoryMaster)
        {
            _context.SubCategoryMaster.Add(subCategoryMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSubCategoryMaster", new { id = subCategoryMaster.Id }, subCategoryMaster);
        }

        // DELETE: api/products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubCategoryMaster(int id)
        {
            var subCategoryMaster = await _context.SubCategoryMaster.FindAsync(id);
            if (subCategoryMaster == null)
            {
                return NotFound();
            }

            _context.SubCategoryMaster.Remove(subCategoryMaster);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SubCategoryMasterExists(int id)
        {
            return _context.SubCategoryMaster.Any(e => e.Id == id);
        }
    }
}
