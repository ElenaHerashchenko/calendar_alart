using System;
using System.Collections.Generic;
using System.Text;

namespace Calendar.Models
{
   public class UserModel: IUserModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
    }
}
