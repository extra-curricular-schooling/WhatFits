﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;
// Used For Models
using Whatfits.Models.Models;
// Used for Context File Registration
using Whatfits.Models.Context.Core;
// Used for Data Transfer Objects
using Whatfits.DataAccess.DataTransferObjects.CoreDTOs;
using Whatfits.DataAccess.GatewayInterfaces;

namespace Whatfits.Gateways.Gateways.CoreGateways
{
    public class RegistrationGateway: IDataGateway<RegistrationDTO>
    {
        private RegistrationContext db = new RegistrationContext();

        public void Create(RegistrationDTO obj)
        {
            User user = new User
            {
                FirstName = obj.GetFirstName(),
                LastName = obj.GetLastName(),
                ID = obj.GetID(),
                Email = obj.GetEmail(),
                Gender = obj.GetGender(),
                IsPartialRegistration = obj.GetPartialRegistration(),
                IsDisabled = obj.GetIsDisabled()
            };
            Credential credential = new Credential {
                UserName = obj.GetUserName(),
                Password = obj.GetPassword(),
                UserID = obj.GetID()
            };
            Location location = new Location {
                Address = obj.GetAddress(),
                City = obj.GetCity(),
                State = obj.GetState(),
                Zipcode = obj.GetZipcode(),
                UserID = obj.GetID()
            };
            PersonalKey personalkey = new PersonalKey
            {
                Salt = obj.GetSalt(),
                UserID = obj.GetID()
            };

            db.Users.Add(user);
            // implementing userClaims
            List<int> claims = obj.GetUserClaims();
            for (int i = 0; i < claims.Count; i++)
            {
                UserClaims temp = new UserClaims();
                temp.ClaimID = claims[i];
                db.UserClaims.Add(temp);
            }
            db.Credentials.Add(credential);
            db.Locations.Add(location);
            db.PersonalKeys.Add(personalkey);
            Save();
        }

        public void Update(RegistrationDTO obj)
        {
            throw new NotImplementedException();
        }

  

        public void Disable(int? id)
        {
            throw new NotImplementedException();
        }

        public string FindByID(int id)
        {
            string UserName = (from x in db.Credentials
                               where x.UserID == id
                               select x.UserName).FirstOrDefault();
            return UserName;
        }

        public int FindByUserName(string userName)
        {
            
            int userID = (from u in db.Credentials
                        where u.UserName == userName
                        select u.UserID).FirstOrDefault();

            return userID;
        }
        public Boolean DoesUserNameExist(string userName)
        {
            string foundUserName = (from x in db.Credentials
                         where x.UserName == userName
                         select x.UserName).FirstOrDefault();
            if (userName == foundUserName)
                return true;
            else
                return false;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}