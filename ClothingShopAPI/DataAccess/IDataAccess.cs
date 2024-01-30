using ClothingShopAPI.Models;

namespace ClothingShopAPI.DataAccess
{
    public interface IDataAccess
    {
        List<ItemCategory> GetItemCategories();
        ItemCategory GetItemCategory(int id);
        Offer GetOffer(int id);
        List<Item> GetItems(string category, string subcategory, int count);
        Item GetItem(int id);
        bool InsertUser(User user);
        string IsUserPresent(string email, string password);
        void InsertReview(Review review);
        List<Review> GetItemReviews(int ItemId);
        User GetUser(int id);
        bool InsertCartItem(int userId, int ItemId);
        Cart GetActiveCartOfUser(int userid);
        Cart GetCart(int cartid);
        List<Cart> GetAllPreviousCartsOfUser(int userid);
        List<PaymentMethod> GetPaymentMethods();
        int InsertPayment(Payment payment);
        int InsertOrder(Order order);
        //start here
        void InsertNewItem(Item Item);
        bool DeleteItem(int id);
        List<Order> GetOrdersOfUser(int userId);
        List<Order> GetAllOrders();
        List<User> GetUsers();
        Payment GetPayments(Payment payment);
        bool DeleteCartItem(int userId, int ItemId);

    }
}
