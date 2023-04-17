using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GripFoodEntities;
using GripFoodBackend.Models;

namespace GripFoodBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly GripFoodDbContext _context;

        public CartsController(GripFoodDbContext context)
        {
            _context = context;
        }


        // GET: api/Carts/5
        [HttpGet("{id}",Name = "GetCart")]
        public async Task<ActionResult<List<Cart>>> GetCart(string id)
        {
            if (_context.Restaurants == null)
            {
                return NotFound();
            }
            var restaurant = await _context.Carts.AsNoTracking().Where(x => x.RestaurantId == id).ToListAsync();
           
            if (restaurant == null)
            {
                return NotFound();
            }

            return restaurant;
        }

    }
}
