//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Timesheet.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public partial class Login
    {
        //Instance variables
        LoginDatabaseEntities1 db = new LoginDatabaseEntities1();

        //Class properties
        public int EmpId { get; set; }
        [DisplayName("User Name")]
        [Required(ErrorMessage = "This Field is required")]
        public string Username { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "This Field is required")]
        public string Password { get; set; }
        public string LoginErrorMessage { get; set; }

        //Constructors
        //no-arg constructor
        public Login()
        {
            EmpId = 0;
            Username = "";
            Password = "";
            LoginErrorMessage = "";
        }

        //all-args constructor
        public Login(int id, string uName, string pWord, string error)
        {
            EmpId = id;
            Username = uName;
            Password = pWord;
            LoginErrorMessage = error;
        }

        //Method to validate login information
        //Queries Login table by username and password, returns bool if record is found
        public bool ValidateLogin(string uname, string pword)
        {
            var log = from logins in db.Logins
                      where logins.Username == uname && logins.Password == pword
                      select logins;
            Login login = (Login)log.FirstOrDefault();

            if (login.EmpId == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //Method to get Login object
        //Queries Login table by username and password, returns Login object
        public Login GetLogin(string uname, string pword)
        {
            var log = from logins in db.Logins
                      where logins.Username == uname && logins.Password == pword
                      select logins;
            Login login = (Login)log.FirstOrDefault();
            return login;
        }

    }
}
