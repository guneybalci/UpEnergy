using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EfCustomerDal>().As<ICustomerDal>().SingleInstance();
            builder.RegisterType<CustomerManager>().As<ICustomerService>().SingleInstance();

            builder.RegisterType<EfCarDal>().As<ICarDal>().SingleInstance();
            builder.RegisterType<CarManager>().As<ICarService>().SingleInstance();

            builder.RegisterType<EfFuelOilDal>().As<IFuelOilDal>().SingleInstance();
            builder.RegisterType<FuelOilManager>().As<IFuelOilService>().SingleInstance();

            builder.RegisterType<EfBalanceDal>().As<IBalanceDal>().SingleInstance();
            builder.RegisterType<BalanceManager>().As<IBalanceService>().SingleInstance();

        }
    }
}
