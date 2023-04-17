using GripFoodEntities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GripFoodBackend.Controllers
{
    [Route("api/finish-order")]
    [ApiController]
    public class FinishOrder : ControllerBase
    {
        private readonly GripFoodDbContext _context;

        public FinishOrder(GripFoodDbContext context)
        {
            _context = context;
        }

        // DELETE api/<FinishOrder>/5
        [HttpDelete("{id}", Name = "FinishOrder")]
        public async Task<IActionResult> DeleteOrder(string id)
        {
            if (_context.Carts == null)
            {
                return NotFound();
            }
            var order = await _context.Carts.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            _context.Carts.Remove(order);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

