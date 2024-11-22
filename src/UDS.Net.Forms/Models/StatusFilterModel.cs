using Microsoft.AspNetCore.Mvc.Rendering;
using UDS.Net.Services.Enums;

namespace UDS.Net.Forms.Models
{
    public class StatusFilterModel
    {
        public List<SelectListItem> StatusList { get; set; } = new List<SelectListItem>();

        public List<string> PacketStatuses { get; set; } = Enum.GetNames(typeof(PacketStatus)).ToList();

        //public string[] StatusList { get; set; } = new string[] {
        //    PacketStatus.Pending.ToString(),
        //    PacketStatus.FailedErrorChecks.ToString()
        //};

        private int _statusCount;

        public int SelectedStatusCount
        {
            get
            {
                int i = 0;
                foreach (var status in StatusList)
                {
                    if (status.Selected)
                        i++;
                }
                return i;
            }
            set => _statusCount = value;
        }

        private string? _statusListString;

        public string? StatusListString
        {
            get
            {
                return string.Join(",", StatusList);
            }
            set => _statusListString = value;
        }


        public string[] ToArray()
        {
            List<string> selected = new List<string>();

            foreach (var checkbox in StatusList)
            {
                if (checkbox.Selected)
                    selected.Add(checkbox.Value);
            }

            return selected.ToArray();
        }
    }
}