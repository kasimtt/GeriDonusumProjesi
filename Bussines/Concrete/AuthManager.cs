using Bussines.Abstract;
using Bussines.Constants;
using Core.Entities.Concretes;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Jwt;
using Entity.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussines.Concrete
{
    public class AuthManager : IAuthService
    {
        IUserService _userService;
        ITokenHelper _tokenHelper;
        public AuthManager(IUserService userService,ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }
        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaim(user);
            var accessToken = _tokenHelper.CreateAccessToken(user, claims.Data);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);

        }

        public IDataResult<User> Login(UserForLogin userForLogin)
        {
            var UserToCheck = _userService.GetByEmail(userForLogin.Email);  
            if(UserToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }
            if(!HashingHelper.VerifyPasswordHash(userForLogin.Password,UserToCheck.Data.PasswordHash,UserToCheck.Data.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }
            return new SuccessDataResult<User>(UserToCheck.Data, Messages.SuccessfulLogin);
        }

        public IDataResult<User> Register(UserForRegister userForRegister, string password)
        {
            byte[] passwordHash, passwordSalt;

            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);

            User user = new User
            {
                Email = userForRegister.Email,
                FirstName = userForRegister.FirstName,
                LastName = userForRegister.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true  // status şimdilik true ama isterler göz önünde bulundurularak değişebilir.
            };
            _userService.Add(user);
            return new ErrorDataResult<User>(user, Messages.UserRegistered);
        }

        public IResult UserExist(string email)
        {
           if(_userService.GetByEmail(email).Data!=null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }
    }
}
