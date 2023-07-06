//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Project_College
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public partial class Staff
    {

        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required (ErrorMessage = "Enter Your Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Select Gender")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Enter Your Mobile Number")]
        [Display (Name = "MobileNo")]
        public string MobileNumber { get; set; }

        [Required(ErrorMessage = "Enter Your Email")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter Your Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Select Your Department")]
        public int DeptId { get; set; }

        public virtual Department Department { get; set; }
    }
}
