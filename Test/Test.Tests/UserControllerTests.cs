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

        [Fact]
        public void GetAll()
        {
            
            DBContextHelper dBContextHelper = new DBContextHelper(); ;
            UsersRepository urh = new UsersRepository(dBContextHelper.Context);
            UserController controller = new UserController(urh);
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
            DBContextHelper dBContextHelper = new DBContextHelper();

            UsersRepository urh = new UsersRepository(dBContextHelper.Context);
            //Arrange
            UserController controller = new UserController(urh);
            // Act
            var result = controller.Get();

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void GetId()
        {
            DBContextHelper dBContextHelper = new DBContextHelper();
            UsersRepository urh = new UsersRepository(dBContextHelper.Context);
            // Arrange
            UserController controller = new UserController(urh);
            User user = dBContextHelper.Context.Users.FirstOrDefault(p => p.Id == userid); 
            // Act
            var result = controller.GetId(5);

            // Assert
            Assert.Equal(user, result);
        }
        [Fact]
        public void GetIdNotNull()
        {
            DBContextHelper dBContextHelper = new DBContextHelper();
            UsersRepository urh = new UsersRepository(dBContextHelper.Context);
            // Arrange
            UserController controller = new UserController(urh);
            // Act
            var result = controller.GetId(5);

            // Assert
            Assert.NotNull(result);
        }
        [Fact]
        public void AddUser()
        {
            DBContextHelper dBContextHelper = new DBContextHelper();
            UsersRepository urh = new UsersRepository(dBContextHelper.Context);
            // Arrange
            UserController controller = new UserController(urh);
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
