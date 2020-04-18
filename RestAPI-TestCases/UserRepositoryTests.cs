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
    // This is a Xunit Test Framework to test the functionalities of the UserRepsitory class.
    // Since we have decoupled our context object from our APIs and placed them on UserRepository, the test is focused on testing the functions present in UserRepository than testing the APIs.
    public class UserRepositoryTests
    {
        private MockUsers _MockUsers;
        private DbSet<Users> _MockDBSet;
        private IUsersContext _DBContextMock;
        private UserRepository _Users;

        public UserRepositoryTests()
        {
            _MockUsers = new MockUsers();                                                       //Object of the MockUsers class
             _MockDBSet = NSubstitueUtils.CreateMockDbSet(_MockUsers.Users);                    //Creating a MockDBset of the MockUsers's Users list
             _DBContextMock = Substitute.For<IUsersContext>();                                  
            _DBContextMock.Users.Returns(_MockDBSet);
            _Users = new UserRepository(_DBContextMock);                                        //Passing in the DBContextMock object as a context object to the UserRepository class
        }


        

        [Fact]
        public void GetUsers_BasedOnFirstName_PassingNull_Returns0()
        {

            //Arrange
            string firstname = "";
            int dataCount = 0;
            // Act
            var data = _Users.GetUsersBasedOnName(firstname);
            dataCount = data.Count;
           

            // Assert
            Assert.Equal(0,dataCount);
        }
        [Fact]
        public void GetUsers_BasedOnFirstName_PassingStringSantosh_Returns1()
        {

            //Arrange
            string firstname = "Santosh";
            int dataCount = 0;
            // Act
            var data = _Users.GetUsersBasedOnName(firstname);
            dataCount = data.Count;
            

            // Assert
            Assert.Equal(1,dataCount);
        }

        [Fact]
        public void GetUsers_BasedOnFirstName_PassingStringArnold_Returns0()
        {

            //Arrange
            string firstname = "Arnold";
            int dataCount = 0;
            // Act
            var data = _Users.GetUsersBasedOnName(firstname);
            dataCount = data.Count;


            // Assert
            Assert.Equal(0, dataCount);
        }

        [Fact]
        public void GetUsers_BasedOnFirstorLastNames_PassingStringBalaaji_Returns1()
        {

            //Arrange
            string name = "Balaaji";

            // Act
            var data = _Users.GetUsersBasedOnName(name);
            int dataCount = 0;
            dataCount = data.Count;
            

            // Assert

            Assert.Equal(1,dataCount);
        }

        [Fact]
        public void GetAllUsers_Returns6()
        {
            //Arrange
            var actualCount = 6;

            //Act
            var data = _Users.GetAllUsers();

            //Assert
            Assert.Equal(actualCount, data.Count);
        }

        [Fact]
        public void GetRandomUsers_BasedOnQuantitySpecified_Passing0_Returns0()
        {

            //Arrange
            int quantity = 0;
            int dataCount = 0;

            // Act
            var data = _Users.FetchUsersBasedOnQuantitySpecified(quantity);
            dataCount = data.Count;

            // Assert

            Assert.Equal(dataCount, quantity);
        }

        [Fact]
        public void GetRandomUsers_BasedOnQuantitySpecified_Passed3_Returns3()
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
        public void GetRandomUsers_BasedOnQuantitySpecified_PassingGreaterValueThanPresentInDB_Passed15_ReturnsNull()
        {

            //Arrange
            int quantity = 15;

            // Act
            var data = _Users.FetchUsersBasedOnQuantitySpecified(quantity);

            // Assert

            Assert.Null(data);
        }


        //This test case can fail sometimes as both the call statements might fetch the same set of users.
        [Fact]
        public void CheckForRandomUsers_Passed3_ReturnsDifferentSetofUsers()
        {

            //Arrange
            int quantity = 3;
            int count = 0;

            // Act
            var query1 = _Users.FetchUsersBasedOnQuantitySpecified(quantity);
            var query2 = _Users.FetchUsersBasedOnQuantitySpecified(quantity);
            foreach (var i in query1)
            {
                foreach (var j in query2)
                {
                    if (i.UserId == j.UserId)
                        count++;
                }
            }

            // Assert

            Assert.NotEqual(quantity, count);
        }

        [Fact]
        public void GetSingleUser_BasedOnUserId_Passed1_ReturnUserMatchingThatId()
        {

            //Arrange
            int id = 1;

            // Act
            var data = _Users.GetUsersBasedOnId(id);

            // Assert

            Assert.Equal(id, data.UserId);
        }

        [Fact]
        public void GetSingleUser_BasedOnUserId_Passed0_ReturnsNull()
        {

            //Arrange
            int id = 0;

            // Act
            Users data = _Users.GetUsersBasedOnId(id);

            // Assert

            Assert.Null(data);
        }

        [Fact]
        public void DeleteSingleUser_BasedOnUserId_ReturnsDeleteStatusTrue()
        {

            //Arrange
            int id = 5;

            // Act
            var data = _Users.DeleteUserBasedOnUserId(id);

            // Assert

            Assert.True(data);
        }

        [Fact]
        public void DeleteSingleUser_UnAvailableUserId_ReturnsDeleteStatusFalse()
        {

            //Arrange
            int id = 7;

            // Act
            var data = _Users.DeleteUserBasedOnUserId(id);

            // Assert

            Assert.False(data);
        }

        [Fact]
        public void UpdateSingleUser_BasedOnUserId_PassedInvalidUserId_ReturnsFalse()
        {
            //Arrange
            int id = 8;
            var user = new Users { UserId = 6, Title = "Mr", FirstName = "Sree", LastName = "Vassa", EmailId = "sree@gmail.com", PhoneNumber = "220760341", DateOfBirth = DateTime.Parse("1995-02-21T00:00:00"), ProfileImages = Encoding.ASCII.GetBytes("c2FudG9zaC5wbmc=") };

            //Act
            var data = _Users.UpdateUserBasedOnId(id, user);


            //Assert
            Assert.False(data);

        }


        [Fact]
        public void UpdateSingleUser_BasedOnUserId_PassingValidUserId_ReturnsTrue()
        {
            //Arrange
            int id = 6;
            var user =new Users { UserId = 6, Title = "Mr", FirstName = "Sree", LastName = "Vassa", EmailId = "sree@gmail.com", PhoneNumber = "220760341", DateOfBirth = DateTime.Parse("1995-02-21T00:00:00"), ProfileImages = Encoding.ASCII.GetBytes("c2FudG9zaC5wbmc=") };

            //Act
            var data = _Users.UpdateUserBasedOnId(id, user);


            //Assert
            Assert.True(data);
         
        }

        [Fact]
        public void CreateNewUser_PassingValidUserDetails_ReturnsTrue()
        {
            //Arrange
            int id = 6;
            var user = new Users { UserId=7 ,Title = "Ms", FirstName = "Aishwarya", LastName = "Venkat", EmailId = "aishu@gmail.com", PhoneNumber = "220760123", DateOfBirth = DateTime.Parse("1995-02-21T00:00:00"), ProfileImages = Encoding.ASCII.GetBytes("c2FudG9zaC5wbmc=") };

            //Act
            var data = _Users.InsertNewUser(user);


            //Assert
            Assert.True(data);

        }

    }
}
