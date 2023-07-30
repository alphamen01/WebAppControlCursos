using System;
using System.Collections.Generic;

namespace WebAppControlCursos.Models
{
    public class PagerMaterial
    {
        /*
        public List<Course> Courses { get; set; } = new List<Course>();
        public int Pages { get; set; }
        public int CurrentPage { get; set; }
        public int Records { get; set; }
        */

        public List<Material> Materials { get; set; } = new List<Material>();

        public int TotalItems { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize {get; set; }
        public int TotalPages { get; set; }
        public int StartPage { get; set; }
        public int EndPage { get; set; }

        public PagerMaterial()
        {
            
        }

        public PagerMaterial(int totalItems, int page, int pageSize )
        {
            int totalPages = (int)Math.Ceiling((decimal)totalItems / (decimal)pageSize);
            int currentPage = page;

            int startPage = currentPage - 5;
            int endPage = currentPage + 4;

            if (startPage <= 0)
            {
                endPage = endPage - (startPage - 1);
                startPage = 1;
            }

            if (endPage > totalPages)
            {
                endPage = totalPages;
                if (endPage > 10)
                {
                    startPage = endPage - 9;
                }
            }

            TotalItems = totalItems;
            CurrentPage = currentPage;
            PageSize = pageSize;
            TotalPages = totalPages;
            StartPage = startPage;
            EndPage = endPage;
            

        }


    }
}
