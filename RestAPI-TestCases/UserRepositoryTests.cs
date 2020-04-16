using CeloInterview_RestAPi_Test.Models;
using CeloInterview_RestAPi_Test.Repositories;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using RestAPI_TestCases.Repositories;
using RestAPI_TestCases.Utils;
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
            Assert.Equal(data.Length, actualCount);
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


    }
}
