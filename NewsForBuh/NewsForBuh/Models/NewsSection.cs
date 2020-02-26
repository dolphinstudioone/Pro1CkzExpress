using System;
using System.Collections.Generic;
using System.Text;

namespace NewsForBuh.Models
{
    public enum SectionNewsType
    { 
        all,
        avtomatizatsiya,
        zakonodatelstvo

    }
    public class NewsSection
    {
        public SectionNewsType Id { get; set; }
        public string NameSectionNews { get; set; }
    }
}
