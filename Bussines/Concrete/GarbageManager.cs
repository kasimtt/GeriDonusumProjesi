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
    // gerekli iş kodları eklenecek
    public class GarbageManager : IGarbageService
    {
        private IGarbageDal _garbageDal;

        public GarbageManager(IGarbageDal garbageDal)
        {
            _garbageDal = garbageDal;
        }

     
        public IResult Add(Garbage garbage)
        {
            _garbageDal.Add(garbage);
            return new SuccessResult(Messages.AddedMessages);
        }

   
        public IResult Delete(Garbage garbage)
        {
            _garbageDal.Delete(garbage);
            return new SuccessResult(Messages.DeletedMessages);
        }

       
        public IDataResult<List<Garbage>> GetAll()
        {
            var result = _garbageDal.GetAll();
            return new SuccessDataResult<List<Garbage>>(result.ToList(), Messages.GetAllMessages);
        }

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
