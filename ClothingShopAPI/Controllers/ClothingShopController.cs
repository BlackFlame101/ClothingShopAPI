using ClothingShopAPI.DataAccess;
using ClothingShopAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClothingShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClothingShopController : ControllerBase
    {
        readonly IDataAccess dataAccess;
        private readonly string DateFormat;
        public ClothingShopController(IDataAccess dataAccess, IConfiguration configuration)
        {
            this.dataAccess = dataAccess;
            DateFormat = configuration["Constants:DateFormat"];
        }

        [HttpGet("GetCategoryList")]
        public IActionResult GetCategoryList()
        {
            var result = dataAccess.GetItemCategories();
            return Ok(result);
        }

        [HttpGet("GetItems")]
        public IActionResult GetItems(string category, string subcategory, int count)
        {
            var result = dataAccess.GetItems(category, subcategory, count);
            return Ok(result);
        }

        [HttpGet("GetItem/{id}")]
        public IActionResult GetItem(int id)
        {
            var result = dataAccess.GetItem(id);
            return Ok(result);
        }

        [HttpPost("RegisterUser")]
        public IActionResult RegisterUser([FromBody] User user)
        {
            user.CreatedAt = DateTime.Now.ToString(DateFormat);
            user.ModifiedAt = DateTime.Now.ToString(DateFormat);

            var result = dataAccess.InsertUser(user);

            string? message;
            if (result) message = "inserted";
            else message = "email not available";
            return Ok(message);
        }

        [HttpPost("LoginUser")]
        public IActionResult LoginUser([FromBody] User user)
        {
            var token = dataAccess.IsUserPresent(user.Email, user.Password);
            if (token == "") token = "invalid";
            return Ok(token);
        }

        [HttpPost("InsertReview")]
        public IActionResult InsertReview([FromBody] Review review)
        {
            review.CreatedAt = DateTime.Now.ToString(DateFormat);
            dataAccess.InsertReview(review);
            return Ok("inserted");
        }

        [HttpGet("GetItemReviews/{ItemId}")]
        public IActionResult GetItemReviews(int ItemId)
        {
            var result = dataAccess.GetItemReviews(ItemId);
            return Ok(result);
        }

        [HttpPost("InsertCartItem/{userid}/{Itemid}")]
        public IActionResult InsertCartItem(int userid, int Itemid)
        {
            var result = dataAccess.InsertCartItem(userid, Itemid);
            return Ok(result ? "inserted" : "not inserted");
        }

        [HttpGet("GetActiveCartOfUser/{id}")]
        public IActionResult GetActiveCartOfUser(int id)
        {
            var result = dataAccess.GetActiveCartOfUser(id);
            return Ok(result);
        }

        [HttpGet("GetAllPreviousCartsOfUser/{id}")]
        public IActionResult GetAllPreviousCartsOfUser(int id)
        {
            var result = dataAccess.GetAllPreviousCartsOfUser(id);
            return Ok(result);
        }

        [HttpGet("GetPaymentMethods")]
        public IActionResult GetPaymentMethods()
        {
            var result = dataAccess.GetPaymentMethods();
            return Ok(result);
        }

        [HttpPost("InsertPayment")]
        public IActionResult InsertPayment(Payment payment)
        {
            payment.CreatedAt = DateTime.Now.ToString();
            var id = dataAccess.InsertPayment(payment);
            return Ok(id.ToString());
        }

        [HttpPost("InsertOrder")]
        public IActionResult InsertOrder(Order order)
        {
            order.CreatedAt = DateTime.Now.ToString();
            var id = dataAccess.InsertOrder(order);
            return Ok(id.ToString());
        }
        [HttpPost("InsertNewItem")]
        public IActionResult InsertNewItem([FromBody] Item item)
        {      
                dataAccess.InsertNewItem(item);
                return Ok("Item inserted successfully.");
        }
        [HttpDelete("DeleteItem/{id}")]
        public IActionResult DeleteItem(int id)
        {      
                var result = dataAccess.DeleteItem(id);

                if (result)
                {
                    return Ok("Item deleted successfully.");
                }
                else
                {
                    return NotFound("Item not found or could not be deleted.");
                } 
        }
        [HttpGet("GetOrdersOfUser/{userId}")]
        public IActionResult GetOrdersOfUser(int userId)
        {       
                var result = dataAccess.GetOrdersOfUser(userId);
                return Ok(result);     
        }
        [HttpGet("GetAllOrders")]
        public IActionResult GetAllOrders()
        {
                var result = dataAccess.GetAllOrders();
                return Ok(result);         
        }
        [HttpGet("GetUsers")]
        public IActionResult GetUsers()
        {           
                var result = dataAccess.GetUsers();
                return Ok(result);   
        }
        [HttpPost("GetPayments")]
        public IActionResult GetPayments([FromBody] Payment payment)
        { 
                var result = dataAccess.GetPayments(payment);
                return Ok(result);        
        }
        [HttpDelete("DeleteCartItem/{userId}/{itemId}")]
        public IActionResult DeleteCartItem(int userId, int itemId)
        {          
                var result = dataAccess.DeleteCartItem(userId, itemId);

                if (result)
                {
                    return Ok("Cart item deleted successfully.");
                }
                else
                {
                    return NotFound("Cart item not found or could not be deleted.");
                }                     
        }

    }
}

