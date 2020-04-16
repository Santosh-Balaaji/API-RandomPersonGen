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
        public void GetUsers_ReturnsAllUsers()
        {

            //Arrange
            
            // Act
            var data = _Users.GetUsers();

            // Assert
            Assert.Equal("Santosh", data[0].FirstName);
        }
    }
}
