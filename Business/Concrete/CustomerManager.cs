using Business.Abstract;
using Business.Contants;
using Business.Enums;
using Core.Extensions;
using Core.Utilities.Results;
using DataAccess.Abstract;
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
    public CustomerManager(ICustomerDal customerDal)
    {
        _customerDal = customerDal;
    }


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

    public IDataResult<List<Customer>> GetAll()
    {
        return new SuccessDataResult<List<Customer>>(_customerDal.GetAll().ToList());
    }

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
        return new SuccessDataResult<Customer>(customer, true, Messages.CustomerAdded);
    }

    public IResult Update(Customer customer)
    {
        _customerDal.Update(customer);
        return new SuccessResult(Messages.CustomerUpdated);
    }

    public IResult Delete(Customer customer)
    {
        _customerDal.Delete(customer);
        return new SuccessResult(Messages.CustomerDeleted);
    }


}
