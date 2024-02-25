using Interviewsystem.Application.Responses;
using Interviewsystem.Persistence.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Interviewsystem.Application.User.Queries.GetUsersList
{
    public class GetUsersListQueryHandler : IRequestHandler<GetUsersListQuery, ObjetRetour>
    {
        private readonly IUserRepository _userRepository;

        public GetUsersListQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<ObjetRetour> Handle(GetUsersListQuery request, CancellationToken cancellationToken)
        {
            var retour = new ObjetRetour();

            try
            {
                retour.Contenu = await _userRepository.GetUsersList();
                retour.Message = "Success";
            }
            catch (Exception ex)
            {
                retour.Etat = false;
                retour.Message = ex.Message;
            }

            return retour;
        }
        
    }
}
