using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {           
            CarManager carManager1 = new CarManager(new InMemoryCarDal());
            foreach (var car in carManager1.GetAll())
            {
                Console.WriteLine(car.Description);
            }

            BrandManager brandManager = new BrandManager(new InMemoryCarDal());
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandName);
            }           
        }
    }
}
