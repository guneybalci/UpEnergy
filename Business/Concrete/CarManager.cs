using Business.Abstract;
using Business.Contants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete;

public class CarManager : ICarService
{
    ICarDal _carDal;

    public CarManager(ICarDal carDal)
    {
            _carDal= carDal;
    }

    public IDataResult<Car> GetById(int carId)
    {
        try
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == carId));
        }
        catch (Exception)
        {

            return new ErrorDataResult<Car>(_carDal.Get(c => c.Id != carId));
        }
    }

    public IDataResult<List<Car>> GetAll()
    {
        return new SuccessDataResult<List<Car>>(_carDal.GetAll().ToList());
    }

    public IDataResult<List<Car>> GetListByCustomerId(int customerId)
    {
        return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.Id == customerId).ToList());
    }

    public IResult Add(Car car)
    {
        _carDal.Add(car);
        return new SuccessResult(Messages.CarDeleted);
    }

    public IResult Update(Car car)
    {
        _carDal.Update(car);
        return new SuccessResult(Messages.CarUpdated);
    }

    public IResult Delete(Car car)
    {
        _carDal.Delete(car);
        return new SuccessResult(Messages.CarDeleted);
    }

  
}
