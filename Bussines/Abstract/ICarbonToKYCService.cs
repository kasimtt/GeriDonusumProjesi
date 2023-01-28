using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussines.Abstract
{
    public interface ICarbonToKYCService
    {
        IDataResult<List<CarbonToKYC>> GetAll();
        IResult Delete(CarbonToKYC carbonToKYC);
        IResult Add(CarbonToKYC carbonToKYC);
        IResult Update(CarbonToKYC carbonToKYC);
    }
}
