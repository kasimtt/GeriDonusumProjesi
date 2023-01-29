using Core.Entities.Concretes;
using Core.Utilities.Results;
using Core.Utilities.Security.Jwt;
using Entity.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussines.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegister userForRegister,string password);
        IDataResult<User> Login(UserForLogin userForLogin);
        IResult UserExist(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);

    }
}
