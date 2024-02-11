namespace PatientInformationPage.Models
{
    public class WebApi
    {
            public HttpClient Initial()
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:7200");
                return client;
            }
        }
}

