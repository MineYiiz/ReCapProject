using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal,IBrandDal,IColorDal
    {
        List<Car> _cars;
        List<Brand> _brands;
        List<Color> _colors;

        public InMemoryCarDal()
        {
            _cars = new List<Car> { 
                new Car{CarId=1,BrandId =1,ColorId=1,ModelYear=2021,DailyPrice=200,Description="Vites;Otomatik,Dizel,Kompakt"},
                new Car{CarId=2,BrandId =1,ColorId=2,ModelYear=2020,DailyPrice=100,Description="Vites;Otomatik,Benzin,Kompakt"},
                new Car{CarId=3,BrandId =2,ColorId=3,ModelYear=2021,DailyPrice=180,Description="Vites;Manuel,Dizel,Kompakt"},
                new Car{CarId=4,BrandId =3,ColorId=3,ModelYear=2021,DailyPrice=200,Description="Vites;Manuel,Benzin,Ekonomik"},
                new Car{CarId=5,BrandId =2,ColorId=5,ModelYear=2021,DailyPrice=200,Description="Vites;Otomatik,Dizel,Standart"}
            };

            _brands = new List<Brand>
            {
                new Brand{BrandId = 1,BrandName ="Renault Clio"},
                new Brand{BrandId = 2,BrandName ="Hyundai i20"},
                new Brand{BrandId = 3,BrandName ="Peugeot 301"}
            };

            _colors = new List<Color>
            {
                new Color{ColorId=1,ColorName ="Black"},
                new Color{ColorId=2,ColorName ="White"},
                new Color{ColorId=3,ColorName ="Red"},
                new Color{ColorId=4,ColorName ="Grey"},
                new Color{ColorId=5,ColorName ="Blue"}
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Add(Brand brand)
        {
            _brands.Add(brand);
        }

        public void Add(Color color)
        {
            _colors.Add(color);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }

        public void Delete(Brand brand)
        {
            Brand brandToDelete = _brands.SingleOrDefault(b => b.BrandId == brand.BrandId);
            _brands.Remove(brandToDelete);
        }

        public void Delete(Color color)
        {
            Color colorToDelete = _colors.SingleOrDefault(c => c.ColorId == color.ColorId);
            _colors.Remove(colorToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAllByBrand(int brandId)
        {
            return _cars.Where(c => c.BrandId == brandId).ToList();
        }

        public List<Car> GetAllByColor(int colorId)
        {
            return _cars.Where(c => c.ColorId == colorId).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }

        public void Update(Brand brand)
        {
            Brand brandToUpdate = _brands.SingleOrDefault(b => b.BrandId == brand.BrandId);
            brandToUpdate.BrandName = brand.BrandName;
        }

        public void Update(Color color)
        {
            Color colorToUpdate = _colors.SingleOrDefault(c => c.ColorId == color.ColorId);
            colorToUpdate.ColorName = color.ColorName;
        }

        List<Brand> IBrandDal.GetAll()
        {
            return _brands;
        }

        List<Color> IColorDal.GetAll()
        {
            return _colors;
        }
    }
}
