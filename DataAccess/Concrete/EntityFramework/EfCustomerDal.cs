using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework;

public class EfCustomerDal : EfEntityRepositoryBase<Customer, UpEnergyContext>, ICustomerDal
{
    public List<Customer> GetDetailCustomers()
    {
        using (var context = new UpEnergyContext()) {

            var result = from cstmr in context.Customers
                         join cr in context.Cars
                         on cstmr.Id equals cr.CustomerId
                         select new Customer
                         {
                             Id = cstmr.Id,
                             FirstName = cstmr.FirstName,
                             LastName = cstmr.LastName,
                             TCKN = cstmr.TCKN,
                             Address = cstmr.Address,
                             StatusCode = cstmr.StatusCode,
                             Status = cstmr.Status,
                             Cars = cstmr.Cars,
                             Balances = cstmr.Balances,
                             Transactions = cstmr.Transactions
                         };

            return result.ToList();
        }
    }
}
