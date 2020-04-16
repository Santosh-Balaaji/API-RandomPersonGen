using CeloInterview_RestAPi_Test.Models;
using System;
using System.Collections.Generic;
using System.Text;

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
        }
    }
}
