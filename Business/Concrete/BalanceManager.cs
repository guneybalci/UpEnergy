using Business.Abstract;
using Business.Contants;
using Business.Enums;
using Core.Extensions;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete;

public class BalanceManager : IBalanceService
{
    IBalanceDal _balanceDal;
    ICustomerService _customerService;
    public BalanceManager(IBalanceDal balanceDal, ICustomerService customerService)
    {
        _balanceDal = balanceDal;
        _customerService = customerService;
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

    public IDataResult<List<Balance>> GetListByCustomerId(int customerId)
    {
        return new SuccessDataResult<List<Balance>>(_balanceDal.GetAll(c => c.CustomerId == customerId).ToList());
    }

    IDataResult<Balance> IBalanceService.Add(Balance balance)
    {
        IResult result = CheckCustomerStatusExists(balance);

        if (result.Success)
        {
            string balanceTypeDescription = "";

            switch (balance.BalanceCode)
            {
                case 0:
                    BalanceTypeEnum Gift = BalanceTypeEnum.Gift;
                    balanceTypeDescription = Gift.GetEnumDescription();
                    balance.Gift = balanceTypeDescription;
                    break;
                case 1:
                    BalanceTypeEnum Credit = BalanceTypeEnum.Credit;
                    balanceTypeDescription = Credit.GetEnumDescription();
                    balance.Credit = balanceTypeDescription;
                    break;
                case 2:
                    BalanceTypeEnum DownPayment = BalanceTypeEnum.DownPayment;
                    balanceTypeDescription = DownPayment.GetEnumDescription();
                    balance.DownPayment = balanceTypeDescription;
                    break;
                default:
                    break;
            }

            _balanceDal.Add(balance);
            return new SuccessDataResult<Balance>(balance, true, Messages.BalanceAdded);
        }
        else
        {
            return new ErrorDataResult<Balance>(result.Message);
        }


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

    private IResult CheckCustomerStatusExists(Balance balance)
    {

        if (_customerService.GetById(balance.CustomerId).Data != null)
        {
            if (_customerService.GetById(balance.CustomerId).Data.StatusCode == 1)
            {
                return new SuccessResult();
            }
            else
            {
                return new ErrorResult(Messages.CustomerApprovedForBalance);
            }
        }
        else
        {
            return new ErrorResult(Messages.CustomerNotRegistered);
        }
    }

 
}
