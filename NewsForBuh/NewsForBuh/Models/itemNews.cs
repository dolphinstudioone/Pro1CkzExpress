using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsForBuh.Models
{  
    [Table("News")]
    public  class itemNews
    {
            [PrimaryKey, AutoIncrement, Column("Id")]
            public int Id { get; set; }

            public string Idbx { get; set; }
            public DateTime Date { get; set; }
            public string Title { get; set; }
            public string Link { get; set; }
            public int Views { get; set; }
            public bool Read { get; set; }
            public bool Bookmark { get; set; }  
            public string SectionNews { get; set; }
    }
}
