using CleaningManagement.Api;
using CleaningManagement.Application.UseCases.CleanningPlan.DTOs;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Extensions.Ordering;

namespace CleanningManagement.Tests.Integration
{
    [TestCaseOrderer("PriorityOrderer", "CleanningManagement.Tests")]
    public class CleanningPlanControllerTests:IClassFixture<TestingWebAppFactory<Startup>>
    {
        private readonly HttpClient _client;
    
        private Guid createdCleanningPlanId;
        public CleanningPlanControllerTests(TestingWebAppFactory<Startup> factory)
        {
            //  Arrange
            _client = factory.CreateClient();
        }

        [Fact, TestPriority(1)]
        public async Task Read_GET_Method()
        {
            // Act
            var response = await _client.GetAsync("/api/cleanning-plans/getByCustomerId/1");

            //  Assert
             response.EnsureSuccessStatusCode();
            var responseString  = await response.Content.ReadAsStringAsync();

            Assert.Contains("183eef1f-e4eb-489d-bd3d-720443bce7c2", responseString);
        }

        [Fact, TestPriority(2)]
        public async Task Dependent_A_Create_POST_ValidMode()
        {
            //  Arrange
            var postRequestUrl = "/api/cleanning-plans";
            var modelForCreate = new CreateCleanningPlanDto
            {
                CustomerId = 2,
                Description = "Test post Method Description",
                Title = "Test post request title"
            };

            var json = JsonConvert.SerializeObject(modelForCreate);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
           
            // Act
            var response = await _client.PostAsync(postRequestUrl, stringContent);

            // Assert 
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var returnedModel = JsonConvert.DeserializeObject<CleanningPlanDto>(responseString);

            createdCleanningPlanId = returnedModel.Id;

            Assert.Equal(modelForCreate.Description, returnedModel.Description);
            Assert.Equal(modelForCreate.Title, returnedModel.Title);
            Assert.Equal(modelForCreate.CustomerId, returnedModel.CustomerId);

        }

     

        [Fact, TestPriority(3)]
        public async Task Dependent_B_Read_PUT()
        {
            //  Arrange
            var putRequestUrl = $"/api/cleanning-plans/183eef1f-e4eb-489d-bd3d-720443bce7c2";

            var modelForUPdate = new CreateCleanningPlanDto
            {
                CustomerId = 3,
                Description = "Test description update Method",
                Title = "Test title update Method "
            };

            var json = JsonConvert.SerializeObject(modelForUPdate);

            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            // Act
            var response = await _client.PutAsync(putRequestUrl,stringContent);

            var responseString = await response.Content.ReadAsStringAsync();

            var returnedModel = JsonConvert.DeserializeObject<CleanningPlanDto>(responseString);
            // Assert 
            response.EnsureSuccessStatusCode();
            Assert.Equal(modelForUPdate.Description, returnedModel.Description);
            Assert.Equal(modelForUPdate.Title, returnedModel.Title);
            Assert.Equal(modelForUPdate.CustomerId, returnedModel.CustomerId);
        }

        [Fact, TestPriority(4)]
        public async Task Dependent_C_Read_DELETE()
        {
            //  Arrange
            var deleteRequestUrl = $"/api/cleanning-plans/{createdCleanningPlanId}";

            // Act
            var response = await _client.DeleteAsync(deleteRequestUrl);

            // Assert 
            response.EnsureSuccessStatusCode();
        }
    }
}
