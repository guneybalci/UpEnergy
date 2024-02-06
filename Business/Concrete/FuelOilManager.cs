using Business.Abstract;
using Business.Contants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class FuelOilManager : IFuelOilService
    {
        IFuelOilDal _fuelOilDal;
        ICarService _carService;
        public FuelOilManager(IFuelOilDal fuelOilDal, ICarService carService)
        {
            _fuelOilDal = fuelOilDal;
            _carService = carService;

        }
        public IDataResult<FuelOil> GetById(int fuelOilId)
        {
            try
            {
                return new SuccessDataResult<FuelOil>(_fuelOilDal.Get(f => f.Id == fuelOilId));
            }
            catch (Exception)
            {
                return new SuccessDataResult<FuelOil>(_fuelOilDal.Get(f => f.Id != fuelOilId));
            }
        }

        public IDataResult<List<FuelOil>> GetAll()
        {
           return new SuccessDataResult<List<FuelOil>>(_fuelOilDal.GetAll().ToList());
        }

        IDataResult<FuelOil> IFuelOilService.Add(FuelOil fuelOil)
        {
            IResult result = CheckCarExists(fuelOil);

            if (result.Success == true)
            {
                _fuelOilDal.Add(fuelOil);
                return new SuccessDataResult<FuelOil>(fuelOil, true, Messages.FuelOilAdded);
            }
            else
            {
                return new ErrorDataResult<FuelOil>(result.Message);
            }


        }

        public IResult Update(FuelOil fuelOil)
        {
            _fuelOilDal.Update(fuelOil);
            return new SuccessResult(Messages.FuelOilUpdated);
        }

        public IResult Delete(FuelOil fuelOil)
        {
            _fuelOilDal.Delete(fuelOil);
            return new SuccessResult(Messages.FuelOilDeleted);
        }

        private IResult CheckCarExists(FuelOil fuelOil)
        {
            var result = _carService.GetAll().Data.Where(x=>x.Plaque == fuelOil.Plaque).ToList().FirstOrDefault();

            if (result.Id == fuelOil.CarId)
            {
                if (_carService.GetById(fuelOil.CarId).Data.Plaque == fuelOil.Plaque)
                {
                    return new SuccessResult();
                }
                else
                {
                    return new ErrorResult(Messages.PlaqueNotEquals);
                }
            }
            else
            {
                return new ErrorResult(Messages.CarNotRegistered);
            }
        }


    }
}
