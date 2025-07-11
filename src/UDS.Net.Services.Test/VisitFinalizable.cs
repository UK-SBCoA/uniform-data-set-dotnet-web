using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using UDS.Net.Services.DomainModels;
using UDS.Net.Services.DomainModels.Forms;
using UDS.Net.Services.Enums;
using Xunit;

namespace UDS.Net.Services.Test
{
    public class VisitFinalizable
    {
        private Visit CreateVisitWithForms(PacketKind packetKind, PacketStatus status, IList<Form> forms, int? unresolvedErrorCount = null)
        {
            return new Visit(
                id: 1,
                number: 1,
                participationId: 1,
                version: "4",
                packet: packetKind,
                visitDate: DateTime.Now,
                initials: "XX",
                status: status,
                createdAt: DateTime.Now,
                createdBy: "tester",
                modifiedBy: null,
                deletedBy: null,
                isDeleted: false,
                existingForms: forms,
                unresolvedErrorCount: unresolvedErrorCount,
                unresolvedErrors: null
            );
        }

        [Fact]
        public void IsFinalizable_ReturnsFalse_WhenUnresolvedErrorsExist()
        {
            // Arrange
            var visit = CreateVisitWithForms(
                PacketKind.I,
                PacketStatus.Pending,
                new List<Form>
                {
                    new Form(1, 1, "A1", "A1", true, FormStatus.Finalized, DateTime.Now, "XX", FormLanguage.English, FormMode.InPerson, null, null, null, DateTime.Now, "tester", "", "", false, new A1FormFields())
                },
                unresolvedErrorCount: 2
            );

            // Act
            var result = visit.IsFinalizable;

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void IsFinalizable_ReturnsFalse_WhenAllFormsAreNotFinalized()
        {
            // Arrange: A required form ("A1") is not finalized
            var visit = CreateVisitWithForms(
                PacketKind.I,
                PacketStatus.Pending,
                new List<Form>
                {
                    new Form(1, 1, "A1", "A1", true, FormStatus.Finalized, DateTime.Now, "XX", FormLanguage.English, FormMode.InPerson, null, null, null, DateTime.Now, "tester", "", "", false, new A1FormFields()),
                    new Form(1, 1, "A1a", "A1a", false, FormStatus.InProgress, DateTime.Now, "XX", FormLanguage.English, FormMode.InPerson, null, null, null, DateTime.Now, "tester", "", "", false, new A1FormFields())
                }
            );

            // Act
            var result = visit.IsFinalizable;

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void IsFinalizable_ReturnsTrue_WhenAllFormsAreFinalized_NoErrors()
        {
            // Arrange: A required form ("A1") is not finalized
            var visit = CreateVisitWithForms(
                PacketKind.I,
                PacketStatus.Pending,
                new List<Form>
                {
                    new Form(1, 1, "A1", "A1", true, FormStatus.Finalized, DateTime.Now, "XX", FormLanguage.English, FormMode.InPerson, null, null, null, DateTime.Now, "tester", "", "", false, new A1FormFields()),
                    new Form(1, 1, "A1a", "A1a", false, FormStatus.Finalized, DateTime.Now, "XX", FormLanguage.English, FormMode.InPerson, null, null, null, DateTime.Now, "tester", "", "", false, new A1aFormFields()),
                    new Form(1, 1, "A2", "A2", false, FormStatus.Finalized, DateTime.Now, "XX", FormLanguage.English, FormMode.InPerson, null, null, null, DateTime.Now, "tester", "", "", false, new A2FormFields()),
                    new Form(1, 1, "A3", "A3", false, FormStatus.Finalized, DateTime.Now, "XX", FormLanguage.English, FormMode.InPerson, null, null, null, DateTime.Now, "tester", "", "", false, new A3FormFields()),
                    new Form(1, 1, "A4", "A4", false, FormStatus.Finalized, DateTime.Now, "XX", FormLanguage.English, FormMode.InPerson, null, null, null, DateTime.Now, "tester", "", "", false, new A4GFormFields()),
                    new Form(1, 1, "A4a", "A4a", false, FormStatus.Finalized, DateTime.Now, "XX", FormLanguage.English, FormMode.InPerson, null, null, null, DateTime.Now, "tester", "", "", false, new A4aFormFields()),
                    new Form(1, 1, "A5D2", "A5D2", false, FormStatus.Finalized, DateTime.Now, "XX", FormLanguage.English, FormMode.InPerson, null, null, null, DateTime.Now, "tester", "", "", false, new A5D2FormFields()),
                    new Form(1, 1, "B1", "B1", false, FormStatus.Finalized, DateTime.Now, "XX", FormLanguage.English, FormMode.InPerson, null, null, null, DateTime.Now, "tester", "", "", false, new B1FormFields()),
                    new Form(1, 1, "B3", "B3", false, FormStatus.Finalized, DateTime.Now, "XX", FormLanguage.English, FormMode.InPerson, null, null, null, DateTime.Now, "tester", "", "", false, new B3FormFields()),
                    new Form(1, 1, "B4", "B4", false, FormStatus.Finalized, DateTime.Now, "XX", FormLanguage.English, FormMode.InPerson, null, null, null, DateTime.Now, "tester", "", "", false, new B4FormFields()),
                    new Form(1, 1, "B5", "B5", false, FormStatus.Finalized, DateTime.Now, "XX", FormLanguage.English, FormMode.InPerson, null, null, null, DateTime.Now, "tester", "", "", false, new B5FormFields()),
                    new Form(1, 1, "B6", "B6", false, FormStatus.Finalized, DateTime.Now, "XX", FormLanguage.English, FormMode.InPerson, null, null, null, DateTime.Now, "tester", "", "", false, new B6FormFields()),
                    new Form(1, 1, "B7", "B7", false, FormStatus.Finalized, DateTime.Now, "XX", FormLanguage.English, FormMode.InPerson, null, null, null, DateTime.Now, "tester", "", "", false, new B7FormFields()),
                    new Form(1, 1, "B8", "B8", false, FormStatus.Finalized, DateTime.Now, "XX", FormLanguage.English, FormMode.InPerson, null, null, null, DateTime.Now, "tester", "", "", false, new B8FormFields()),
                    new Form(1, 1, "B9", "B9", false, FormStatus.Finalized, DateTime.Now, "XX", FormLanguage.English, FormMode.InPerson, null, null, null, DateTime.Now, "tester", "", "", false, new B9FormFields()),
                    new Form(1, 1, "C2", "C2", false, FormStatus.Finalized, DateTime.Now, "XX", FormLanguage.English, FormMode.InPerson, null, null, null, DateTime.Now, "tester", "", "", false, new C2FormFields()),
                    new Form(1, 1, "D1a", "D1a", false, FormStatus.Finalized, DateTime.Now, "XX", FormLanguage.English, FormMode.InPerson, null, null, null, DateTime.Now, "tester", "", "", false, new D1aFormFields()),
                    new Form(1, 1, "D1b", "D1b", false, FormStatus.Finalized, DateTime.Now, "XX", FormLanguage.English, FormMode.InPerson, null, null, null, DateTime.Now, "tester", "", "", false, new D1bFormFields())
                }
            );

            // Act
            var result = visit.IsFinalizable;

            // Assert
            Assert.True(result);
        }
    }
}