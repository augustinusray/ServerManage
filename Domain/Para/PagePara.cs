using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Para
{
    public class PagePara
    {
        public int Limit { get; set; }

        public int Offset { get; set; }

        public string Search_Name { get; set; }

        public string Search_Description { get; set; }
    }
}
