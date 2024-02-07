using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Entities.Concrete;

public class Customer
{
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string TCKN { get; set; } 

    public string Address { get; set; }

    public int? StatusCode { get; set; }
    public string Status { get; set; }



    // Bir müşterinin - birden'den çok Arac'ı olabilir. (One-To-Many)
    public ICollection<Car> Cars { get; set; }

    public ICollection<Balance> Balances { get; set; }

    public ICollection<Transaction> Transactions { get; set; }


    //// Bir Müşteri - Bir Bakiye Tanımlanması Yapabilir. (One-To-One)
    //public Balance Balance { get; set; }
}
