using CommerceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CommerceApp.Controllers
{
    public class BasketController : Controller
    {
        // GET: Basket
        public JsonResult Index()
        {
            var basket = Session["basket"] as List<BasketItem>;
            return Json(basket, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Add(int id)
        {
            var basket = Session["basket"] as List<BasketItem>;



            if (Session["basket"] == null)
            {
                basket = new List<BasketItem>();
                var item = new BasketItem
                {
                    ProductId = id,
                    Count = 1
                };
                basket.Add(item);
                Session["basket"] = basket;
            } else
            {
                basket = Session["basket"] as List<BasketItem>;

                var existItem = basket.FirstOrDefault(b => b.ProductId == id);

                if (existItem == null)
                {
                    var item = new BasketItem
                    {
                        ProductId = id,
                        Count = 1
                    };
                    basket.Add(item);

                }
                else
                {
                    existItem.Count++;
                }

                Session["basket"] = basket;


            }


            return Json(basket, JsonRequestBehavior.AllowGet);

        }
        
    }
}