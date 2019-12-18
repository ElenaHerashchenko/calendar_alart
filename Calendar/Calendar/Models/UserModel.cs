using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Calendar.Models
{
   public class UserModel
    {
        [Required(ErrorMessage = "First name not specified")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Second name not specified")]
        public string SecondName { get; set; }
        [Required]
        [RegularExpression(@"^\+\d{2}\(\d{3}\)\d{3}-\d{2}-\d{2}$", ErrorMessage = "The phone number uncorrect")]
        public string Phone { get; set; }
        [Required]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Uncorrect address")]
        public string Email { get; set; }
        [Required]
        [Range(1, 100, ErrorMessage = "Unacceptable age")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Login not specified")]
        public string Login { get; set; }
        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$", ErrorMessage = "Uncorrect passvord")]
        public string Password { get; set; }
        public bool isExist = true;
        public UserModel() { }

        public UserModel(string firstName, string secondName, string phone, string email, int age, string login, string password)
        {
            FirstName = firstName;
            SecondName = secondName;
            Phone = phone;
            Email = email;
            Age = age;
            Login = login;
            Password = password;
        }
    }
}
