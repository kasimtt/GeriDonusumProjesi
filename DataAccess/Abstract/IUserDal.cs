using Core.DataAccess;
using Core.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IUserDal:IEntityRepository<User>
    {
        List<OperationClaim> GetClaim(User user);
    }
}
