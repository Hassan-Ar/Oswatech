using System.Threading.Tasks;
using Oswatech.Models.TokenAuth;
using Oswatech.Web.Controllers;
using Shouldly;
using Xunit;

namespace Oswatech.Web.Tests.Controllers
{
    public class HomeController_Tests: OswatechWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}