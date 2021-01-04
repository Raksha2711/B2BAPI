using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Admin.API.Model;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;


namespace Admin.API.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class verticalsController : ControllerBase
    {
        //private readonly TodoContext _context;
        private IRepositoryWrapper _repoWrapper;
        public verticalsController(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }
        [HttpGet]
        public IEnumerable<CategoryMaster> Get()
        {
            var data = _repoWrapper.Category.FindAll();
            return data;

        }
        // GET: api/Categories
        //[HttpGet]
        //public IActionResult GetCategory([FromQuery] OwnerParameters ownerParameters)
        //{
        //    var owners = _context.CategoryMaster.GetCategory(ownerParameters);
        //    var metadata = new
        //    {
        //        owners.TotalCount,
        //        owners.PageSize,
        //        owners.CurrentPage,
        //        owners.TotalPages,
        //        owners.HasNext,
        //        owners.HasPrevious
        //    };
        //    Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
        //    //_logger.LogInfo($"Returned {owners.TotalCount} owners from database.");
        //    return Ok(owners);
        //}
        //[HttpGet]
        //public IActionResult GetCategory([FromQuery] OwnerParameters ownerParameters)
        //{
        //    var owners = _context.CategoryMaster.GetOwners(ownerParameters);
        //    ILogger.LogInfo($"Returned {owners.Count()} owners from database.");
        //    return Ok(owners);
        //}
        //// GET: api/Categories/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<CategoryMaster>> GetCategory(int id)
        //{
        //    var category = await _context.CategoryMaster.FindAsync(id);

        //    if (category == null)
        //    {
        //        return NotFound();
        //    }

        //    return category;
        //}

        //// PUT: api/Categories/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutCategory(int id, CategoryMaster category)
        //{
        //    if (id != category.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(category).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CategoryExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Categories
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<CategoryMaster>> PostCategory(CategoryMaster category)
        //{
        //    _context.CategoryMaster.Add(category);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction(nameof(GetCategory), new { id = category.Id }, category);
        //}

        //// DELETE: api/Categories/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteCategory(int id)
        //{
        //    var category = await _context.CategoryMaster.FindAsync(id);
        //    if (category == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.CategoryMaster.Remove(category);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool CategoryExists(int id)
        //{
        //    return _context.CategoryMaster.Any(e => e.Id == id);
        //}
    }
}
