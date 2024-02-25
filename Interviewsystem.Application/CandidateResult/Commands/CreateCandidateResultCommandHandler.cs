using Interviewsystem.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interviewsystem.Application.CandidateResult.Commands
{
    public class CreateCandidateResultCommandHandler : IRequestHandler<CreateCandidateResultCommand, ObjetRetour>
    {
        public Task<ObjetRetour> Handle(CreateCandidateResultCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
