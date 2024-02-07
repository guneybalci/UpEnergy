using Business.Abstract;
using Business.Contants;
using Business.Enums;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Extensions;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete;

public class CustomerManager : ICustomerService
{
    ICustomerDal _customerDal;
    private ITransactionService _transactionService;
    private ITransactionDal _transactionDal;
    public CustomerManager(ICustomerDal customerDal, ITransactionService transactionService, ITransactionDal transactionDal)
    {
        _customerDal = customerDal;
        _transactionService = transactionService;
        _transactionDal = transactionDal;

    }

    [LogAspect(typeof(FileLogger))] // DatabaseLooger
    public IDataResult<Customer> GetById(int customerId)
    {
        try
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(c => c.Id == customerId));
        }
        catch (Exception)
        {

            return new ErrorDataResult<Customer>(_customerDal.Get(c => c.Id != customerId));
        }

    }

    [LogAspect(typeof(FileLogger))] // DatabaseLooger
    public IDataResult<List<Customer>> GetAll()
    {
        return new SuccessDataResult<List<Customer>>(_customerDal.GetAll().ToList());
    }

    [LogAspect(typeof(FileLogger))] // DatabaseLooger
    public IDataResult<List<Customer>> GetDetailCustomers()
    {
        return new SuccessDataResult<List<Customer>>(_customerDal.GetDetailCustomers());
    }

    [LogAspect(typeof(FileLogger))] // DatabaseLooger
    IDataResult<Customer> ICustomerService.Add(Customer customer)
    {
        // Business Code - İş Kuralı Örn daha önce eklenen ürün eklenmesin ya da validasyon

        string enumDescription = "";

        switch (customer.StatusCode)
        {
            case 0:
                CustomerStatus OnayBekliyor = CustomerStatus.OnayBekliyor;
                enumDescription = OnayBekliyor.GetEnumDescription();
                break;
            case 1:
                CustomerStatus Onaylandi = CustomerStatus.Onaylandi;
                enumDescription = Onaylandi.GetEnumDescription();
                break;
            case 2:
                CustomerStatus Reddedildi = CustomerStatus.Reddedildi;
                enumDescription = Reddedildi.GetEnumDescription();
                break;
            default:
                enumDescription = Messages.OnayBekliyor;
                break;
        }

   
        customer.Status = enumDescription;
        _customerDal.Add(customer);
        AddTransaction(customer);
        return new SuccessDataResult<Customer>(customer, true, Messages.CustomerAdded);
    }

    [LogAspect(typeof(FileLogger))] // DatabaseLooger
    public IResult Update(Customer customer)
    {
  
        _customerDal.Update(customer);
        AddTransaction(customer);
        return new SuccessResult(Messages.CustomerUpdated);
    }

    [LogAspect(typeof(FileLogger))] // DatabaseLooger
    public IResult Delete(Customer customer)
    {
        _customerDal.Delete(customer);
        AddTransaction(customer);
        return new SuccessResult(Messages.CustomerDeleted);
    }

    [LogAspect(typeof(FileLogger))] // DatabaseLooger
    private void AddTransaction(Customer customer)
    {
        Transaction transaction = new Transaction()
        {
            Customer = customer,
            CustomerID = _customerDal.GetAll().Select(x=>x.Id).Last(),
        };

        _transactionService.Add(transaction);
    }
}
