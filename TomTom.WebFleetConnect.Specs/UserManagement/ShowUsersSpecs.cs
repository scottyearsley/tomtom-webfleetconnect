using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;
using TestStack.BDDfy;
using TomTom.WebFleetConnect.Models;

namespace TomTom.WebFleetConnect.Specs.UserManagement
{
    namespace ShowUsersSpecs
    {
        public class CalledWithoutParameters
        {
            private WebFleetClient _sut;
            private List<User> _expected;
            private FakeHttpMessageHandler _mockHandler;
            private HttpRequestMessage _httpRequest;

            [Given]
            public void GivenAWebFleetClient()
            {
                _mockHandler = new FakeHttpMessageHandler(request =>
                {
                    _httpRequest = request;
                    
                    return FakeHttpMessageHandler.CreateResponse(HttpStatusCode.OK,
                        new List<User>
                        {
                            new User
                            {
                            }
                        });
                });

                _sut = SpecHelper.CreateClient(_mockHandler);
            }

            [When]
            public async Task WhenShowUsersIsInvokedWithoutParameters()
            {
                _expected = await _sut.Users.ShowUsers();
            }

            [Then]
            public void ThenTheCorrectUrlIsInvoked()
            {
                var expectedUri = SpecHelper.CreateUri("showUsers");
                Assert.That(_httpRequest.RequestUri, Is.EqualTo(expectedUri));
            }
            
            [AndThen]
            public void AndThenUsersAreReturned()
            {
                Assert.That(_expected, Has.Count.EqualTo(1));
            }

            [Test]
            public void Run()
            {
                this.BDDfy("Called without parameters");
            }
        }
    }
}