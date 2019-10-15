using DirectLineGroupTests.Utils;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DirectLineGroupTests.Support.API
{
    public class FindMyVehicleAPI
    {

        private string _endPoint = null;

        public void SetEndPoint()
        {
            Logger.Info("Setting Endpoint of API");
            _endPoint =Settings.ProjectSettings.Default.APIEndPointURL;
        }

        public Dictionary<String, String> IsVehicleExists(String registrationNumber)
        {
            try
            {

                string url = _endPoint + registrationNumber;

                var rss = getResponse(url);
                Dictionary<String,String> Codes= new Dictionary<String, String>();
                Codes.Add("StatusCode", GetResponseStatusCode(rss).ToString());

                var json = GetResponseJson(rss);

                try
                {
                    String count = json["Count"].ToString();
                    Codes.Add("ResponseCode","200");
                }
                catch(Exception e)
                {
                    Codes.Add("ResponseCode", json["status"].ToString());
                }
                // Codes.Add("ResponseCode",)

                return Codes;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public HttpWebResponse getResponse(string requestURL)
        {
            try
            {
                //Creating WebRequest with URL (endPoint plus API path)
                Logger.Info("Creating WebRequest with URL (endPoint plus API path)");
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestURL);
                //Type of Request
                Logger.Info("Setting Request Method, ContentType and APIKey");
                request.Method = "Get";
                //Content Type
                request.ContentType = "application/json";
                // adding API key
                request.Headers.Add("x-api-key", "C989hVcuT06PUfg49Hpt588U3qhZdNOs82HhaLB2");
                //Generating Response
                return (HttpWebResponse) request.GetResponse();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int GetResponseStatusCode(HttpWebResponse response)
        {
            Logger.Info("Getting Status Code");
            return (int)response.StatusCode;
        }

        public JObject GetResponseJson(HttpWebResponse response)
        {
            Logger.Info("Getting Json Response");
            //Creating JSON Object
            JObject jsonResponse = new JObject();
             Stream webStream = response.GetResponseStream();
            //Reading Response 
            StreamReader responseReader = new StreamReader(webStream);
            //Convert response from String to Json
            jsonResponse = JObject.Parse(responseReader.ReadToEnd());
            responseReader.Close();
            return jsonResponse;

        }
    }
}
