using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GCC.Models
{
    public class Pagination
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int RecordCount { get; set; }
    }
}