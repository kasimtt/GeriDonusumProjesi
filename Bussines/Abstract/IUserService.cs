using Core.Entities.Concretes;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussines.Abstract
{
    public interface IUserService
    {
        IDataResult<List<OperationClaim>> GetClaim(User user);
        IResult Add(User user);
        IDataResult<User> GetByEmail(string email);

    }
}
