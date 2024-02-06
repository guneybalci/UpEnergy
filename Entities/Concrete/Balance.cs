using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete;

public class Balance
{
    public int Id { get; set; }

    public int? BalanceCode { get; set; }

    public string Gift { get; set; }

    public string Credit { get; set; }

    public string DownPayment { get; set; }

    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
    //// Bir Müşteri İçin - Bir Bakiye Tanımlanması (One-To-One)
    //public int CustomerId { get; set; }
    //public Customer Customer { get; set; }
}
