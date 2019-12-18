using System;
using System.Collections.Generic;
using System.Text;

namespace Calendar.Models
{
    interface IUserModel
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        int Phone { get; set; }
        string Email { get; set; }
        int Age { get; set; }
    }
}
