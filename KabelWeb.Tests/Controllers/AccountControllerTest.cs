using System;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using Xunit;
using KabelWeb;
using KabelWeb.Controllers;
using KabelWeb.Models;

namespace KabelWeb.Tests.Controllers
{
    public class AccountControllerTest
    {
        [Fact]
        public void ChangePassword_Get_ReturnsView()
        {
            // Arrange
            AccountController controller = GetAccountController();

            // Act
            ActionResult result = controller.ChangePassword();

            // Assert
            Assert.IsType<ViewResult>(result);
            Assert.Equal(10, ((ViewResult)result).ViewData["PasswordLength"]);
        }

        [Fact]
        public void ChangePassword_Post_ReturnsRedirectOnSuccess()
        {
            // Arrange
            AccountController controller = GetAccountController();
            ChangePasswordModel model = new ChangePasswordModel()
            {
                OldPassword = "goodOldPassword",
                NewPassword = "goodNewPassword",
                ConfirmPassword = "goodNewPassword"
            };

            // Act
            ActionResult result = controller.ChangePassword(model);

            // Assert
            Assert.IsType<RedirectToRouteResult>(result);
            RedirectToRouteResult redirectResult = (RedirectToRouteResult)result;
            Assert.Equal("ChangePasswordSuccess", redirectResult.RouteValues["action"]);
        }

        [Fact]
        public void ChangePassword_Post_ReturnsViewIfChangePasswordFails()
        {
            // Arrange
            AccountController controller = GetAccountController();
            ChangePasswordModel model = new ChangePasswordModel()
            {
                OldPassword = "goodOldPassword",
                NewPassword = "badNewPassword",
                ConfirmPassword = "badNewPassword"
            };

            // Act
            ActionResult result = controller.ChangePassword(model);

            // Assert
            Assert.IsType<ViewResult>(result);
            ViewResult viewResult = (ViewResult)result;
            Assert.Equal(viewResult.ViewData.Model, model);
            Assert.Equal("The current password is incorrect or the new password is invalid.", controller.ModelState[""].Errors[0].ErrorMessage);
            Assert.Equal(10, viewResult.ViewData["PasswordLength"]);
        }

        [Fact]
        public void ChangePassword_Post_ReturnsViewIfModelStateIsInvalid()
        {
            // Arrange
            AccountController controller = GetAccountController();
            ChangePasswordModel model = new ChangePasswordModel()
            {
                OldPassword = "goodOldPassword",
                NewPassword = "goodNewPassword",
                ConfirmPassword = "goodNewPassword"
            };
            controller.ModelState.AddModelError("", "Dummy error message.");

            // Act
            ActionResult result = controller.ChangePassword(model);

            // Assert
            Assert.IsType<ViewResult>(result);
            ViewResult viewResult = (ViewResult)result;
            Assert.Equal(model, viewResult.ViewData.Model);
            Assert.Equal(10, viewResult.ViewData["PasswordLength"]);
        }

