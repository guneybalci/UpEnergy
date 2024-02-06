using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete;

public class Car
{
    public int Id { get; set; }

    public string Plaque { get; set; }

    public int? CarCode { get; set; }
    public string CarType { get; set; }

    public int? FuelOilCode { get; set; }
    public string FuelOilType { get; set; }


    // Her Araç İçin Bir Müşteri (One-To-Many)
    public int CustomerId { get; set; }

    public Customer Customer { get; set; }


    public ICollection<FuelOil> FuelOils { get; set; }


    //// Bir araç birden'den çok Akaryakıt'ı olabilir. (One-To-Many)
    //public virtual ICollection<FuelOil> FuelOils { get; set; }
}
