using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ContactList.Models
{
    public class Contact
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your Email")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }

        public string Address { get; set; }

        [Phone(ErrorMessage = "Invalid Phone")]
        public string Phone { get; set; }
    }
}