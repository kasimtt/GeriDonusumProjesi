using Core.DataAccess.EntityFramework;
using Core.Entities.Concretes;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, KoyunCoinDB>, IUserDal
    {
        public List<OperationClaim> GetClaim(User user)
        {
            using (var context = new KoyunCoinDB())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.userOperationClaims
                             on operationClaim.OperationClaimId equals userOperationClaim.OperationClaimId
                             where user.UserId == userOperationClaim.UserId
                             select new OperationClaim
                             {
                                 OperationClaimId = operationClaim.OperationClaimId,
                                 Name = operationClaim.Name
                             };
                return result.ToList();
            }
            
        }
    }
}
