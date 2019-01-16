using System;
using System.Linq;
using eShop.Common;
using eShop.Helper;
using eShop.Model.Models;
using eShop.Service.Infrastructure;
using eShop.Service.ViewModel;

namespace eShop.Service.Services
{
    public interface IUserService : IServiceBase<User>
    {
        bool ValidateUser(string username, string password);
        User GetByUsername(string username);
        User GetByEmail(string email);
        User Login(LoginViewModel loginModel);
        RegisterResult Register(RegistrationViewModel registrationModel);
    }

    public class UserService : ServiceBase<User>, IUserService
    {
        public bool ValidateUser(string username, string password)
        {
            string encryptedPassword = SecretHelper.SHA512Encrypt(password);
            return GetMulti(x => x.Username == username && x.Password == encryptedPassword).Any();
        }

        public User GetByUsername(string username)
        {
            return GetMulti(x => x.Username == username).FirstOrDefault();
        }

        public User GetByEmail(string email)
        {
            return GetMulti(x => x.Email == email).FirstOrDefault();
        }

        public User Login(LoginViewModel loginModel)
        {
            string encryptedPassword = SecretHelper.SHA512Encrypt(loginModel.Password);
            return GetMulti(x => x.Username == loginModel.UserName && x.Password == encryptedPassword).FirstOrDefault();
        }

        public RegisterResult Register(RegistrationViewModel registrationModel)
        {
            User checkEmail = GetByEmail(registrationModel.Email);
            User checkUsername = GetByUsername(registrationModel.Username);
            if (checkEmail != null) return RegisterResult.MailExisted;
            if (checkUsername != null) return RegisterResult.UsernameExisted;

            //Save User Data 

            var user = new User
            {
                Username = registrationModel.Username,
                FirstName = registrationModel.FirstName,
                LastName = registrationModel.LastName,
                Email = registrationModel.Email,
                Password = SecretHelper.SHA512Encrypt(registrationModel.Password),
                City = registrationModel.City,
                Country = registrationModel.Country,
                SignupDate = DateTime.Now,
                CreatedOn = DateTime.Now,
                ChangedOn = DateTime.Now
                //ActivationCode = Guid.NewGuid(),
            };

            int result = Add(user);
            if (result <= 0) return RegisterResult.Failed;

            return RegisterResult.Success;
        }
    }
}