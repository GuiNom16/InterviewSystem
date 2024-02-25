using Interviewsystem.Persistence.Entities.Common;

namespace Interviewsystem.Persistence.Entities;
public partial class CandidateResultEntity:BaseEntity  
{
    public long CandidateResultId { get; set; }
    public string? CandidateFullname { get; set; }
    public byte? Role { get; set; }
    public byte? Status { get; set; }
    public string? Comment { get; set; }
    public string? QuestionsAnswers { get; set; }
    public byte? CandidateLevel { get; set; }
}
