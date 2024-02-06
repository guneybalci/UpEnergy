using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract;

public interface IBalanceService
{
    IDataResult<Balance> GetById(int balanceId);
    IDataResult<List<Balance>> GetAll();
    IDataResult<Balance> Add(Balance balance);
    IResult Delete(Balance balance);
    IResult Update(Balance balance);

    IDataResult<List<Balance>> GetListByCustomerId(int customerId);
}
