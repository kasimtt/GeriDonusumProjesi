using Bussines.Abstract;
using Bussines.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bussines.Concrete
{
    public class CarbonToKYCManager : ICarbonToKYCService
    {
        ICarbonToKYCDal _carbonToKYCDal;

        public CarbonToKYCManager(ICarbonToKYCDal carbonToKYCDal)
        {
            _carbonToKYCDal = carbonToKYCDal;
        }

        public IResult Add(CarbonToKYC carbonToKYC)
        {
            _carbonToKYCDal.Add(carbonToKYC);
            return new SuccessResult(Messages.AddedMessages);
        }

        public IResult Delete(CarbonToKYC carbonToKYC)
        {
            _carbonToKYCDal.Delete(carbonToKYC);
            return new SuccessResult(Messages.DeletedMessages);
        }

        public IDataResult<List<CarbonToKYC>>GetAll()
        {
            var result = _carbonToKYCDal.GetAll();
            return new SuccessDataResult<List<CarbonToKYC>>(result.ToList(), Messages.GetAllMessages);
        }

        public IResult Update(CarbonToKYC carbonToKYC)
        {
            _carbonToKYCDal.Update(carbonToKYC);
            return new SuccessResult(Messages.UpdatedMessages);
        }
    }
}
