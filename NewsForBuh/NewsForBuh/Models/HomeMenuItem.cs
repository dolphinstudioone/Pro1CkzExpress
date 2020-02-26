using System;
using System.Collections.Generic;
using System.Text;

namespace NewsForBuh.Models
{
    public enum MenuItemType
    {
        News ,
        Bookmarks,
        Settings,
        About
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
