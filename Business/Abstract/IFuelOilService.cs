using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract;

public interface IFuelOilService
{
    IDataResult<FuelOil> GetById(int fuelOilId);
    IDataResult<List<FuelOil>> GetAll();
    IDataResult<FuelOil> Add(FuelOil fuelOil);
    IResult Delete(FuelOil fuelOil);
    IResult Update(FuelOil fuelOil);
}
