﻿using Common.Domain;
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
        private User()
        {

        }
        public User(string name, string family, string phoneNumber, string email,
            string password, Gender gender, IDomainUserservice userDomainService)
        {
            Guard(phoneNumber, email, userDomainService);

            Name = name;
            Familly = family;
            PhoneNumber = phoneNumber;
            Email = email;
            Password = password;
            Gender = gender;
            Avatar = "avatar.png";
            IsActive = true;
            Roles = new();
            Wallets = new();
            Addressess = new();
            Tokens = new();
        }

        public string Name { get; private set; }

        public string Familly { get; private set; }

        public string PhoneNumber { get; private set; }

        public string Email { get; private set; }

        public string Password { get; private set; }

        public string Avatar { get; private set; }

        public bool IsActive { get; set; }

        public Gender Gender { get; private set; }

        public List<UserRole> Roles { get; private set; }

        public List<Wallet> Wallets { get; private set; }

        public List<UserAddressess> Addressess { get; private set; }
        public List<UserToken> Tokens { get; }


        public void Edit(string name, string familly, string phoneNumber, string email, Gender gender, IDomainUserservice domainService)
        {
            Guard(phoneNumber, email, domainService);
            Name = name;
            Familly = familly;
            PhoneNumber = phoneNumber;
            Email = email;
            Gender = gender;
        }
        
        public void ChangePassword(string newPassword)
        {
            NullOrEmptyDomainDataException.CheckString(newPassword, nameof(newPassword));

            Password = newPassword;
        }
        public static User RegisterUser(string phoneNumber, string password, IDomainUserservice userDomainService)
        {
            return new User("", "", phoneNumber, null, password, Gender.None, userDomainService);
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

        public void SetImage(string image)
        {
            if (image == null)
                image = "avatar.png";

            Avatar = image;
        }
        
        public void AddToken(string hashJwtToken, string hashRefreshToken, DateTime tokenExpireDate, DateTime refreshTokenExpireDate, string device)
        {
            var activeTokenCount = Tokens.Count(c => c.RefreshTokenExpireDate > DateTime.Now);
            if (activeTokenCount == 3)
                throw new InvalidDomainDataException("امکان استفاده از 4 دستگاه همزمان وجود ندارد");

            var token = new UserToken(hashJwtToken, hashRefreshToken, tokenExpireDate, refreshTokenExpireDate, device);
            token.UserId = Id;
            Tokens.Add(token);
        }
        
        public string RemoveToken(long tokenId)
        {
            var token = Tokens.FirstOrDefault(f => f.Id == tokenId);
            if (token == null)
                throw new InvalidDomainDataException("invalid TokenId");

            Tokens.Remove(token);
            return token.HashJwtToken;
        }
        
        public void DeleteAddress(long addressId)
        {
            var oldAddress = Addressess.FirstOrDefault(f => f.Id == addressId);
            if (oldAddress == null)
                throw new NullOrEmptyDomainDataException("Address Not Fount");

            Addressess.Remove(oldAddress);
        }

        public void ChargeWallet(Wallet wallet)
        {
            wallet.UserId = Id;
            Wallets.Add(wallet);
        }

        public void SetRoles(List<UserRole> roles)
        {
            roles.ForEach(f => f.UserId = Id);
            Roles.Clear();
            Roles.AddRange(roles);
        }
        
        public void SetActiveAddress(long addressId)
        {
            var currentAddress = Addressess.FirstOrDefault(f => f.Id == addressId);
            if (currentAddress == null)
                throw new NullOrEmptyDomainDataException("Address Not found");

            foreach (var address in Addressess)
            {
                address.SetDeActive();
            }
            currentAddress.SetActive();
        }

        private void Guard(string phoneNumber, string email, IDomainUserservice domainservice)
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
