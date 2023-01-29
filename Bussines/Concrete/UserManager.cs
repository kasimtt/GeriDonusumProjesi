using Bussines.Abstract;
using Core.Entities.Concretes;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussines.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult();
        }

        public IDataResult<User> GetByEmail(string email)
        {
            var result = _userDal.Get(u => u.Email == email);
            return new SuccessDataResult<User>(result);
        }

        public IDataResult<List<OperationClaim>> GetClaim(User user)
        {
            var result = _userDal.GetClaim(user);
            return new SuccessDataResult<List<OperationClaim>>(result);
        }
    }
}
