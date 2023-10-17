using Newtonsoft.Json;
using Student_Follower.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Student_Follower.Services
{
    public static class GenericApiService
    {
        public static List<T> SuccessListService<T>(ResponseStatusCode responseStatusCode)
        {
            List<T> datalist = JsonConvert.DeserializeObject<List<T>>(responseStatusCode.Content);
            return datalist;
        }
        public static void ErrorService(ResponseStatusCode responseStatusCode)
        {
            List<string> errorMessageBox = null;
            if (responseStatusCode.StatusCode == 400 || responseStatusCode.StatusCode == 500 || responseStatusCode.StatusCode == 404)
            {
                errorMessageBox = new List<string>();
                ValidationErrorResponse response = JsonConvert.DeserializeObject<ValidationErrorResponse>(responseStatusCode.Content);
                if (response.Errors == null)
                {
                    BusinessErrorResponse businessErrorResponse = JsonConvert.DeserializeObject<BusinessErrorResponse>(responseStatusCode.Content);
                    MessageBox.Show($"{businessErrorResponse.Detail}", $"{businessErrorResponse.Title}", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    foreach (var error in response.Errors)
                    {
                        foreach (var errorDetail in error.Errors)
                        {
                            errorMessageBox.Add(errorDetail);
                        }
                    }
                    MessageBox.Show($"{errorMessageBox.FirstOrDefault()}", $"{response.Title}", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

    }
}
