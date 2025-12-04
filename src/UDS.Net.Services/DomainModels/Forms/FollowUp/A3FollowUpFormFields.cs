using UDS.Net.Dto;

namespace UDS.Net.Services.DomainModels.Forms.FollowUp
{
    public class A3FollowUpFormFields : A3FormFields
    {
        public int? NWINFPAR { get; set; }
        public int? NWINFSIB { get; set; }
        public int? NWINFKID { get; set; }

        public A3FollowUpFormFields() : base()
        {
        }

        public A3FollowUpFormFields(FormDto dto) : base(dto)
        {
            if (dto is A3Dto)
            {
                //NWINFPAR = dto.NWINFPAR == true ? 1 : dto.NWINFPAR == false ? 0 : (int?)null;
                //NWINFSIB = dto.NWINFSIB == true ? 1 : dto.NWINFSIB == false ? 0 : (int?)null;
                //NWINFKID = dto.NWINFKID == true ? 1 : dto.NWINFKID == false ? 0 : (int?)null;
            }
        }
    }
}
