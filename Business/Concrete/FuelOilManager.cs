using Business.Abstract;
using Business.Contants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class FuelOilManager : IFuelOilService
    {
        IFuelOilDal _fuelOilDal;
        public FuelOilManager(IFuelOilDal fuelOilDal)
        {
            _fuelOilDal = fuelOilDal;
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

        public IResult Add(FuelOil fuelOil)
        {
            _fuelOilDal.Add(fuelOil);
            return new SuccessResult(Messages.FuelOilAdded);
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



     

  
    }
}
