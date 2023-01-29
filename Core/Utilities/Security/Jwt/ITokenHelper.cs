using Core.Entities.Concretes;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Jwt
{
    public interface ITokenHelper
    {
        AccessToken CreateAccessToken(User user, List<OperationClaim> operationClaims);
        void CreateAccessToken(User user, IDataResult<List<OperationClaim>> claims);
    }
}
