using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete;

public class TransactionManager : ITransactionService
{
    private ITransactionDal _transactionDal;
    private ICustomerDal _customerDal;
    public TransactionManager(ITransactionDal transactionDal, ICustomerDal customerDal)
    {
        _transactionDal = transactionDal;
        _customerDal = customerDal;
    }


    public IDataResult<Transaction> GetById(int transactionId)
    {
        return new SuccessDataResult<Transaction>(_transactionDal.Get(t => t.Id == transactionId));
    }

    public IDataResult<List<Transaction>> GetAll()
    {
        return new SuccessDataResult<List<Transaction>>(_transactionDal.GetAll().ToList());
    }

    public IResult Add(Transaction transaction)
    {
        try
        {
            //Customer c = _customerDal.Get(x => x.Id == transaction.CustomerID);
            //c.Transactions.Add(transaction);
            //_customerDal.Update(c);

            transaction.IsSuccess = true;
            var transactionGetAll = _transactionDal.GetAll();
            transaction.TransactionNo = 10000 + transactionGetAll.Count + 1;

            _transactionDal.Add(transaction);
            return new SuccessResult($"İşleminiz {transaction.TransactionNo} numarasıyla başarılı bir şekilde tamamlanmıştır.");
        }
        catch
        {
            transaction.IsSuccess = false;
            _transactionDal.Add(transaction);
            return new ErrorResult("İşlem yapılamadı. Daha sonra tekrar deneyiniz.");
        }
    }
}
