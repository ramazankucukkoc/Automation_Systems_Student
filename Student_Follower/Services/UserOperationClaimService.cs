using Newtonsoft.Json;
using Student_Follower.Entities;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Student_Follower.Services
{
    public class UserOperationClaimService
    {
        private readonly HttpClient _httpClient;

        public UserOperationClaimService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:44395/api/UserOperationClaims/");
        }
        public async Task<bool> Add(CreateUserOperationClaim createUserOperationClaim)
        {
            string studentData = JsonConvert.SerializeObject(createUserOperationClaim);

            StringContent stringContent = new StringContent(studentData, Encoding.UTF8, "application/json");

            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsync("Add", stringContent);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
