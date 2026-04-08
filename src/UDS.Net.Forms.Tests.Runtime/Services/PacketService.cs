using UDS.Net.Forms.Tests.Runtime.Data;
using UDS.Net.Services;
using UDS.Net.Services.DomainModels;
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
            var packet = new Packet(1, 1, 1, "4", PacketKind.I, DateTime.Now, "TT", PacketStatus.Submitted, DateTime.Now, "test@test.com", null, null, false, new List<Form>(), new List<PacketSubmission>
            {
                new PacketSubmission(1, "17", DateTime.Now, 1, DateTime.Now, "test@test.com", null, null, false, null)
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
                    new PacketSubmission(1, "17", DateTime.Now, 1, DateTime.Now, "test@test.com", null, null, false, null, new List<Form>
                    {
                        //DEVNOTE: Will need to include all forms for the export to write data
                        new Form(1, "A3", true, DateTime.Now, "test@test.com", PacketKind.I)
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