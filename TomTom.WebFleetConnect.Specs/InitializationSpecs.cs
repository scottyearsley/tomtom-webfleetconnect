using System;
using TestStack.BDDfy;
using NUnit.Framework;

namespace TomTom.WebFleetConnect.Specs
{
    namespace InitializationSpecs
    {
        [Story]
        public class ConstructorArgumentsRequired
        {
            private string _account;
            private string _username;
            private string _password;
            private string _apiKey;
            private string _paramName;
            private WebFleetClient _sut;
            private Exception _expected;
            
            [Given]
            public void GivenInvalidParameter()
            {
            }

            [When]
            public void WhenTheClientIsInitialized()
            {
                try
                {
                    _sut = new WebFleetClient(_account, _username, _password, _apiKey);
                }
                catch (Exception e)
                {
                    _expected = e;
                }
            }

            [Then]
            public void ThenAnExceptionIsThrown()
            {
                Assert.IsNotNull(_expected);
                Assert.That(_expected, Is.TypeOf<ArgumentNullException>());
                Assert.That(((ArgumentNullException)_expected).ParamName, Is.EqualTo(_paramName));
            }

            [TestCase("account", "username", "password", "", "apiKey")]
            [TestCase("account", "username", "password", null, "apiKey")]
            [TestCase("account", "username", "", "apiKey", "password")]
            [TestCase("account", "username", null, "apiKey", "password")]
            [TestCase("account", "", "password", "apiKey", "username")]
            [TestCase("account", null, "password", "apiKey", "username")]
            [TestCase("", "username", "password", "apiKey", "accountName")]
            [TestCase(null, "username", "password", "apiKey", "accountName")]
            public void Run(string account, string username, string password, string apiKey, string paramName)
            {
                _account = account;
                _username = username;
                _password = password;
                _apiKey = apiKey;
                _paramName = paramName;

                this.BDDfy();
            }
        }
    }
}