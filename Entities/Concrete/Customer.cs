using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Entities.Concrete;

// Müşteri
public class Customer
{
    public int Id { get; set; }

    // Müşteri Adı
    public string FirstName { get; set; }

    // Müşteri Soyadı
    public string LastName { get; set; }

    // Müşteri TC Kimlik No
    public string TCKN { get; set; } 

    // Müşteri Adres
    public string Address { get; set; }





    // Bir müşterinin - birden'den çok Arac'ı olabilir. (One-To-Many)
    public ICollection<Car> Cars { get; set; }




    //// Bir Müşteri - Bir Bakiye Tanımlanması Yapabilir. (One-To-One)
    //public Balance Balance { get; set; }
}
