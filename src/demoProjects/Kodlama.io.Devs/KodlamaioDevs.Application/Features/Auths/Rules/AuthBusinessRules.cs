using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Core.Security.Hashing;
using KodlamaioDevs.Application.Services.Repositories;

namespace KodlamaioDevs.Application.Features.Auths.Rules
{
    public class AuthBusinessRules
    {
        private readonly IUserRepository _userRepository;
        public AuthBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task EmailCanNotBeDuplicatedWhenRegistered(string email)
        {
            User? user = await _userRepository.GetAsync(x => x.Email == email);
            if (user != null) throw new BusinessException("Email already in use");
        }

        public void VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            if (HashingHelper.VerifyPasswordHash(password, passwordHash, passwordSalt) != true)
            {
                throw new BusinessException("invalid password");
            }
        }

        public void CheckIfUserExist(string email)
        {
            if (_userRepository.GetList(x=>x.Email == email).Items.Count == 0)
            {
                throw new BusinessException("User not exist !");
            }
        }
    }
}
