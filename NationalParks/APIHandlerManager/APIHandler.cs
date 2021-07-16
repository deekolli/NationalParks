using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using NationalParks.Models;

namespace NationalParks.APIHandlerManager
{
  public class APIHandler
  {
    // Obtaining the API key is easy. The same key should be usable across the entire
    // data.gov developer network, i.e. all data sources on data.gov.
    // 

    static string BASE_URL = "https://api.data.gov/ed/collegescorecard/v1/schools?per_page=4";
    static string API_KEY = "xeOUK1hsD4oethe5kTM45q37JI8YxaUzfx88B3DN"; //Add your API key here inside ""

    HttpClient httpClient;

    /// <summary>
    ///  Constructor to initialize the connection to the data source
    /// </summary>
    public APIHandler()
    {
      httpClient = new HttpClient();
      httpClient.DefaultRequestHeaders.Accept.Clear();
      httpClient.DefaultRequestHeaders.Add("X-Api-Key", API_KEY);
      httpClient.DefaultRequestHeaders.Accept.Add(
          new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
    }

        /// <summary>
        /// Method to receive data from API end point as a collection of objects
        /// 
        /// JsonConvert parses the JSON string into classes
        /// </summary>
        /// <returns></returns>
        public string replaceString(string responseString)
        {
            string responseStringModified = responseString;
            responseStringModified = responseStringModified.Replace("school.name", "schoolname");
            responseStringModified = responseStringModified.Replace("school.city", "schoolcity");
            responseStringModified = responseStringModified.Replace("school.state", "schoolstate");


            return responseStringModified;
        }
        public Parks GetParks()
    {
      string NATIONAL_PARK_API_PATH = BASE_URL + "&_fields=school.name,school.city,school.state,id";
      string parksData = "";

      Parks parks = null;

      httpClient.BaseAddress = new Uri(NATIONAL_PARK_API_PATH);

      // It can take a few requests to get back a prompt response, if the API has not received
      //  calls in the recent past and the server has put the service on hibernation
      try
      {
        HttpResponseMessage response = httpClient.GetAsync(NATIONAL_PARK_API_PATH).GetAwaiter().GetResult();
        if (response.IsSuccessStatusCode)
        {
          parksData = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    parksData = replaceString(parksData);
                }

        if (!parksData.Equals(""))
        {
          // JsonConvert is part of the NewtonSoft.Json Nuget package
          parks = JsonConvert.DeserializeObject<Parks>(parksData);
        }
      }
      catch (Exception e)
      {
        // This is a useful place to insert a breakpoint and observe the error message
        Console.WriteLine(e.Message);
      }

      return parks;
    }
  }
}