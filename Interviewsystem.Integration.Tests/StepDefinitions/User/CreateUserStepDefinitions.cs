using Interviewsystem.Application.Responses;
using Interviewsystem.Application.User.Commands.CreateUser;
using Newtonsoft.Json;
using System;
using System.Net.Http.Json;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Shouldly;
using Interviewsystem.Domain.Enumerations;

namespace Interviewsystem.Integration.Tests.StepDefinitions.User
{
    [Binding]
    public class CreateUserStepDefinitions : IClassFixture<TestingWebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        private CreateUserCommand _createUserCommand;
        private HttpResponseMessage _response;
        public CreateUserStepDefinitions(TestingWebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
            _createUserCommand = new();
            _response = new HttpResponseMessage();
        }

        [Given(@"I have entered my information")]
        public void GivenIHaveEnteredTheInformationForSigningUp(Table table)
        {
            var data = table?.CreateSet<CreateUserCommand>().FirstOrDefault();
            if (data != null)
            {
                //_createUserCommand.UserId = data.UserId;
                _createUserCommand.Email = data.Email;
                _createUserCommand.Password = data.Password;
                _createUserCommand.FullName = data.FullName;
                _createUserCommand.Profile = (byte)EnumRole.Interviewer;
            }
        }

        [When(@"I click on register button")]
        public async Task WhenIClickOnTheRegisterButton()
        {
            _response = await _client.PostAsJsonAsync("/interviewsystem/addUser", _createUserCommand);
        }

        [Then(@"the system should respond with a success message")]
        public async Task ThenTheSystemShouldRespondWithASuccessMessage()
        {
            _response.EnsureSuccessStatusCode();
            var result = await _response.Content.ReadAsStringAsync();
            var retour = JsonConvert.DeserializeObject<ObjetRetour>(result);
            retour.ShouldBeOfType<ObjetRetour>();
            retour.Etat.ShouldBeTrue();
            retour.Message.ShouldBe("Success");
        }
    }
}
