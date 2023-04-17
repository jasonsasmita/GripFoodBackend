using GripFoodBackend.Models;
using GripFoodEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GripFoodBackend.Controllers
{
    [Route("api/add-to-cart")]
    [ApiController]
    public class AddToCart : ControllerBase
    {
        private readonly GripFoodDbContext _context;

        public AddToCart(GripFoodDbContext context)
        {
            _context = context;
        }

        //POST api/add-to-cart
        [HttpPost("{id}", Name = "AddtoCart")]
        public async Task<ActionResult<Cart>> Post(AddToCartModel addToCart)
        {
            if (_context.Carts == null)
            {
                return Problem("Entity set 'Carts'  is null.");
            }
/*            User currentUser = await client.UsersManager.GetCurrentUserInformationAsync();*/
            var newCart = new Cart
            {
                Id = Ulid.NewUlid().ToString(),
/*                UserId = currentUser.Id,*/
            };
            var newCartDetail = new CartDetail
            {
                Id = Ulid.NewUlid().ToString(),
                CartId = newCart.Id,
                FoodItemId = addToCart.FoodItemId,
                Qty = addToCart.Qty
            };
            _context.Carts.Add(newCart);
            _context.CartDetails.Add(newCartDetail);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CartOnRestaurantExists(newCart.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return newCart;
        }

        private bool CartOnRestaurantExists(string id)
        {
            return (_context.Carts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
