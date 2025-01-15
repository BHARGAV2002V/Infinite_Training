using Moq;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System.Web.Mvc;
using ETradingClient.Controllers;
using ETradingClient.Models;
using ETradingClient.Services;
using System.Threading.Tasks;

namespace EtradingTests.Controllers
{
    [TestFixture]
    public class AccountControllerTests
    {
        private Mock<UserService> _mockService;
        private AccountController _controller;

        [SetUp]
        public void SetUp()
        {
            _mockService = new Mock<UserService>();
            _controller = new AccountController(_mockService.Object);
        }

        [Test]
        public async Task Login_ValidUser_ReturnsRedirectToRoute()
        {
            // Arrange
            var user = new User { Username = "testuser", Password = "password", IsCustomer = true };

            // Mock service methods
            _mockService.Setup(s => s.LoginUserAsync(It.IsAny<User>())).ReturnsAsync("Login successful");
            _mockService.Setup(s => s.GetUserByUsernameAsync(It.IsAny<string>()))
                        .ReturnsAsync(new User { Username = "testuser", UserID = 1 });

            // Act
            var result = await _controller.Login(user) as RedirectToRouteResult;

            // Assert
            ClassicAssert.IsNotNull(result); 
            ClassicAssert.AreEqual("Search", result.RouteValues["action"]); 
            ClassicAssert.AreEqual("Products", result.RouteValues["controller"]);  
        }

        [Test]
        public async Task Register_ValidUser_ReturnsRedirectToRoute()
        {
            // Arrange
            var user = new User { Username = "newuser", Password = "password", IsCustomer = true };

            // Mock service methods
            _mockService.Setup(s => s.RegisterUserAsync(It.IsAny<User>())).ReturnsAsync("Registration successful");
            _mockService.Setup(s => s.GetUserByUsernameAsync(It.IsAny<string>()))
                        .ReturnsAsync(new User { Username = "newuser", UserID = 2 });

            // Act
            var result = await _controller.Register(user) as RedirectToRouteResult;

            // Assert
            ClassicAssert.IsNotNull(result);  
            ClassicAssert.AreEqual("Add", result.RouteValues["action"]);  
            ClassicAssert.AreEqual("Profile", result.RouteValues["controller"]);  
        }
    }
}