using System;
using System.Collections.Generic;
using System.Linq;

namespace CrossCutingLayer.Utils
{
    public class PaginatedList<T>
    {
        public int CurrentPage { get; private set; }
        public int TotalPages { get; private set; }
        public int PageSize { get; private set; }
        public List<T> Items { get; private set; }

        public PaginatedList(List<T> items, int currentPage, int pageSize)
        {
            CurrentPage = currentPage;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling(items.Count / (double)PageSize);

            Items = items.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList();
        }

        public bool HasPreviousPage
        {
            get { return CurrentPage > 1; }
        }

        public bool HasNextPage
        {
            get { return CurrentPage < TotalPages; }
        }
    }
}