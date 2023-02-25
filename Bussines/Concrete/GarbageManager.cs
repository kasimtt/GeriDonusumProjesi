using Bussines.Abstract;
using Bussines.BusinessAspect.Autofact;
using Bussines.Constants;
using Bussines.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading;
using System.Transactions;

namespace Bussines.Concrete
{ 
    // gerekli iş kodları eklenecek
    public class GarbageManager : IGarbageService
    {
        private IGarbageDal _garbageDal;

        public GarbageManager(IGarbageDal garbageDal)
        {
            _garbageDal = garbageDal;
        }


        [SecuredOperation("admin,garbage.add")]
        [ValidationAspect(typeof(GarbageValidator))]
        [CacheRemoveAspect("IGarbageService.Get")]
        public IResult Add(Garbage garbage)
        {
            _garbageDal.Add(garbage);
            return new SuccessResult(Messages.AddedMessages);
        }

        [TransactionScopeAspect]  // test amacıyla yazılmıştır
        public IResult AddTransactionalTest(Garbage garbage)
        {

            Add(garbage);
            if(garbage.Carbon<10)
            {
                throw new Exception("bir tane hata");
            }
           
            Add(garbage);
            return new SuccessResult(Messages.AddedMessages);
        }

        public IResult Delete(Garbage garbage)
        {
            _garbageDal.Delete(garbage);
            return new SuccessResult(Messages.DeletedMessages);
        }


        [CacheAspect]
        
        public IDataResult<List<Garbage>> GetAll()
        {
            Thread.Sleep(6000);
            var result = _garbageDal.GetAll();
            return new SuccessDataResult<List<Garbage>>(result.ToList(), Messages.GetAllMessages);
        }
        [CacheAspect]
        public IDataResult<Garbage> GetByName(string garbageName)
        {
            var result = _garbageDal.Get(G => G.Type == garbageName);
            return new SuccessDataResult<Garbage>(result, Messages.GetMessages);
        }

   
        public IResult Update(Garbage garbage)
        {
            _garbageDal.Update(garbage);
            return new SuccessResult(Messages.UpdatedMessages);

        }
    }
}
