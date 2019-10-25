using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CommerceApp.Controllers
{
    public class ProductsController : BaseController
    {
        // GET: Products
        public ActionResult Index()
        {

            //string language = this.ControllerContext.RouteData.Values["language"].ToString();
            //return Content(language);

            var lang = Request.Cookies["saytimin_dili"].Value;

            var model = db.ProductTranslates
                .Include("Product")
                .Where(p => p.Language.Code == lang)
                .ToList();


            return View(model);
        }
    }
}