using CeloInterview_RestAPi_Test.Models;
using System;
using System.Collections.Generic;
using System.Text;

// This provides the Mock Model data for testing purposes.
namespace RestAPI_TestCases.Repositories
{
    public class MockUsers
    {
        public List<Users> Users;

        public MockUsers()
        {
            Users = new List<Users>();
            Users.Add(new Users { UserId = 1, Title = "Mr", FirstName = "Santosh", LastName = "Balaaji", EmailId = "sv.santosh2695@gmail.com", PhoneNumber = "220760061", DateOfBirth = DateTime.Parse("1995-04-26T00:00:00"), ProfileImages = Encoding.ASCII.GetBytes("c2FudG9zaC5wbmc=") });
            Users.Add(new Users { UserId = 2, Title = "Ms", FirstName = "Denerys", LastName = "Targerian", EmailId = "danny@gmail.com", PhoneNumber = "220760222", DateOfBirth = DateTime.Parse("1997-02-12T00:00:00"), ProfileImages = Encoding.ASCII.GetBytes("c2FudG9zaC5wbmc=") });
            Users.Add(new Users { UserId = 3, Title = "Mr", FirstName = "Sureya", LastName = "Prakash", EmailId = "sunder@gmail.com", PhoneNumber = "220760345", DateOfBirth = DateTime.Parse("1994-08-21T00:00:00"), ProfileImages = Encoding.ASCII.GetBytes("c2FudG9zaC5wbmc=") });
            Users.Add(new Users { UserId = 4, Title = "Mr", FirstName = "Sree", LastName = "Krishna", EmailId = "sk@gmail.com", PhoneNumber = "220760623", DateOfBirth = DateTime.Parse("1993-05-11T00:00:00"), ProfileImages = Encoding.ASCII.GetBytes("c2FudG9zaC5wbmc=") });
            Users.Add(new Users { UserId = 5, Title = "Ms", FirstName = "Sandya", LastName = "Ragu", EmailId = "sandy@gmail.com", PhoneNumber = "220760101", DateOfBirth = DateTime.Parse("2000-01-01T00:00:00"), ProfileImages = Encoding.ASCII.GetBytes("c2FudG9zaC5wbmc=") });
            Users.Add(new Users { UserId = 6, Title = "Mr", FirstName = "Sree", LastName = "Vassa", EmailId = "sree@gmail.com", PhoneNumber = "220760341", DateOfBirth = DateTime.Parse("1995-02-21T00:00:00"), ProfileImages = Encoding.ASCII.GetBytes("c2FudG9zaC5wbmc=") });

        }
    }
}
