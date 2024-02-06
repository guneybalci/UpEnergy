using Business.Abstract;
using Business.Contants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete;

public class BalanceManager : IBalanceService
{
    IBalanceDal _balanceDal;
    public BalanceManager(IBalanceDal balanceDal)
    {
            _balanceDal = balanceDal;
    }

    public IDataResult<Balance> GetById(int balanceId)
    {
        try
        {
            return new SuccessDataResult<Balance>(_balanceDal.Get(b => b.Id == balanceId));
        }
        catch (Exception)
        {

            return new ErrorDataResult<Balance>(_balanceDal.Get(b => b.Id != balanceId));
        }
    }

    public IDataResult<List<Balance>> GetAll()
    {
        return new SuccessDataResult<List<Balance>>(_balanceDal.GetAll().ToList());
    }
    public IResult Add(Balance balance)
    {
        _balanceDal.Add(balance);
        return new SuccessResult(Messages.BalanceAdded);
    }

    public IResult Update(Balance balance)
    {
        _balanceDal.Update(balance);
        return new SuccessResult(Messages.BalanceUpdated);
    }

    public IResult Delete(Balance balance)
    {
        _balanceDal.Delete(balance);
        return new SuccessResult(Messages.BalanceDeleted);
    }



}
