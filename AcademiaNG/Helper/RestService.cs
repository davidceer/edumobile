using AcademiaNG.Helper;
using AcademiaNG.Interfaces;
using AcademiaNG.Models;
using MimeKit;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

[assembly: Dependency(typeof(HttpClientHandlerService))]
namespace AcademiaNG.Helper
{
    public class RestService
    {
        public RestService()
        {
            HttpClient _client = new HttpClient();

            if (Device.RuntimePlatform == Device.UWP)
            {
                _client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
                _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            }
        }

        public static async Task GetAllNewsAsync(Action<IEnumerable<object>> action, string adaptiveUri = @"https://api.academiang.info")
        {

            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync(adaptiveUri);

            Debug.WriteLine(response.Content.ToString());

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var list = JsonConvert.DeserializeObject<IEnumerable<object>>(await response.Content.ReadAsStringAsync());
                action(list);
            }
        }

        public async Task<HttpResponseMessage> SendPostAsync(string adaptiveUri, List<KeyValuePair<string, string>> modelObj)
        {
            HttpResponseMessage postRequest;
            HttpClient client = new HttpClient();
            Uri uri = new Uri(adaptiveUri);
            var content = new FormUrlEncodedContent(modelObj);
            using (postRequest = await client.PostAsync(uri, content))
            {
                return postRequest;
            }
        }

        public static async Task PostAndGetUsingAPIAsync(Action<IEnumerable<object>> action, List<KeyValuePair<string, string>> modelObj, string adaptiveUri = @"https://api.academiang.info")
        {
            using (HttpClient client = new HttpClient())
            {
                string jsonResponse = "";
                HttpResponseMessage postRequest;
                Uri uri = new Uri(adaptiveUri);

                FormUrlEncodedContent content = new FormUrlEncodedContent(modelObj);
                using (postRequest = await client.PostAsync(uri, content))
                {
                    if (postRequest.IsSuccessStatusCode)
                    {
                        jsonResponse = await postRequest.Content.ReadAsStringAsync();
                        if (!string.IsNullOrEmpty(jsonResponse))
                        {
                            List<LoginDetails> source = JsonConvert.DeserializeObject<List<LoginDetails>>(jsonResponse);
                            action(source);
                        }
                    }
                }
            }
        }

        public async Task<string> PostAndGetUsingAPIAsync(List<KeyValuePair<string, string>> modelObj, string adaptiveUri = @"https://api.academiang.info")
        {
            using (HttpClient client = new HttpClient())
            {
                string jsonString = "";
                HttpResponseMessage postRequest;
                Uri uri = new Uri(adaptiveUri);

                FormUrlEncodedContent content = new FormUrlEncodedContent(modelObj);
                using (postRequest = await client.PostAsync(uri, content))
                {
                    if (postRequest.IsSuccessStatusCode)
                    {
                        jsonString = await postRequest.Content.ReadAsStringAsync();
                    }
                    modelObj = null;
                }
                return jsonString;
            }
        }

        public async Task<List<Organization>> GetAnythingAsync(string uri)
        {
            HttpClient _client = new HttpClient();
            List<Organization> repositories = null;
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    repositories = JsonConvert.DeserializeObject<List<Organization>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }

            return repositories;
        }

        public async Task<List<User>> GetUserAsync(string uri)
        {
            HttpClient _client = new HttpClient();
            List<User> repositories = null;
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    repositories = JsonConvert.DeserializeObject<List<User>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }

            return repositories;
        }

        //START
        public async Task<TResult> GetAsync<TResult>(string uri, string token = "")
        {
            HttpClient httpClient = CreateHttpClient(token);
            HttpResponseMessage response = await httpClient.GetAsync(uri);

            //await HandleResponse(response);
            string serialized = await response.Content.ReadAsStringAsync();

            TResult result = await Task.Run(() =>
            JsonConvert.DeserializeObject<TResult>(serialized)); //

            return result;
        }

        private HttpClient CreateHttpClient(string token = "")
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            if (!string.IsNullOrEmpty(token))
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            return httpClient;
        }
        //STOP

        // This method must be in a class in a platform project, even if
        // the HttpClient object is constructed in a shared project.
        public HttpClientHandler GetInsecureHandler()
        {
            HttpClientHandler handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
                {
                    if (cert.Issuer.Equals("CN=localhost"))
                        return true;
                    return errors == System.Net.Security.SslPolicyErrors.None;
                }
            };
            return handler;
        }
    }

    public class HttpClientHandlerService : IHttpClientHandlerService
    {
        public HttpClientHandler GetInsecureHandler()
        {
            HttpClientHandler handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
                {
                    if (cert.Issuer.Equals("CN=localhost"))
                        return true;
                    return errors == System.Net.Security.SslPolicyErrors.None;
                }
            };
            return handler;
        }
    }

    public class EmailTest
    {
        public async Task SendEmail(string subject, string body, List<string> recipient)
        {
            try
            {
                EmailMessage message = new EmailMessage
                {
                    Subject = subject,
                    Body = body,
                    To = recipient
                };
                await Email.ComposeAsync(message);
            }
            catch (FeatureNotSupportedException fbsEx)
            {
                // Email is not supported on this device
                System.Diagnostics.Debug.WriteLine(fbsEx);
            }
            catch (Exception ex)
            {
                // Some other exception occurred
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }

        public void SendEmailSMTP(string Subject, string MessageBody, string SenderEmail, string Recipient)
        {
            try
            {
                MailMessage newMail = new MailMessage();
                // use the Gmail SMTP Host
                SmtpClient client = new SmtpClient("smtp.gmail.com");
                //Follow the RFS 5321 Email Standard
                newMail.From = new MailAddress(SenderEmail, "AcademiaNG");
                newMail.To.Add("<<" + Recipient + ">>");
                //declare the email subject
                newMail.Subject = Subject;
                //use HTML for the email body
                newMail.IsBodyHtml = true;
                newMail.Body = MessageBody;
                // enable SSL for encryption across channels
                client.EnableSsl = true;
                // Port 465 for SSL communication
                client.Port = 465;
                // Provide authentication information with Gmail SMTP server to authenticate your sender account
                client.Credentials = new System.Net.NetworkCredential("<<" + SenderEmail + ">>", "<<systemical0304>>");

                client.Send(newMail); // Send the constructed mail
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error -" + ex);
            }
        }
    }
}
