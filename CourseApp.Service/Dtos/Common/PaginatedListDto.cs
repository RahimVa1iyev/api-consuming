using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Service.Dtos.Common
{
    public class PaginatedListDto<T>
    {

        public PaginatedListDto(List<T> ıtems, int pageIndex, int pageSize , int totalCount)
        {
            Items = ıtems;
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(totalCount /(double)pageSize);
        }

        public List<T> Items { get; set; }

        public int PageIndex { get; set; }

        public int TotalPages { get; set; }

        public bool HasPrev => PageIndex > 1;

        public bool HasNext => PageIndex < TotalPages;



    }
}
