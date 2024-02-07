using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete;

public class Transaction
{
    public int Id { get; set; }
    public int TransactionNo { get; set; }
    public DateTime? TransactionDate { get; set; }
    public bool IsSuccess { get; set; }


    // Her işlemin bir müşteri
    public int CustomerID { get; set; }
    public virtual Customer Customer { get; set; }
}
