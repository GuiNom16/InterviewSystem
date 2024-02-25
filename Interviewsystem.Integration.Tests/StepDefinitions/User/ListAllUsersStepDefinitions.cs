using Interviewsystem.Application.Responses;
using Interviewsystem.Application.User.Queries.GetUsersList;
using Interviewsystem.Domain.Models;
using Interviewsystem.Persistence;
using Interviewsystem.Persistence.Entities;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Shouldly;
using System;
using System.Net.Http.Json;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Interviewsystem.Integration.Tests.StepDefinitions.User
{
    [Binding]
    public class ListAllUsersStepDefinitions
    {
        private readonly TestingWebApplicationFactory<Program> _factory;
        private readonly HttpClient _client;
       // private GetUsersListQuery _getUsersListQuery;
        private HttpResponseMessage _response;

        public ListAllUsersStepDefinitions(TestingWebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _client = _factory.CreateClient();
            //_getUsersListQuery = new();
            _response = new HttpResponseMessage();            
        }

        [Given(@"I have these users in my Database")]
        public async Task GivenIHaveTheseUsersInMyDatabase(Table table)
        {
            var data = table.CreateSet<UserEntity>();

            using var scope = _factory.Services.CreateScope();
            var services = scope.ServiceProvider;
            var dbContext = services.GetRequiredService<InterviewsystemContext>();

            await dbContext.Users.AddRangeAsync(data);
            await dbContext.SaveChangesAsync();
        }

        [When(@"I access the role page, a call back to endpoint is made")]
        public async Task WhenIAccessTheRolePageACallBackToEndpointIsMade()
        {
            _response = await _client.GetAsync("/interviewsystem/getUsersList");
        }

        [Then(@"response should be true and I need to have the following info:")]
        public async void ThenResponseShouldBeTrueAndINeedToHaveTheFollowingInfo(Table table)
        {
            _response.EnsureSuccessStatusCode();
            //var result = await _response.content.readfromjsonasync<objetretour>();
            //result.shouldbeoftype<objetretour>();
            //result.etat.shouldbetrue();
            //result.message.shouldbe("success");
            //result.contenu.shouldbeoftype<list<usermodel>>();
            //var data = assert.isassignablefrom<usermodel[]>(result.contenu);
            //var n = result.contenu as ireadonlylist<usermodel>;

            //var expectedresult = table.createset<usermodel>();
            var result = await _response.Content.ReadAsStringAsync();
            var retour = JsonConvert.DeserializeObject<ObjetRetour>(result);
            retour?.Contenu.ShouldBeOfType<List<UserModel>>();
        }
    }
}
