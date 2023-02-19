using AppService.Core.Interfaces.Infrastructure;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using ZstdSharp.Unsafe;

namespace AppService.Infrastructure.SMS.SMSCountry
{
    public class SMSService :ISMSService
    {
        private readonly SMSCountryOptions _options;
        private readonly string _sendSMSUrlPath="{0}{1}/SMSes/";
        public SMSService(IOptions<SMSCountryOptions> options)
        {
            ArgumentNullException.ThrowIfNull(options, nameof(options));
            _options = options.Value;
           
        }

        public async Task<string> SendSMS(string from, string to, string message)
        {
            var authString = $"{_options.AuthKey}:{_options.AuthToken}";
            var base64EncodedAuthString = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(authString));

            var messageBody = new
            {
                Number = to,
                Text = "User Admin login OTP is** - SMSCOU",
                SenderId = "SMSCOU",
                Tool="API"
            };
            
            using(var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization 
                    = new AuthenticationHeaderValue("Basic", base64EncodedAuthString);
                using (var requestMessage = new HttpRequestMessage())
                {
                    try
                    {
                    requestMessage.RequestUri = new Uri(String.Format(_sendSMSUrlPath,_options.Url,_options.AuthKey));
                    requestMessage.Method = HttpMethod.Post;
                    requestMessage.Content = JsonContent.Create(messageBody, mediaType: MediaTypeHeaderValue.Parse("application/json"));

                       // content.Headers.ContentType.MediaType="application/json";
                   // requestMessage.Headers.Add("Context-Type",)
                    //requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Basic", base64EncodedAuthString);

                     HttpResponseMessage res;
                    
                        res = await client.SendAsync(requestMessage);
                        if (res.IsSuccessStatusCode)
                        {
                            return res.Content.ReadAsStringAsync().Result;
                        }
                        return null;
                    }
                    catch(Exception ex)
                    {
                        throw new Exception("Something went wronf", ex);
                    }
                   

                }
               

            }
            throw new NotImplementedException();
        }


    }
}
