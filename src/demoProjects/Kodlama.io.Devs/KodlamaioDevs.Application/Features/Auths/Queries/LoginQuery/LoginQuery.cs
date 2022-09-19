using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using KodlamaioDevs.Application.Features.Auths.Rules;
using KodlamaioDevs.Application.Services.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KodlamaioDevs.Application.Features.Auths.Queries.LoginQuery
{
    public class LoginQuery : IRequest<AccessToken>
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public class LoginQueryHandler : IRequestHandler<LoginQuery, AccessToken>
        {
            public readonly IUserRepository _userRepository;
            private readonly IUserOperationClaimRepository _userOperationClaimRepository;
            public readonly IMapper _mapper;
            private readonly AuthBusinessRules authBusinessRules;
            private readonly ITokenHelper _tokenHelper;

            public LoginQueryHandler(IUserRepository userRepository, IMapper mapper, AuthBusinessRules authBusinessRules, IUserOperationClaimRepository userOperationClaimRepository)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                this.authBusinessRules = authBusinessRules;
                _userOperationClaimRepository = userOperationClaimRepository;
            }

            public async Task<AccessToken> Handle(LoginQuery request, CancellationToken cancellationToken)
            {
                authBusinessRules.CheckIfUserExist(request.Email);
                User user = await _userRepository.GetAsync(u => u.Email == request.Email);

                if (!HashingHelper.VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
                    throw new BusinessException("The password you entered is incorrect.");

                IPaginate<UserOperationClaim> userGetClaims = await _userOperationClaimRepository.GetListAsync(u => u.UserId == user.Id,
                    include: i => i.Include(i => i.OperationClaim));

                AccessToken accessToken = _tokenHelper.CreateToken(user, userGetClaims.Items.Select(u => u.OperationClaim).ToList());
                return accessToken;
            }
        }
    }
}
