using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussines.Abstract
{
    public interface IGarbageService
    {
        IDataResult<List<Garbage>> GetAll();
        IResult Delete(Garbage garbage);
        IResult Add(Garbage garbage);
        IResult Update(Garbage garbage);
        IDataResult<Garbage> GetByName(string garbageName);

    }
}
