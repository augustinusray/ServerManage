﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Para
{
    public class PagePara
    {
        public int PageSize { get; set; }

        public int PageIndex { get; set; }

        public string ServerName { get; set; }

        public string Description { get; set; }
    }
}