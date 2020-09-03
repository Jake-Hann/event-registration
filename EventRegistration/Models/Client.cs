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

    public partial class Client
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Client()
        {
            // HashSet is an unordered collection. It does not maintain the order in which the elements are inserted. HashSet internally uses a HashMap to store its elements.
            this.Registers = new HashSet<Register>();
        }
        
        [Required(ErrorMessage = "Please enter an email...")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter your full name...")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Please enter your address...")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please enter your age...")]
        [Range(18, 120, ErrorMessage = "Please enter your age (must be 18 or older)...")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Please enter a valid phone number...")]
        public string Phone { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        // ICollection - Used for a list of objects that needs to be iterated through. 
        public virtual ICollection<Register> Registers { get; set; }
    }
}