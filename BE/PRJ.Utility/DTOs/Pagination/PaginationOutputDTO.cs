﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJ.Utility.DTOs.Pagination
{
    public class PaginationOutputDTO<T> : PaginationDTO
    {
        public int? TotalCounts { get; set; }

        public List<T>? List { get; set; }
    }
}
