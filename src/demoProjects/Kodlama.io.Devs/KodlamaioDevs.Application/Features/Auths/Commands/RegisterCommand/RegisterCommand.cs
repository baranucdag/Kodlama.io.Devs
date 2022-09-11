using AutoMapper;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using KodlamaioDevs.Application.Features.Auths.Rules;
using KodlamaioDevs.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaioDevs.Application.Features.Auths.Commands.RegisterCommand
{
    public class RegisterCommand : IRequest<AccessToken>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public class RegisterCommandHandler : IRequestHandler<RegisterCommand, AccessToken>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;
            private readonly ITokenHelper _tokenHelper;
            private readonly IUserOperationClaimRepository _useOperationClaimRepository;
            private readonly AuthBusinessRules authBusinessRules;

            public RegisterCommandHandler(
                IUserRepository userRepository,
                IMapper mapper, ITokenHelper tokenHelper,
                IUserOperationClaimRepository useOperationClaimRepository,
                AuthBusinessRules authBusinessRules
                )
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _tokenHelper = tokenHelper;
                _useOperationClaimRepository = useOperationClaimRepository;
                this.authBusinessRules = authBusinessRules;
            }

            public async Task<AccessToken> Handle(RegisterCommand request, CancellationToken cancellationToken)
            {
                await authBusinessRules.EmailCanNotBeDuplicatedWhenRegistered(request.Email);

                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);

                User user = _mapper.Map<User>(request);
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                user.Status = true;

                User registeredUser = await _userRepository.AddAsync(user);
                var token = _tokenHelper.CreateToken(registeredUser, new List<OperationClaim>());

                return token;
            }
        }
    }
}
