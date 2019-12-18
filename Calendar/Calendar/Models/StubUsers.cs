using System;
using System.Collections.Generic;
using System.Text;

namespace Calendar.Models
{
    public class StubUsers
    {
        List<UserModel> users;
        string _emailReplace;

        public StubUsers()
        {
            users = new List<UserModel>();
        }

        public void AddUser(UserModel user)
        {
            users.Add(user);
        }

        public void RemoveUser(UserModel user)
        {
            users.Remove(user);
        }

        public List<UserModel> GetUsers()
        {
            return users;
        }

        public bool CheckEmail(string email)
        {
            foreach(var item in users)
            {
                if (email.Equals(item.Email))
                {
                    _emailReplace = email;
                    return true;
                }
            }
            return false;
        }

        public void RepleacePassword(string password)
        {
            foreach (var item in users)
            {
                if (item.isExist)
               {
                    item.Password = password;
              }
            }
        }
        public bool IsExistPassword()
        {
            foreach (var item in users)
            {
                if (item.isExist)
                {
                    return true;
                }
            }
            return false;
        }
     

        public void CreateFirstUser()
        {
            UserModel user = new UserModel
            {
                FirstName = "Pol",
                SecondName = "Smith",
                Phone = "+38(068)777-55-55",
                Email = "pol@gmail.com",
                Age = 20,
                Login = "pol",
                Password = "123"
            };
            users.Add(user);
        }

    }
}
