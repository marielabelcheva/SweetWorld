using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using SweetWorld.Core.Contracts;
using SweetWorld.Core.Models.UserViewModels;
using SweetWorld.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetWorld.Tests.UnitTests
{
    [TestFixture]
    public class UserServiceTestClass : UnitTestsBase
    {
        private IUserService userService;

        [SetUp]
        public async Task SetUp()
        {
            this.userService = new UserService(this.context);
        }

        [Test]
        [TestCase("00000000-0000-0000-0000-000000000000")]
        [TestCase("11c43ee8-b9d3-4e51-b73f-bd9dda66e29c")]
        public async Task DeleteUserShouldThrowException(string id)
        {
            Assert.ThrowsAsync<NullReferenceException>(async () => await this.userService.DeleteUserAsync(id));
        }

        [Test]
        public async Task DeleteUserShouldReturnCorrectResult()
        {
            await this.userService.DeleteUserAsync("f25654a2-67f5-44a0-8d4f-14890fdbb682");

            var user = await this.context.Users.FindAsync("f25654a2-67f5-44a0-8d4f-14890fdbb682");

            Assert.IsNull(user);
        }

        [Test]
        public async Task GetUserByIdShouldReturnCorrectViewModel()
        {
            var dbUser = await this.context.Users.FindAsync("f25654a2-67f5-44a0-8d4f-14890fdbb682");

            var user = await this.userService.GetUserByIdAsync("f25654a2-67f5-44a0-8d4f-14890fdbb682");

            Assert.That(user.Id, Is.EqualTo(dbUser?.Id));
            Assert.That(user.Email, Is.EqualTo(dbUser?.Email));
        }

        [Test]
        [TestCase("00000000-0000-0000-0000-000000000000")]
        [TestCase("11c43ee8-b9d3-4e51-b73f-bd9dda66e29c")]
        public async Task GetUserByIdShoulThrowException(string id)
        {
            Assert.ThrowsAsync<NullReferenceException>(async () => await this.userService.GetUserByIdAsync(id));
        }

        [Test]
        [TestCase("00000000-0000-0000-0000-000000000000")]
        [TestCase("11c43ee8-b9d3-4e51-b73f-bd9dda66e29c")]
        public async Task UpdateUserShouldThrowException(string id)
        {
            var user = new UserViewModel
            {
                Id = id,
                FirstName = "Test",
                LastName = "Testov",
                Email = "testTestov@gmail.com"
            };

            Assert.ThrowsAsync<NullReferenceException>(async () => await this.userService.UpdateUserAsync(user));
        }

        [Test]
        public async Task UpdateUserShouldReturnCorrectResult()
        {
            var user = new UserViewModel
            {
                Id = "f25654a2-67f5-44a0-8d4f-14890fdbb682",
                FirstName = "Test",
                LastName = "Testov",
                Email = "testTestov@gmail.com"
            };

            await this.userService.UpdateUserAsync(user);

            var dbUser = await this.context.Users.FindAsync("f25654a2-67f5-44a0-8d4f-14890fdbb682");

            Assert.IsNotNull(dbUser);
            Assert.That(dbUser.FirstName, Is.EqualTo("Test"));
            Assert.That(dbUser.LastName, Is.EqualTo("Testov"));
            Assert.That(dbUser.Email, Is.EqualTo("testTestov@gmail.com"));
        }
    }
}
