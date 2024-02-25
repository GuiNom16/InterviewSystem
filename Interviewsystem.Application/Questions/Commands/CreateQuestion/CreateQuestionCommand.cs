using Interviewsystem.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interviewsystem.Application.Questions.Commands.CreateQuestion
{
    public class CreateQuestionCommand : IRequest<ObjetRetour>
    {
        public long QuestionId { get; set; }
        public string? QuestionContent { get; set; }
        public int? TechnoId { get; set; }
        public string? AnswerElement { get; set; }
        public byte? QuestionLevel { get; set; }
    }
}
