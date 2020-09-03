//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EventRegistration.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public partial class Register
    {
        public int Id { get; set; }
        [Range(1, 100, ErrorMessage = "Please enter a number between 1 and 100...")]
        [Required(ErrorMessage = "Please enter the amount of tickets you want to purchase...")]
        public int GuestNumber { get; set; }
        [Required(ErrorMessage = "Please enter the payment amount...")]
        public decimal PaymentAmount { get; set; }
        [Required(ErrorMessage = "Please select an event...")]
        public string EventName { get; set; }
        [Required(ErrorMessage = "Please select an email...")]
        public string Email { get; set; }

        // The virtual keyword is used to modify a method, property, indexer, or event declaration and allow for it to be overridden in a derived class. 
        public virtual Client Client { get; set; }
        public virtual Event Event { get; set; }
    }
}
