using Interviewsystem.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interviewsystem.Application.User.Queries.GetUsersList
{
    public class GetUsersListQuery : IRequest<ObjetRetour>
    {
        public string FullName { get; set; } = string.Empty;
        public string Login { get; set; } = string.Empty;
        public byte Profile { get; set; }
    }
}
