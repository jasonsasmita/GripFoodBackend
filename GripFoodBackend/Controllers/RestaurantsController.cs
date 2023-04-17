﻿using System;
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
    public class RestaurantsController : ControllerBase
    {
        private readonly GripFoodDbContext _context;

        public RestaurantsController(GripFoodDbContext context)
        {
            _context = context;
        }

        // GET: api/Restaurants
        [HttpGet]
        public async Task<ActionResult<List<Restaurant>>> GetRestaurants()
        {
            if (_context.Restaurants == null)
            {
                return NotFound();
            }

            var query = _context.Restaurants.AsNoTracking();
            return await query.ToListAsync();
        }

        // GET: api/Restaurants/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<RestaurantDetailModel>>> GetRestaurant(string id)
        {
            if (_context.Restaurants == null)
            {
                return NotFound();
            }
            var restaurant = await _context.FoodItems.AsNoTracking().Where(x => x.RestaurantId == id)
                .Select( x => new RestaurantDetailModel
                            {
                                Id = x.Id,
                                Name = x.Name,
                                Price = x.Price
                            }
                       ).ToListAsync();

            if (restaurant == null)
            {
                return NotFound();
            }

            return restaurant;
        }

  

    }
}
