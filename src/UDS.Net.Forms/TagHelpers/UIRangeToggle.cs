using System;
namespace UDS.Net.Forms.TagHelpers
{
    public class UIRangeToggle : UIRangeToggleBase
    {
        public List<UIRangeBehavior> Behaviors { get; } = new();

        public UIRangeToggle()
        {
        }
    }
}

