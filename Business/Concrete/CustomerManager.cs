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

    public IResult Add(Customer customer)
    {
        // Business Code - İş Kuralı Örn daha önce eklenen ürün eklenmesin ya da validasyon
        _customerDal.Add(customer);
        return new SuccessResult(Messages.CustomerAdded); 
          
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
