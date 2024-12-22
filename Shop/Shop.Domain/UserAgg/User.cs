using Common.Domain;
using Common.Domain.Exceptions;
using Shop.Domain.UserAgg.Enums;
using Shop.Domain.UserAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.UserAgg
{
    public class User : AggregateRoot
    {
        public User(string name, string familly, string phoneNumber, string email, string password,
            Gender gender, IDomainUserservice domainService)
        {
            Guard(phoneNumber, email, domainService);

            Name = name;
            Familly = familly;
            PhoneNumber = phoneNumber;
            Email = email;
            Password = password;
            Gender = gender;
        }

        public string Name { get; private set; }

        public string Familly { get; private set; }

        public string PhoneNumber { get; private set; }

        public string Email { get; private set; }

        public string Password { get; private set; }

        public Gender Gender { get; private set; }

        public List<UserRole> Roles { get; private set; }

        public List<Wallet> Wallets { get; private set; }

        public List<UserAddressess> Addressess { get; private set; }

        public void Edit(string name, string familly, string phoneNumber, string email, Gender gender, IDomainUserservice domainService)
        {
            Guard(phoneNumber, email, domainService);
            Name = name;
            Familly = familly;
            PhoneNumber = phoneNumber;
            Email = email;
            Gender = gender;
        }

        public static User RegisterUser(string phoneNumber,string email, string password, IDomainUserservice domainService)
        {
            return new User("", "", phoneNumber, email,password,Gender.None, domainService);
        }

        public void AddAddress(UserAddressess addressess)
        {
            addressess.UserId = Id;
            Addressess.Add(addressess);
        }

        public void EditAddress(UserAddressess addressess)
        {
            var oldAddress = Addressess.FirstOrDefault(f => f.Id == addressess.Id);
            if (oldAddress == null)
                throw new NullOrEmptyDomainDataException("Address Not Fount");

            Addressess.Remove(oldAddress);
            Addressess.Add(addressess);
        }

        public void DeleteAddress(long addressId)
        {
            var oldAddress = Addressess.FirstOrDefault(f => f.Id == addressId);
            if (oldAddress == null)
                throw new NullOrEmptyDomainDataException("Address Not Fount");

            Addressess.Remove(oldAddress);
        }

        public void chargeWallet(Wallet wallet)
        {
            Wallets.Add(wallet);
        }

        public void SetRoles(List<UserRole> roles)
        {
            roles.ForEach(f => f.UserId = Id);
            Roles.Clear();
            Roles.AddRange(roles);
        }


        public void Guard(string phoneNumber, string email, IDomainUserservice domainservice)
        {
            NullOrEmptyDomainDataException.CheckString(phoneNumber, nameof(phoneNumber));
            NullOrEmptyDomainDataException.CheckString(email, nameof(email));

            if (phoneNumber.Length != 11)
                throw new InvalidDomainDataException("شماره موبایل نامعتبر است");

            if (email.IsValidEmail() == false)
                throw new InvalidDomainDataException("ایمیل نامعتبر است");

            if (phoneNumber != PhoneNumber)
                if (domainservice.PhoneNumberExist(phoneNumber) == false)
                    throw new InvalidDomainDataException("شماره تلفن تکراری است");

            if (email != Email)
                if (domainservice.IsEmailExist(email) == false)
                    throw new InvalidDomainDataException("ایمیل تکراری است");
        }
    }
}
