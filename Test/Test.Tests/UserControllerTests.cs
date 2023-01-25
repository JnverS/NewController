using Xunit;
using Test.Tests.Infrastructure.Helpers;
using Test.Repository;
using Test.Controllers;
using Microsoft.AspNetCore.Mvc;
using Test.Interfaces;
using Test.Models;
using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;

namespace Test.Tests
{
    public class UserControllerTests
    {
        private int userid = 5;
        private static DBContextHelper dBContextHelper = new DBContextHelper();
        private static UsersRepository urh = new UsersRepository(dBContextHelper.Context);
        private static UserController controller = new UserController(urh);

        [Fact]
        public void GetAll()
        {
            
            // Arrange
            IEnumerable<User> Users = dBContextHelper.Context.Users;
            // Act
            var result = controller.Get();
            
            // Assert
            Assert.Equal(Users, result);
        }
        [Fact]
        public void GetAllNotNull()
        { 
            // Act
            var result = controller.Get();

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void GetId()
        {
            User? user = dBContextHelper.Context.Users.FirstOrDefault(p => p.Id == userid); 
            // Act
            var result = controller.GetId(5);

            // Assert
            Assert.Equal(user, result);
        }
        [Fact]
        public void GetIdNotNull()
        {

            // Act
            var result = controller.GetId(5);

            // Assert
            Assert.NotNull(result);
        }
        [Fact]
        public void AddUser()
        {
            User user = new User
            {
                Id = 1,
                NickName = "testadd",
                Lvl = 1,
                TotalScore = 1,
            };
            // Act
            controller.Post(user);
            var result = dBContextHelper.Context.Users.FirstOrDefault(p => p.Id == 1);

            // Assert
            Assert.Equal(user, result);
        }

    }
}
