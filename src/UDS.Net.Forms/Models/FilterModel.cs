using Microsoft.AspNetCore.Mvc.Rendering;

namespace UDS.Net.Forms.Models
{
    public class FilterModel
    {
        public List<SelectListItem> FilterList { get; set; } = new List<SelectListItem>();
        public List<string> SelectedItems { get; set; } = new List<string>();

        public FilterModel(Array items)
        {
            if (items.Length > 0)
            {
                foreach (var item in items)
                {
                    FilterList.Add(new SelectListItem
                    {
                        Text = item.ToString(),
                        Selected = false
                    });
                }
            }
        }
    }
}