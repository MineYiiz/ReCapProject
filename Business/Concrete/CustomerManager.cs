﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Add(Customer customer) 
        {
            if (customer.CompanyName.Length < 2)
            {
                return new ErrorResult(Messages.CustomerNameInvalid);
            }
            _customerDal.Add(customer);
            return new SuccessResult(Messages.CustomerAdded);
        }
        public IResult Delete(Customer customer) 
        {
            if (customer.CustomerId < 1)
            {
                return new ErrorResult(Messages.CustomerNameInvalid);
            }
            _customerDal.Delete(customer);
            return new SuccessResult(Messages.CustomerDeleted);
        }
        public IDataResult<List<Customer>> GetAll()
        {
            if (DateTime.Now.Hour ==22)
            {
                return new ErrorDataResult<List<Customer>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Customer>>(Messages.CustomerListed);
        }
        public IDataResult<Customer> GetById(int customerId) 
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(cstmr => cstmr.CustomerId == customerId));
        }
        public IResult Update(Customer customer)
        {
            if (customer.CustomerId < 1)
            {
                return new ErrorResult(Messages.CustomerNameInvalid);
            }
            _customerDal.Update(customer);
            return new SuccessResult(Messages.CustomerUpdate);
        }
    }
}