using dotNetCore.Controllers;
using dotNetCore.Services.Interfaces;
using dotNetCore.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Threading.Tasks;

namespace dotNetCore.Test.Controllers
{
  [TestClass]
  public class LoginControllerTests
  {
    private IUserService subUserService;

    [TestInitialize]
    public void TestInitialize()
    {
      this.subUserService = Substitute.For<IUserService>();
    }

    private LoginController CreateLoginController()
    {
      return new LoginController(
          this.subUserService);
    }

    [TestMethod]
    public async Task Index_StateUnderTest_ExpectedBehavior1()
    {
      // Arrange
      var unitUnderTest = this.CreateLoginController();
      var login = new LoginView()
      {
        account = "test",
        password = "123"
      };

      // Act
      var result = await unitUnderTest.Index(
        login);

      // Assert
      // Assert.Fail();
      // Assert.Equals(HttpStatusCode.OK, result);
    }
  }
}
