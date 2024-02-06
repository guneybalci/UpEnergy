using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract;

public interface ICustomerService
{
    //Customer Get(Customer customer);
    IDataResult<Customer> GetById(int customerId);
    IDataResult<List<Customer>> GetAll();
    IDataResult<Customer> Add(Customer customer);
    IResult Delete(Customer customer);
    IResult Update(Customer customer);

}
