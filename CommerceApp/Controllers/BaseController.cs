using CommerceApp.DAL;
using CommerceApp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CommerceApp.Controllers
{
    public class BaseController : Controller
    {
        protected readonly AppDbContext db;

        public BaseController()
        {
            db = new AppDbContext();

           ViewBag.Languages = db.Languages.ToList();
        }


        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        {
            string lang = null;

            HttpCookie langCookie = Request.Cookies["saytimin_dili"];
            if (langCookie != null)
            {
                lang = langCookie.Value;
            }
            else
            {
                var userLanguage = Request.UserLanguages;
                var userLang = userLanguage != null ? userLanguage[0] : "";
                if (userLang != "")
                {
                    lang = userLang;
                }
                else
                {
                    lang = LanguageManager.GetDefaultLanguage();
                }
            }

            new LanguageManager().SetLanguage(lang);

            return base.BeginExecuteCore(callback, state);
        }
    }
}