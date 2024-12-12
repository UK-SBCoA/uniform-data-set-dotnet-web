namespace UDS.Net.Forms.Models
{
    public class FilterModel
    {
        public List<FilterItemModel> FilterList { get; set; } = new List<FilterItemModel>();
        public List<string> SelectedItems { get; set; } = new List<string>();

        //Constructor for creating a new filterModel using existing FilterModel data
        public FilterModel(List<string> items, List<string>? selectedItems = null)
        {
            //if selected items is not provided, turn it into an empty list. 
            //providing an empty selectedItems argument is NOT a null argument
            if (selectedItems == null)
            {
                selectedItems = new List<string>();
            }

            List<FilterItemModel> itemsList = new List<FilterItemModel>();

            foreach (var item in items)
            {
                string newFilterItemText = item;

                itemsList.Add(new FilterItemModel
                {
                    Text = newFilterItemText,
                    Selected = false
                });
            }

            //if selectedItems is null, then add all items to selectedItems list
            if (selectedItems.Count == 0)
            {
                foreach (var item in itemsList)
                {
                    selectedItems.Add(item.Text);
                }
            }

            //selectedItems can be a single comma delimeted string item or multi item list from selectedItems
            //If it is a single delimeted string item, seperate into a list
            if (selectedItems.Count() == 1)
            {
                selectedItems = selectedItems[0].Split(',').ToList();
            }

            //set selected true in itemsList if item is in selectedItems
            for (var i = 0; i < itemsList.Count(); i++)
            {
                foreach (var item in selectedItems)
                {
                    if (itemsList[i].Text == item)
                    {
                        itemsList[i].Selected = true;
                    }
                }
            }

            FilterList = itemsList;
            SelectedItems = selectedItems;
        }
    }
}