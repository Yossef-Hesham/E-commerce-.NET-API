namespace BLL.System
{
    public interface ICartItemManager
    {
        Task AddItemToCart(CartItemWritedto cartItemdto);
        Task<IEnumerable<CartItemReaddto>> GetCartItems();
        Task DeleteCartItem(int id);
        Task UpdateCartItem(int id, int Quantity);

    }
}
    