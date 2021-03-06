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

    public partial class Event
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Event()
        {
            // HashSet is an unordered collection. It does not maintain the order in which the elements are inserted. HashSet internally uses a HashMap to store its elements.
            this.Registers = new HashSet<Register>();
        }

        [Required(ErrorMessage = "Please enter an event name...")]
        public string EventName { get; set; }
        [Required(ErrorMessage = "Please enter a description of the event...")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please enter an email...")]
        public string Location { get; set; }
        [Required(ErrorMessage = "Please enter a date...")]
        public string Date { get; set; }
        [Required(ErrorMessage = "Please enter the ticket cost...")]
        public decimal TicketFee { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        // ICollection - Used for a list of objects that needs to be iterated through. 
        public virtual ICollection<Register> Registers { get; set; }
    }
}
