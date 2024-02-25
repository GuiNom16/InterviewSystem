using Interviewsystem.Application.User.Commands.UpdateUser;
using Shouldly;
using Interviewsystem.Application.Responses;
using Newtonsoft.Json;
using System.Text;
using TechTalk.SpecFlow.Assist;
using Interviewsystem.Application.User.Commands.CreateUser;

namespace Interviewsystem.Integration.Tests.StepDefinitions.User
{
    [Binding]
    public class UpdatingUserStepDefinitions : IClassFixture<TestingWebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        private UpdateUserCommand _updateUserCommand;
        private HttpResponseMessage _response;

        public UpdatingUserStepDefinitions(TestingWebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
            _updateUserCommand = new();
            _response = new HttpResponseMessage();
        }

        [Given(@"I have changed the user's role")]
        public void GivenIHaveChangedTheUsersRole(Table table)
        {
            var data = table?.CreateSet<UpdateUserCommand>().FirstOrDefault();
            if(data != null)
            {
                _updateUserCommand.UserId = data.UserId;
                _updateUserCommand.Profile = data.Profile;
            }
        }


        [When(@"I click on save button")]
        public async Task WhenIClickOnSaveButton()
        {
            var data = new
            {
                _updateUserCommand.UserId,
                _updateUserCommand.Profile
            };
            string jsonData = System.Text.Json.JsonSerializer.Serialize(data);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            _response = await _client.PatchAsync("/interviewsystem/updateUser", content);
        }

        [Then(@"I will get a success message")]
        public async Task ThenIWillGetASuccessMessage()
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
