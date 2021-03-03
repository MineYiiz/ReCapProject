using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using System.Linq;


namespace Business.Concrete
{

    public class CarManager : ICarService
    {
        ICarDal _carDal;
        

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetByDailyPrice(decimal min)
        {
            return _carDal.GetAll(c => c.DailyPrice >0);
        }

        //public List<Car> GetCarsByCarName(Car cars,Brand brands)
        //{
        //    return _carDal.GetAll(from Car in cars
        //                          join Brand in brands
        //                          on Car.CarId equals Brand.BrandId
        //                          where len(BrandName) > 2
        //                          select new CarDto
        //                          {
        //                             CarId = Car.CarId,
        //                             BrandName = Brand.BrandName,
        //                             DailyPrice = Car.DailyPrice
        //                          });           
        //}
        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(c => c.BrandId == id);

        }
        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetAll(c => c.ColorId == id);
        }
    }
}
