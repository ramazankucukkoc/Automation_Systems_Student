using Newtonsoft.Json;
using Student_Follower.Entities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Student_Follower.Services
{
    public class UserApiService
    {
        private readonly HttpClient _httpClient;

        public UserApiService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:44395/api/Users/");
        }
        public async Task<List<UserList>> GetAll()
        {

            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync("GetAll");
            string responseContent = await httpResponseMessage.Content.ReadAsStringAsync();
            var datalist = JsonConvert.DeserializeObject<List<UserList>>(responseContent);
            return datalist;

        }
        public async Task<bool> Login(UserForLogin userForLogin)
        {
            string personelGiriş = JsonConvert.SerializeObject(userForLogin);
            StringContent stringContent = new StringContent(personelGiriş, Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsync("Login", stringContent);
            httpResponseMessage.Content = stringContent;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
        public async Task<bool> ForgotPassword(ForgotPassword forgotPassword)
        {
            string sifreUnuttum = JsonConvert.SerializeObject(forgotPassword);
            StringContent stringContent = new StringContent(sifreUnuttum, Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsync("ForgotPassword", stringContent);
            httpResponseMessage.Content = stringContent;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
        public async Task<bool> Add(CreateUser createUser)
        {
            string studentData = JsonConvert.SerializeObject(createUser);

            StringContent stringContent = new StringContent(studentData, Encoding.UTF8, "application/json");

            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsync("Register", stringContent);
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
