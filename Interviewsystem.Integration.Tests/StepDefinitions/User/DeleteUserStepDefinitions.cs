using Interviewsystem.Application.Responses;
using Interviewsystem.Application.User.Commands.DeleteUser;
using Newtonsoft.Json;
using Shouldly;
using System;
using TechTalk.SpecFlow;

namespace Interviewsystem.Integration.Tests.StepDefinitions.User
{
    [Binding]
    public class DeleteUserStepDefinitions : IClassFixture<TestingWebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        private DeleteUserCommand _deleteUserCommand;
        private HttpResponseMessage _response;

        public DeleteUserStepDefinitions(TestingWebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
            _deleteUserCommand = new();
            _response = new HttpResponseMessage();
        }
        [Given(@"I have seleceted the id (.*) of the user I want to delete")]
        public void GivenIHaveSelecetedTheIdOfTheUserIWantToDelete(int userId)
        {
            _deleteUserCommand.UserId = userId;
        }

        [When(@"I click the delete button")]
        public async Task WhenIClickOnTheDeleteButton()
        {
            _response = await _client.DeleteAsync($"/interviewsystem/deleteUser?id={_deleteUserCommand.UserId}");
        }

        [Then(@"I will get the message of successful deletion")]
        public async Task ThenIWillGetTheMessageOfSuccessfulDeletion()
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
