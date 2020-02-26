using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using NewsForBuh.Models;
using AngleSharp;

namespace NewsForBuh.Services
{
    public class ParserNews
    {
         async public void ParseDataSite()
        {

            var config = Configuration.Default.WithDefaultLoader();
            var address = "https://pro1c.kz/news/zakonodatelstvo/";
            var context = BrowsingContext.New(config);
            var document = await context.OpenAsync(address);
            var idblock = document.QuerySelectorAll("[id*='bx_6']");



            foreach (var el in idblock)
            {


                itemNews newsOne = new itemNews
                {
                    Idbx = el.GetAttribute("id").ToString(),
                    Date = el.QuerySelector("small").TextContent ,
                    Link = el.QuerySelector("h3.news_title > a").GetAttribute("href").ToString(),
                    Title = el.QuerySelector("h3.news_title").TextContent.ToString(),
                    Views = Convert.ToInt32(el.QuerySelector("li > a").TextContent.ToString()),
                    Read = false,
                    Bookmark = false
                };

                var searchNews = new itemNews();
                searchNews = await App.Database.ReturnFindItemNews(newsOne);
                if (searchNews != null)
                { 
                    await App.Database.UpdateNewsAsync(searchNews);
                }
                else
                {
                    await App.Database.AddNewsAsync(newsOne);
                }





            }
        }
    }
}
