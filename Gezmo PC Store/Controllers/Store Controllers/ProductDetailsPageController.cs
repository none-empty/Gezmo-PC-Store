using Gezmo_PC_Store.DataBaseModels;
using Gezmo_PC_Store.Models;
using Gezmo_PC_Store.Services;
using Microsoft.AspNetCore.Mvc;
  
namespace Gezmo_PC_Store.Controllers.Store_Controllers;

public class ProductDetailsPageController:BaseController
{
    public ProductDetailsPageController(IGlobalsHelper globalsHelper, IDataProvider dataProvider) : base(globalsHelper, dataProvider)
    {
    }

    public IActionResult ProductDetails(int product_id)
    {
        return View(new ProductDetailsModel{Prod = _dataProvider.GetByIdAsync(product_id).Result});
    }
    [HttpPost]
    public JsonResult AddToCart([FromBody] CartItemRequest request)
    {
        try
        {
            // Retrieve or initialize the cart
            var glob = ViewData["Globals"] as GlobalModels;
            var cart = glob.cart;

            // Add or update the item in the cart
            var existingItem = cart.Items.FirstOrDefault(c => c.item.ProductID == request.ItemId);
            if (existingItem != null)
            {
                existingItem.quantity += request.Quantity; // Update quantity if the item exists
            }
            else
            {
                var prod=_dataProvider.GetByIdAsync(request.ItemId).Result;
                if (prod.Stock < request.Quantity) throw new Exception("Item does not have enough stock");
                cart.Items.Add(new CartItem { item = new Item{ProductID = prod.ProductId,
                                              ProductName = prod.Name
                                              ,ImageUrl = prod.ImageUrl,
                                              Price = prod.Price
                                          },
                    quantity = request.Quantity });
            }
            glob.cart = cart;
             
            // Save the cart back
            ViewData["Globals"] = glob;
            
           _globalsHelper.SetGlobals(HttpContext,glob);
          
          
           return Json(new { success = true });
        }
        catch (Exception ex)
        {
            return Json(new { success = false, message = ex.Message });
        }
    }
    
}
public class CartItemRequest
{
    public int ItemId { get; set; }  
    public int Quantity { get; set; }  
}