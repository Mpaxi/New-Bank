using NB.Registration.Domain.Commands;
using NB.Registration.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace NB.Registration.API.ViewModel
{
    public class PhysicalPerson
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
        [Required]
        public ICollection<Document> Documents { get; set; }
        [Required]
        public ICollection<InternetAddress> InternetAddresses { get; set; }

        public AddPhysicalPersonCommand CreateCommand()
        {

            return new AddPhysicalPersonCommand()
            {
                Name = this.Name,
                Birthday = this.Birthday,
                Documents = this.Documents.Select(s => new PhysicalPersonDocument() { Value = s.Value, DocumentTypeID = s.DocumentTypeID, ValidDate = s.ValidDate }),
                InternetAddresses = this.InternetAddresses.Select(s => new PhysicalPersonInternetAddress() { Value = s.Value, InternetAddressTypeID = s.InternetAddressTypeID })
            };
        }
    }
}