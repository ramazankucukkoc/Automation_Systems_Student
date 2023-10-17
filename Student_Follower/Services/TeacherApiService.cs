using Newtonsoft.Json;
using Student_Follower.Entities;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Student_Follower.Services
{
    public class TeacherApiService
    {
        private readonly HttpClient _httpClient;

        public TeacherApiService()

        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:44395/api/Teachers/");
        }
        public async Task<ResponseStatusCode> GetResponse(string endpoint)
        {

            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync(endpoint);
            int statusCode = (int)httpResponseMessage.StatusCode;
            string responseContent = await httpResponseMessage.Content.ReadAsStringAsync();
            return new ResponseStatusCode() { StatusCode = statusCode, Content = responseContent };

        }
        public async Task<ResponseStatusCode> Response<T>(T entity, string endpoint)
        {
            string studentData = JsonConvert.SerializeObject(entity);
            StringContent stringContent = new StringContent(studentData, Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsync(endpoint, stringContent);
            int statusCode = (int)httpResponseMessage.StatusCode;
            string responseContent = await httpResponseMessage.Content.ReadAsStringAsync();
            return new ResponseStatusCode() { StatusCode = statusCode, Content = responseContent };

        }
    }
}
