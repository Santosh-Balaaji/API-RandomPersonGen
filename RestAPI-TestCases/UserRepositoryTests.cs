using CeloInterview_RestAPi_Test.Models;
using CeloInterview_RestAPi_Test.Repositories;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using RestAPI_TestCases.Repositories;
using RestAPI_TestCases.Utils;
using System;
using System.Text;
using Xunit;

namespace RestAPI_TestCases
{
    public class UserRepositoryTests
    {
        private MockUsers _MockUsers;
        private DbSet<Users> _MockDBSet;
        private IUsersContext _DBContextMock;
        private UserRepository _Users;

        public UserRepositoryTests()
        {
            _MockUsers = new MockUsers();
             _MockDBSet = NSubstitueUtils.CreateMockDbSet(_MockUsers.Users);
             _DBContextMock = Substitute.For<IUsersContext>();
            _DBContextMock.Users.Returns(_MockDBSet);
            _Users = new UserRepository(_DBContextMock);
        }


        [Fact]
        public void GetAllUsers_ReturnsAllUsers()
        {
            //Arrange
            var actualCount= _MockUsers.Users.Count;

            //Act
            var data = _Users.GetAllUsers();

            //Assert
            Assert.Equal(data.Count, actualCount);
        }
        [Fact]
        public void GetUsers_BasedOnFirstName_ReturnsTrue()
        {

            //Arrange
            string firstname = "Santosh";
            int count=0,dataCount = 0;
            // Act
            var data = _Users.GetUsersBasedOnName(firstname);
            dataCount = data.Count;
            foreach (var user in data)
            {
                if (user.FirstName == firstname)
                    count++;
            }

            // Assert
            Assert.Equal(dataCount, count);
        }

        [Fact]
        public void GetUsers_BasedOnFirstorLastNames_ReturnsTrue()
        {

            //Arrange
            string name = "Balaaji";

            // Act
            var data = _Users.GetUsersBasedOnName(name);
            int count = 0, dataCount = 0;
            dataCount = data.Count;
            foreach (var user in data)
            {
                if (user.FirstName == name || user.LastName == name)
                    count++;
            }

            // Assert

            Assert.Equal(dataCount, count);
        }

        [Fact]
        public void GetRandomUsers_BasedOnQuantity_ReturnsRandomUsersOfSpecifiedAmount()
        {

            //Arrange
            int quantity = 3;
            int dataCount = 0;

            // Act
            var data = _Users.FetchUsersBasedOnQuantitySpecified(quantity);
            dataCount = data.Count;

            // Assert

            Assert.Equal(dataCount, quantity);
        }

        [Fact]
        public void GetSingleUser_BasedOnUserId_ReturnUserMatchingThatId()
        {

            //Arrange
            int id = 1;

            // Act
            var data = _Users.GetUsersBasedOnId(id);

            // Assert

            Assert.Equal(id, data.UserId);
        }

        [Fact]
        public void DeleteSingleUser_BasedOnUserId_ReturnsDeleteStatus()
        {

            //Arrange
            int id = 5;

            // Act
            var data = _Users.DeleteUserBasedOnUserId(id);

            // Assert

            Assert.True(data);
        }

        [Fact]

        public void UpdateSingleUser_BasedOnUserId_ReturnsUpdatedUserDetails()
        {
            //Arrange
            int id = 6;
            var user =new Users { UserId = 6, Title = "Mr", FirstName = "Sree", LastName = "Vassa", EmailId = "sree@gmail.com", PhoneNumber = "220760341", DateOfBirth = DateTime.Parse("1995-02-21T00:00:00"), ProfileImages = Encoding.ASCII.GetBytes("c2FudG9zaC5wbmc=") };

            //Act
            var data = _Users.UpdateUserBasedOnId(id, user);


            //Assert
            Assert.True(data);
         
        }



    }
}
