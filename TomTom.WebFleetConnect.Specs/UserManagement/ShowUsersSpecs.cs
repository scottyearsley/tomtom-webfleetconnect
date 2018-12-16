using System.Collections.Generic;
using TestStack.BDDfy;
using TomTom.WebFleetConnect.Models;

namespace TomTom.WebFleetConnect.Specs.UserManagement
{
    namespace ShowUsersSpecs
    {
        class CalledWithoutParameters
        {
            private WebFleetClient _sut;
            private List<User> _expected;

            [Given]
            public void GivenAWebFleetClient()
            {
                _sut = new WebFleetClient("account", "username", "password", "apiKey");
            }

            [When]
            public void WhenShowUsersIsInvokedWithoutParameters()
            {
                _expected = _sut.Users.ShowUsers();
            }

            [Then]
            public void ThenTheCorrectUrlIsInvoked()
            {
                
            }
        }
        
        
    }
}