using AutoMapper;
using Core.Security.JWT;
using KodlamaioDevs.Application.Features.Auths.Rules;
using KodlamaioDevs.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaioDevs.Application.Features.Auths.Queries.LoginQuery
{
    public class LoginQuery : IRequest<AccessToken>
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public class LoginQueryHandler : IRequestHandler<LoginQuery, AccessToken>
        {
            public readonly IUserRepository _userRepository;
            public readonly IMapper _mapper;
            private readonly AuthBusinessRules authBusinessRules;

            public LoginQueryHandler(IUserRepository userRepository, IMapper mapper, AuthBusinessRules authBusinessRules)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                this.authBusinessRules = authBusinessRules;
            }

            public Task<AccessToken> Handle(LoginQuery request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
