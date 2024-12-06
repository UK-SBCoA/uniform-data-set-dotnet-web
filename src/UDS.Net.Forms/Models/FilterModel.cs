namespace UDS.Net.Forms.Models
{
    public class FilterModel
    {
        public List<FilterItemModel> FilterList { get; set; } = new List<FilterItemModel>();
        public List<string> SelectedItems { get; set; } = new List<string>();

        public FilterModel(Array? items = null)
        {
            // Allowing null items default for use with the mapper extensions.
            // Mapper functions MUST be able to create a new object without values
            if (items != null)
            {
                if (items.Length > 0)
                {
                    foreach (var item in items)
                    {
                        FilterList.Add(new FilterItemModel
                        {
                            Text = item.ToString(),
                            Selected = false
                        });
                    }
                }
            }
        }
    }
}