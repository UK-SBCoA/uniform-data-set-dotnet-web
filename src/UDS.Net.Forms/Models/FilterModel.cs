namespace UDS.Net.Forms.Models
{
    public class FilterModel
    {
        public List<FilterItemModel> FilterList { get; set; } = new List<FilterItemModel>();
        public List<string> SelectedItems { get; set; } = new List<string>();

        public FilterModel(Array items)
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

        //Constructor for creating a new filterModel using existing FilterModel data
        public FilterModel(List<FilterItemModel> items, List<string>? selectedItems = null)
        {
            //if filterQuery is null, then select all filter options and end method
            if (selectedItems == null || selectedItems.Count == 0)
            {
                for (var i = 0; i < items.Count(); i++)
                {
                    selectedItems.Add(items[i].Text);
                }
            }

            //selectedItems can be a single comma delimeted string item or multi item list from selectedItems
            //If it is a single delimeted string item, seperate into a list
            if (selectedItems.Count() == 1)
            {
                selectedItems = selectedItems[0].Split(',').ToList();
            }

            for (var i = 0; i < items.Count(); i++)
            {
                foreach (var item in selectedItems)
                {
                    if (items[i].Text == item)
                    {
                        items[i].Selected = true;
                    }
                }
            }

            FilterList = items;
            SelectedItems = selectedItems;
        }
    }
}