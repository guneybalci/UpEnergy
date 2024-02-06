using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract;

public interface ICarService
{
    IDataResult<Car> GetById(int carId);
    IDataResult<List<Car>> GetAll();
    IDataResult<List<Car>> GetListByCustomerId(int customerId);
    IDataResult<Car> Add(Car car);
    IResult Delete(Car car);
    IResult Update(Car car);
}
