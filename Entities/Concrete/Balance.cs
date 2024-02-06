using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete;

// Bakiye
public class Balance
{
    public int Id { get; set; }

    // Hediye
    public string Gift { get; set; }

    // Kredi
    public string Credit { get; set; }

    // Ön Ödeme
    public string DownPayment { get; set; }


    //// Bir Müşteri İçin - Bir Bakiye Tanımlanması (One-To-One)
    //public int CustomerId { get; set; }
    //public Customer Customer { get; set; }
}
