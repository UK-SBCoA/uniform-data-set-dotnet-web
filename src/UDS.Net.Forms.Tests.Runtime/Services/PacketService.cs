using UDS.Net.Forms.Tests.Runtime.Data;
using UDS.Net.Services;
using UDS.Net.Services.DomainModels;
using UDS.Net.Services.DomainModels.Forms;
using UDS.Net.Services.DomainModels.Submission;
using UDS.Net.Services.Enums;

namespace UDS.Net.Forms.Tests.Runtime.Services
{
    public class PacketService : IPacketService
    {
        private readonly TestDbContext _context;

        public PacketService(TestDbContext context)
        {
            _context = context;
        }

        public Task<Packet> Add(string username, Packet entity)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Count(string username, List<PacketStatus> statuses)
        {
            //DEVNOTE: Manually set 1 for packet count
            return 1;
        }

        public Task<int> Count(string username)
        {
            throw new NotImplementedException();
        }

        public async Task<Packet> GetById(string username, int id)
        {
            //DEVNOTE: Manually create packet with a submission to use for view
            //var packet = await _context.Packets.FindAsync(id);
            //var packet = new Packet(1, 1, 1, "4", PacketKind.I, DateTime.Now, "TT", PacketStatus.Submitted, DateTime.Now, "test@test.com", null, null, false, new List<Form>(), new List<PacketSubmission>
            //{
            //    new PacketSubmission(1, "17", DateTime.Now, 1, DateTime.Now, "test@test.com", null, null, false, null)
            //});

            var packet = new Packet(1, 1, 1, "4", PacketKind.I, DateTime.Now, "TT", PacketStatus.Submitted, DateTime.Now, "test@test.com", null, null, false, new List<Form>(), new List<PacketSubmission>
            {
                new PacketSubmission(1, "19", DateTime.Now, 1, DateTime.Now, "test@test.com", null, null, false, null)
            });
             
            return packet;
        }

