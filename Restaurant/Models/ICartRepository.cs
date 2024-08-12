using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Models
{
    internal interface ICartRepository
    {
        //IEnumerable<CartItem> GetCartItems(string userId);
        void AddItemToCart(string userId, int menuItemId, int quantity);
        void UpdateCartItem(int cartItemId, int quantity);
        void RemoveItemFromCart(int cartItemId);
    }
}
