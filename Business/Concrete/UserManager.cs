using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            if (user.Email == "" && user.Password == "")
            {
                return new ErrorResult(Messages.UserNull);
            }
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }
        public IResult Delete(User user)
        {
            if (user.UserId < 1)
            {
                return new ErrorResult(Messages.UserInvalid);
            }
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserUpdate);
        }
        public IDataResult<List<User>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<User>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<User>>(Messages.UserListed);
        }
        public IDataResult<User> GetById(int userId)
        {
            return new SuccessDataResult<User>(_userDal.Get(U => U.UserId == userId));
        }
        public IResult Update(User user)
        {
            if (user.UserId < 1)
            {
                return new ErrorResult(Messages.UserInvalid);
            }
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdate);
        }
    }
}
