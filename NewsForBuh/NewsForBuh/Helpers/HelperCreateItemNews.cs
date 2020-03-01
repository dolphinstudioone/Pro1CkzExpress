using System;
using System.Collections.Generic;
using System.Text;
using NewsForBuh.ViewModels;

namespace NewsForBuh.Helpers
{
    public static class HelperCreateItemNews
    {
        public static string SectionNewsFromURL(string Url) 
        {
            string returnSection;
            switch (Url.Split(new char[] { '/' })[2]) 
            {
                case "avtomatizatsiya": returnSection = "Автоматизация"; break;
                case "zakonodatelstvo": returnSection = "Законодательство"; break;
                default: returnSection = ""; break;

            }
            return returnSection;
        }
    }
}