        public Task<Packet> GetPacketWithForms(string username, int id)
        {
            //DEVNOTE: Will need to create data to use with the export here
            //throw new NotImplementedException();

            var packet = new Packet(1, 1, 1, "4", PacketKind.I, DateTime.Now, "TT", PacketStatus.Submitted, DateTime.Now, "test@test.com", null, null, false,
                new List<Form>
                {
                    new Form(1, "A3", true, DateTime.Now, "test@test.com", PacketKind.I)
                },
                new List<PacketSubmission>
                {
                    new PacketSubmission(1, "19", DateTime.Now, 1, DateTime.Now, "test@test.com", null, null, false, null, new List<Form>
                    {
                        //DEVNOTE: Will need to include all forms for the export to write data
                        new Form(1, 1, "A1", "A1", FormStatus.Finalized, DateTime.Now, "TT", FormLanguage.English, FormMode.InPerson, null, null, null, AdministrationFormat.Self, DateTime.Now, "test@test.com", null, null, false, new A1FormFields()),
                        new Form(1, 1, "A1a", "A1a", FormStatus.Finalized, DateTime.Now, "TT", FormLanguage.English, FormMode.InPerson, null, null, null, AdministrationFormat.Self, DateTime.Now, "test@test.com", null, null, false, new A1aFormFields()),
                        new Form(1, 1, "A2", "A2", FormStatus.Finalized, DateTime.Now, "TT", FormLanguage.English, FormMode.InPerson, null, null, null, null, DateTime.Now, "test@test.com", null, null, false, new A2FormFields()),
                        new Form(1, 1, "A3", "A3", FormStatus.Finalized, DateTime.Now, "TT", FormLanguage.English, FormMode.InPerson, null, null, null, null, DateTime.Now, "test@test.com", null, null, false, new A3FormFields()),
                        new Form(1, 1, "A4", "A4", FormStatus.Finalized, DateTime.Now, "TT", FormLanguage.English, FormMode.InPerson, null, null, null, null, DateTime.Now, "test@test.com", null, null, false, new A4GFormFields()),
                        new Form(1, 1, "A4a", "A4a", FormStatus.Finalized, DateTime.Now, "TT", FormLanguage.English, FormMode.InPerson, null, null, null, null, DateTime.Now, "test@test.com", null, null, false, new A4aFormFields()),
                        new Form(1, 1, "A5D2", "A5D2", FormStatus.Finalized, DateTime.Now, "TT", FormLanguage.English, FormMode.InPerson, null, null, null, null, DateTime.Now, "test@test.com", null, null, false, new A5D2FormFields()),
                        new Form(1, 1, "B1", "B1", FormStatus.Finalized, DateTime.Now, "TT", FormLanguage.English, FormMode.InPerson, null, null, null, null, DateTime.Now, "test@test.com", null, null, false, new B1FormFields()),
                        new Form(1, 1, "B3", "B3", FormStatus.Finalized, DateTime.Now, "TT", FormLanguage.English, FormMode.InPerson, null, null, null, null, DateTime.Now, "test@test.com", null, null, false, new B3FormFields()),
                        new Form(1, 1, "B4", "B4", FormStatus.Finalized, DateTime.Now, "TT", FormLanguage.English, FormMode.InPerson, null, null, null, null, DateTime.Now, "test@test.com", null, null, false, new B4FormFields()),
                        new Form(1, 1, "B5", "B5", FormStatus.Finalized, DateTime.Now, "TT", FormLanguage.English, FormMode.InPerson, null, null, null, null, DateTime.Now, "test@test.com", null, null, false, new B5FormFields()),
                        new Form(1, 1, "B6", "B6", FormStatus.Finalized, DateTime.Now, "TT", FormLanguage.English, FormMode.InPerson, null, null, null, null, DateTime.Now, "test@test.com", null, null, false, new B6FormFields()),
                        new Form(1, 1, "B7", "B7", FormStatus.Finalized, DateTime.Now, "TT", FormLanguage.English, FormMode.InPerson, null, null, null, null, DateTime.Now, "test@test.com", null, null, false, new B7FormFields()),
                        new Form(1, 1, "B8", "B8", FormStatus.Finalized, DateTime.Now, "TT", FormLanguage.English, FormMode.InPerson, null, null, null, null, DateTime.Now, "test@test.com", null, null, false, new B8FormFields()),
                        new Form(1, 1, "B9", "B9", FormStatus.Finalized, DateTime.Now, "TT", FormLanguage.English, FormMode.InPerson, null, null, null, null, DateTime.Now, "test@test.com", null, null, false, new B9FormFields()),
                        new Form(1, 1, "C2", "C2", FormStatus.Finalized, DateTime.Now, "TT", FormLanguage.English, FormMode.InPerson, null, null, null, null, DateTime.Now, "test@test.com", null, null, false, new C2FormFields()),
                        new Form(1, 1, "D1a", "D1a", FormStatus.Finalized, DateTime.Now, "TT", FormLanguage.English, FormMode.InPerson, null, null, null, null, DateTime.Now, "test@test.com", null, null, false, new D1aFormFields()),
                        new Form(1, 1, "D1b", "D1b", FormStatus.Finalized, DateTime.Now, "TT", FormLanguage.English, FormMode.InPerson, null, null, null, null, DateTime.Now, "test@test.com", null, null, false, new D1bFormFields())
                    })
                });

            return Task.FromResult(packet);
        }

        public async Task<List<Packet>> List(string username, List<PacketStatus> statuses, int pageSize = 10, int pageIndex = 1)
        {
            //DEVNOTE: Manually create packet to use with packets index
            List<Packet> packetDomains = new List<Packet>
            {
                new Packet(1, 1, 1, "4", PacketKind.I, DateTime.Now, "TT", PacketStatus.Submitted, DateTime.Now, "test@test.com", null, null, false, new List<Form>(), new List<PacketSubmission>())
            };

            return packetDomains;
        }

        public Task<IEnumerable<Packet>> List(string username, int pageSize = 10, int pageIndex = 1)
        {
            throw new NotImplementedException();
        }

        public Task<Packet> Patch(string username, Packet entity)
        {
            throw new NotImplementedException();
        }

        public Task Remove(string username, Packet entity)
        {
            throw new NotImplementedException();
        }

        public Task<Packet> Update(string username, Packet entity)
        {
            throw new NotImplementedException();
        }

        public Task<Packet> UpdatePacketSubmissionErrors(string username, Packet packetToEdit, int packetSubmissionId, List<PacketSubmissionError> errors)
        {
            throw new NotImplementedException();
        }
    }
}