using Business.Abstract;
using Business.Contants;
using Business.Enums;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Extensions;
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
    ICustomerService _customerService;

    public CarManager(ICarDal carDal, ICustomerService customerService)
    {
        _carDal = carDal;
        _customerService = customerService;
    }

    [LogAspect(typeof(FileLogger))] // DatabaseLooger
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

    [LogAspect(typeof(FileLogger))] // DatabaseLooger
    public IDataResult<List<Car>> GetAll()
    {
        return new SuccessDataResult<List<Car>>(_carDal.GetAll().ToList());
    }

    [LogAspect(typeof(FileLogger))] // DatabaseLooger
    public IDataResult<List<Car>> GetListByCustomerId(int customerId)
    {
        return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.CustomerId == customerId).ToList());
    }

    [LogAspect(typeof(FileLogger))] // DatabaseLooger
    IDataResult<Car> ICarService.Add(Car car)
    {
        // Business Code - İş Kuralı Örn daha önce eklenen ürün eklenmesin ya da validasyon
        IResult result = CheckCustomerStatusExists(car);

        if (result.Success)
        {
            string carTypeEnumDescription = "";
            string fuelOilTypeEnumDescription = "";

            switch (car.CarCode)
            {
                case 0:
                    CarTypeEnum Binek = CarTypeEnum.Binek;
                    carTypeEnumDescription = Binek.GetEnumDescription();
                    break;
                case 1:
                    CarTypeEnum Ticari = CarTypeEnum.Ticari;
                    carTypeEnumDescription = Ticari.GetEnumDescription();
                    break;
                case 2:
                    CarTypeEnum Motorsiklet = CarTypeEnum.Motorsiklet;
                    carTypeEnumDescription = Motorsiklet.GetEnumDescription();
                    break;
                default:
                    break;
            }

            switch (car.FuelOilCode)
            {
                case 0:
                    FuelOilTypeEnum Benzin = FuelOilTypeEnum.Benzin;
                    fuelOilTypeEnumDescription = Benzin.GetEnumDescription();
                    break;
                case 1:
                    FuelOilTypeEnum Dizel = FuelOilTypeEnum.Dizel;
                    fuelOilTypeEnumDescription = Dizel.GetEnumDescription();
                    break;
                case 2:
                    FuelOilTypeEnum LPG = FuelOilTypeEnum.LPG;
                    fuelOilTypeEnumDescription = LPG.GetEnumDescription();
                    break;
                case 3:
                    FuelOilTypeEnum Elektrik = FuelOilTypeEnum.Elektrik;
                    fuelOilTypeEnumDescription = Elektrik.GetEnumDescription();
                    break;
                default:
                    break;
            }

            car.CarType = carTypeEnumDescription;
            car.FuelOilType = fuelOilTypeEnumDescription;
            _carDal.Add(car);
            return new SuccessDataResult<Car>(car, true, Messages.CarAdded);
        }
        else
        {
            return new ErrorDataResult<Car>(result.Message);
        }

      

    }

    [LogAspect(typeof(FileLogger))] // DatabaseLooger
    public IResult Update(Car car)
    {
        _carDal.Update(car);
        return new SuccessResult(Messages.CarUpdated);
    }

    [LogAspect(typeof(FileLogger))] // DatabaseLooger
    public IResult Delete(Car car)
    {
        _carDal.Delete(car);
        return new SuccessResult(Messages.CarDeleted);
    }


    private IResult CheckCustomerStatusExists(Car car)
    {

        //var result = _customerService.GetAll().Data.Where(x => x.Id == car.CustomerId).Any(x => x.Status == Messages.OnayBekliyor);

        if (_customerService.GetById(car.CustomerId).Data != null)
        {
            if (_customerService.GetById(car.CustomerId).Data.StatusCode == 0 || _customerService.GetById(car.CustomerId).Data.StatusCode == 1)
            {
                return new SuccessResult();
            }
            else
            {
                return new ErrorResult(Messages.CustomerStatusRejected);
            }
        }
        else
        {
            return new ErrorResult(Messages.CustomerNotRegistered);
        }
    }
}
