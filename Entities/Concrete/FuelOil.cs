using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete;

public class FuelOil
{
    public int Id { get; set; }

    public string Plaque { get; set; }

    public decimal? TransactionAmount { get; set; }

    public DateTime? TransactionDate { get; set; }



    public int CarId { get; set; }

    public Car Car { get; set; }



}
