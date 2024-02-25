namespace Interviewsystem.Domain.Models;
public class CandidateResultModel
{
    public long CandidateResultId { get; set; }
    public string? CandidateFullname { get; set; }
    public byte? Role { get; set; }
    public byte? Status { get; set; }
    public string? Comment { get; set; }
    public string QuestionsAnswers { get; set; } = string.Empty;
    public byte? CandidateLevel { get; set; }
    public byte? UserId { get; set; }   
}