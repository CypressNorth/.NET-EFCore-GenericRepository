using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EFCoreRepository.ExampleEntities
{
    public class Entity : BaseEntity
    {
        public string FullName => $"{FirstName} {LastName}".Trim();

        [StringLength(50), Display(Name = "First Name")]
        public string FirstName { get; set; }

        [StringLength(50), Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [StringLength(50), Display(Name = "Last Name")]
        public string LastName { get; set; }

        [StringLength(150), Display(Name = "Address 1")]
        public string Address1 { get; set; }

        [StringLength(150), Display(Name = "Address 2")]
        public string Address2 { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(50)]
        public string State { get; set; }

        [StringLength(15)]
        public string Zipcode { get; set; }
    }
}
