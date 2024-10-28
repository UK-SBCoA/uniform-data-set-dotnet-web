using System;
namespace UDS.Net.Forms.Models
{
    public class PaginatedModel
    {
        public bool HasPreviousPage
        {
            get
            {
                return (PageIndex > 1);
            }
        }
        public bool HasNextPage
        {
            get
            {
                return (PageIndex < TotalPages);
            }
        }
        public int PageSize { get; set; } = 10;
        public int PageIndex { get; set; } = 1;
        public int Total { get; set; } = 0;
        public int TotalPages
        {
            get
            {
                if (Total > 0)
                    return (int)Math.Ceiling(Total / (double)PageSize);

                return 0;
            }
        }
        public int CurrentPageStart
        {
            get
            {
                return ((PageIndex - 1) * PageSize) + 1;
            }
        }
        public int CurrentPageEnd
        {
            get
            {
                if (HasNextPage)
                {
                    return CurrentPageStart + PageSize - 1;
                }
                else
                    return Total;
            }
        }

        public string Search { get; set; } = "";
        public string Action { get; set; } = "Index";
        public int? Id { get; set; } = null; // sometimes the paginated list is a child of the current object, do we might need an id
    }
}

