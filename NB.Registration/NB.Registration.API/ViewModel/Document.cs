using System;

namespace NB.Registration.API.ViewModel
{
    public class Document
    {
        public string Value { get; set; }
        public DateTime ValidDate { get; set; }
        public Guid DocumentTypeID { get; set; }
    }
}
