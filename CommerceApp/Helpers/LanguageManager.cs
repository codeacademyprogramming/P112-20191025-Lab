using CommerceApp.DAL;
using CommerceApp.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;

namespace CommerceApp.Helpers
{
    public class LanguageManager
    {
        static AppDbContext db = new AppDbContext();



        public static bool IsLanguageAvailable(string lang)
        {
            Language language = db.Languages.FirstOrDefault(l => l.Code.ToLower() == lang.ToLower());
            if (language == null)
            {
                return false;
            }
            return true;
        }


        public static string GetDefaultLanguage()
        {
            return db.Languages.FirstOrDefault().Code;
        }

        public void SetLanguage(string lang)
        {
            if (!IsLanguageAvailable(lang))
            {
                lang = GetDefaultLanguage();
            }

            var cultureInfo = new CultureInfo(lang);
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureInfo.Name);

            HttpCookie langCookie = new HttpCookie("saytimin_dili", lang);
            langCookie.Expires = DateTime.Now.AddYears(1);
            HttpContext.Current.Response.Cookies.Add(langCookie);
        }
    }
}