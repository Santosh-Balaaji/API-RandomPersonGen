using System;
using System.Collections.Generic;

namespace CeloInterview_RestAPi_Test.Models
{
    public partial class Users
    {
        public int UserId { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public byte[] ProfileImages { get; set; }


    }
}
