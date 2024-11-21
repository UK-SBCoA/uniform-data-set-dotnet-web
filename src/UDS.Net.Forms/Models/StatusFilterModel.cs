using UDS.Net.Services.Enums;

namespace UDS.Net.Forms.Models
{
    public class StatusFilterModel
    {
        public List<string> PacketStatuses { get; set; } = Enum.GetNames(typeof(PacketStatus)).ToList();
        public string[] StatusList { get; set; } = [PacketStatus.Pending.ToString(), PacketStatus.FailedErrorChecks.ToString()];

        private int _statusCount;

        public int StatusCount
        {
            get
            {
                return StatusList.Length;
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
    }
}