        [Fact]
        public void ChangePasswordSuccess_ReturnsView()
        {
            // Arrange
            AccountController controller = GetAccountController();

            // Act
            ActionResult result = controller.ChangePasswordSuccess();

            // Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void LogOff_LogsOutAndRedirects()
        {
            // Arrange
            AccountController controller = GetAccountController();

            // Act
            ActionResult result = controller.LogOff();

            // Assert
            Assert.IsType<RedirectToRouteResult>(result);
            RedirectToRouteResult redirectResult = (RedirectToRouteResult)result;
            Assert.Equal("Home", redirectResult.RouteValues["controller"]);
            Assert.Equal("Index", redirectResult.RouteValues["action"]);
            // TODO: Mocking Framework
            Assert.True(((MockFormsAuthenticationService)controller.FormsService).SignOut_WasCalled);
        }

        [Fact]
        public void LogOn_Get_ReturnsView()
        {
            // Arrange
            AccountController controller = GetAccountController();

            // Act
            ActionResult result = controller.LogOn();

            // Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void LogOn_Post_ReturnsRedirectOnSuccess_WithoutReturnUrl()
        {
            // Arrange
            AccountController controller = GetAccountController();
            LogOnModel model = new LogOnModel()
            {
                UserName = "someUser",
                Password = "goodPassword",
                RememberMe = false
            };

            // Act
            ActionResult result = controller.LogOn(model, null);

            // Assert
            Assert.IsType<RedirectToRouteResult>(result);
            RedirectToRouteResult redirectResult = (RedirectToRouteResult)result;
            Assert.Equal("Home", redirectResult.RouteValues["controller"]);
            Assert.Equal("Index", redirectResult.RouteValues["action"]);
            // TODO: Mocking Framework
            Assert.True(((MockFormsAuthenticationService)controller.FormsService).SignIn_WasCalled);
        }

        [Fact]
        public void LogOn_Post_ReturnsRedirectOnSuccess_WithLocalReturnUrl()
        {
            // Arrange
            AccountController controller = GetAccountController();
            LogOnModel model = new LogOnModel()
            {
                UserName = "someUser",
                Password = "goodPassword",
                RememberMe = false
            };

            // Act
            ActionResult result = controller.LogOn(model, "/someUrl");

            // Assert
            Assert.IsType<RedirectResult>(result);
            RedirectResult redirectResult = (RedirectResult)result;
            Assert.Equal("/someUrl", redirectResult.Url);
            // TODO: Mocking Framework
            Assert.True(((MockFormsAuthenticationService)controller.FormsService).SignIn_WasCalled);
        }

        [Fact]
        public void LogOn_Post_ReturnsRedirectToHomeOnSuccess_WithExternalReturnUrl()
        {
            // Arrange
            AccountController controller = GetAccountController();
            LogOnModel model = new LogOnModel()
            {
                UserName = "someUser",
                Password = "goodPassword",
                RememberMe = false
            };

            // Act
            ActionResult result = controller.LogOn(model, "http://malicious.example.net");

            // Assert
            Assert.IsType<RedirectToRouteResult>(result);
            RedirectToRouteResult redirectResult = (RedirectToRouteResult)result;
            Assert.Equal("Home", redirectResult.RouteValues["controller"]);
            Assert.Equal("Index", redirectResult.RouteValues["action"]);
            // TODO: Mocking Framework
            Assert.True(((MockFormsAuthenticationService)controller.FormsService).SignIn_WasCalled);
        }

        [Fact]
        public void LogOn_Post_ReturnsViewIfModelStateIsInvalid()
        {
            // Arrange
            AccountController controller = GetAccountController();
            LogOnModel model = new LogOnModel()
            {
                UserName = "someUser",
                Password = "goodPassword",
                RememberMe = false
            };
            controller.ModelState.AddModelError("", "Dummy error message.");

            // Act
            ActionResult result = controller.LogOn(model, null);

            // Assert
            Assert.IsType<ViewResult>(result);
            ViewResult viewResult = (ViewResult)result;
            Assert.Equal(model, viewResult.ViewData.Model);
        }

        [Fact]
        public void LogOn_Post_ReturnsViewIfValidateUserFails()
        {
            // Arrange
            AccountController controller = GetAccountController();
            LogOnModel model = new LogOnModel()
            {
                UserName = "someUser",
                Password = "badPassword",
                RememberMe = false
            };

            // Act
            ActionResult result = controller.LogOn(model, null);

            // Assert
            Assert.IsType<ViewResult>(result);
            ViewResult viewResult = (ViewResult)result;
            Assert.Equal(model, viewResult.ViewData.Model);
            Assert.Equal("The user name or password provided is incorrect.", controller.ModelState[""].Errors[0].ErrorMessage);
        }

        [Fact]
        public void Register_Get_ReturnsView()
        {
            // Arrange
            AccountController controller = GetAccountController();

            // Act
            ActionResult result = controller.Register();

            // Assert
            Assert.IsType<ViewResult>(result);
            Assert.Equal(10, ((ViewResult)result).ViewData["PasswordLength"]);
        }

        [Fact]
        public void Register_Post_ReturnsRedirectOnSuccess()
        {
            // Arrange
            AccountController controller = GetAccountController();
            RegisterModel model = new RegisterModel()
            {
                UserName = "someUser",
                Email = "goodEmail",
                Password = "goodPassword",
                ConfirmPassword = "goodPassword"
            };

            // Act
            ActionResult result = controller.Register(model);

            // Assert
            Assert.IsType<RedirectToRouteResult>(result);
            RedirectToRouteResult redirectResult = (RedirectToRouteResult)result;
            Assert.Equal("Home", redirectResult.RouteValues["controller"]);
            Assert.Equal("Index", redirectResult.RouteValues["action"]);
        }

        [Fact]
        public void Register_Post_ReturnsViewIfRegistrationFails()
        {
            // Arrange
            AccountController controller = GetAccountController();
            RegisterModel model = new RegisterModel()
            {
                UserName = "duplicateUser",
                Email = "goodEmail",
                Password = "goodPassword",
                ConfirmPassword = "goodPassword"
            };

            // Act
            ActionResult result = controller.Register(model);

            // Assert
            Assert.IsType<ViewResult>(result);
            ViewResult viewResult = (ViewResult)result;
            Assert.Equal(model, viewResult.ViewData.Model);
            Assert.Equal("Username already exists. Please enter a different user name.", controller.ModelState[""].Errors[0].ErrorMessage);
            Assert.Equal(10, viewResult.ViewData["PasswordLength"]);
        }

        [Fact]
        public void Register_Post_ReturnsViewIfModelStateIsInvalid()
        {
            // Arrange
            AccountController controller = GetAccountController();
            RegisterModel model = new RegisterModel()
            {
                UserName = "someUser",
                Email = "goodEmail",
                Password = "goodPassword",
                ConfirmPassword = "goodPassword"
            };
            controller.ModelState.AddModelError("", "Dummy error message.");

            // Act
            ActionResult result = controller.Register(model);

            // Assert
            Assert.IsType<ViewResult>(result);
            ViewResult viewResult = (ViewResult)result;
            Assert.Equal(model, viewResult.ViewData.Model);
            Assert.Equal(10, viewResult.ViewData["PasswordLength"]);
        }

        private static AccountController GetAccountController()
        {
            RequestContext requestContext = new RequestContext(new MockHttpContext(), new RouteData());
            AccountController controller = new AccountController()
            {
                FormsService = new MockFormsAuthenticationService(),
                MembershipService = new MockMembershipService(),
                Url = new UrlHelper(requestContext),
            };
            controller.ControllerContext = new ControllerContext()
            {
                Controller = controller,
                RequestContext = requestContext
            };
            return controller;
        }

        private class MockFormsAuthenticationService : IFormsAuthenticationService
        {
            public bool SignIn_WasCalled;
            public bool SignOut_WasCalled;

            public void SignIn(string userName, bool createPersistentCookie)
            {
                // verify that the arguments are what we expected
                Assert.Equal("someUser", userName);
                Assert.False(createPersistentCookie);

                SignIn_WasCalled = true;
            }

            public void SignOut()
            {
                SignOut_WasCalled = true;
            }
        }

        private class MockHttpContext : HttpContextBase
        {
            private readonly IPrincipal _user = new GenericPrincipal(new GenericIdentity("someUser"), null /* roles */);
            private readonly HttpRequestBase _request = new MockHttpRequest();

            public override IPrincipal User
            {
                get
                {
                    return _user;
                }
                set
                {
                    base.User = value;
                }
            }

            public override HttpRequestBase Request
            {
                get
                {
                    return _request;
                }
            }
        }

        private class MockHttpRequest : HttpRequestBase
        {
            private readonly Uri _url = new Uri("http://mysite.example.com/");

            public override Uri Url
            {
                get
                {
                    return _url;
                }
            }
        }

        private class MockMembershipService : IMembershipService
        {
            public int MinPasswordLength
            {
                get { return 10; }
            }

            public bool ValidateUser(string userName, string password)
            {
                return (userName == "someUser" && password == "goodPassword");
            }

            public MembershipCreateStatus CreateUser(string userName, string password, string email)
            {
                if (userName == "duplicateUser")
                {
                    return MembershipCreateStatus.DuplicateUserName;
                }

                // verify that values are what we expected
                Assert.Equal("goodPassword", password);
                Assert.Equal("goodEmail", email);

                return MembershipCreateStatus.Success;
            }

            public bool ChangePassword(string userName, string oldPassword, string newPassword)
            {
                return (userName == "someUser" && oldPassword == "goodOldPassword" && newPassword == "goodNewPassword");
            }
        }
    }
}
