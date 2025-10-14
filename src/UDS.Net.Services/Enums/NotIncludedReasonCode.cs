using System.ComponentModel;
namespace UDS.Net.Services.Enums
{
    // A2: 94, No co-participant|95, Physical problem|96, Cognitive/behavioral problem|97, Other|98, Verbal refusal
    // B1, B3: 94, Remote visit|95, Physical problem|96, Cognitive/behavioral problem|97, Other|98, Verbal refusal
    public enum NotIncludedReasonCode
    {
        [Description("Remote visit")]
        RemoteVisit = 94, // B1, B3
        [Description("No co-participant")]
        NoCoParticipant = 92, // only allowed for A2
        [Description("Physical problem")]
        PhysicalProblem = 95,
        [Description("Cognitive/behavioral problem")]
        CognitiveBehavioralProblem = 96,
        [Description("Other")]
        Other = 97,
        [Description("Verbal refusal")]
        VerbalRefusal = 98,
        [Description("Concerns about reliability")]
        ConcernsAboutReliability = 93
    }
}

