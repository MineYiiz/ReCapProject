using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentACarContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails() 
             {
            using (RentACarContext context = new RentACarContext())
            {
                var result = 
                             from rental in context.Rentals
                             join car in context.Cars
                             on rental.CarId equals car.CarId

                             join brand in context.Brands
                             on car.BrandId equals brand.BrandId

                             join customer in context.Customers
                             on rental.CustomerId equals customer.CustomerId
                             select new RentalDetailDto
                             {
                                 RentalId = rental.RentalId,
                                 CompanyName = customer.CompanyName,
                                 BrandName = brand.BrandName,
                                 CarName = car.CarName,                                 
                                 DailyPrice = car.DailyPrice,
                                 RentDate = rental.RentDate,
                                 ReturnDate = rental.ReturnDate
                             };
                return result.ToList();

            }
        }
    }
}
