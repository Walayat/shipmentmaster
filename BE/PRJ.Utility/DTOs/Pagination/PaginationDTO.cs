using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJ.Utility.DTOs.Pagination
{
    public class PaginationDTO
    {
        public int PageNo { get; set; } = 1;
        public int Size { get; set; } = 20;
        public string? Search { get; set; }
        public bool IsPagination { get; set; }
    }
}
