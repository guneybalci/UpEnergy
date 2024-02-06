using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete;

// Araç
public class Car
{
    public int Id { get; set; }

    // Araç Tipi (Binek, Ticari, Motorsiklet)
    public string CarType { get; set; }

    // Yakıt Tipi (Benzin, Dizel, LPG, Elektrik)
    public string FuelOilType { get; set; }





    // Her Araç İçin Bir Müşteri (One-To-Many)
    public int CustomerId { get; set; }

    public Customer Customer { get; set; }





    //// Bir araç birden'den çok Akaryakıt'ı olabilir. (One-To-Many)
    //public virtual ICollection<FuelOil> FuelOils { get; set; }
}
