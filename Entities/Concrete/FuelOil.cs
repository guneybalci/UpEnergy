using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete;

// Akaryakıt
public class FuelOil
{
    public int Id { get; set; }

    // Plaka
    public string Plaque { get; set; }

    // İşlem Tutarı
    public decimal TransactionAmount { get; set; }

    // İşlem Tarihi
    public DateTime? TransactionDate { get; set; }








    //// Her Akaryakıt İçin Bir Araç (One-To-Many)
    //public int CarId { get; set; }

    //public virtual Car Car { get; set; }
}
