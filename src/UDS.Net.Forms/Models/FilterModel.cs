namespace UDS.Net.Forms.Models
{
    public class FilterModel
    {
        public List<FilterItemModel> FilterList { get; set; } = new List<FilterItemModel>();
        public List<string> SelectedItems { get; set; } = new List<string>();

        //Constructor for creating a new filterModel using existing FilterModel data
        public FilterModel(List<string> items, List<string>? selectedItems = null)
        {
            /********** Set selected items ********/
            //if selectedItems is null, then add all items to selectedItems list
            if (selectedItems == null || selectedItems.Count == 0)
            {
                SelectedItems.AddRange(items);
            }
            else if (selectedItems.Count() == 1 && selectedItems.Any(i => i.Contains(",")))
            {
                //selectedItems can be a single comma delimeted string item or multi item list from selectedItems
                //If it is a single delimeted string item, seperate into a list
                SelectedItems = selectedItems[0].Split(',').ToList();
            }
            else
            {
                // more than one item is selected and its already split into an array
                SelectedItems = selectedItems;
            }

            /********** Set the list ********/
            foreach (var item in items)
            {
                FilterList.Add(new FilterItemModel
                {
                    Text = String.IsNullOrWhiteSpace(item) ? "Item" : item,
                    Selected = SelectedItems.Contains(item) // if item is null or item is empty string then we want it to be set as false
                });
            }
        }
    }
}