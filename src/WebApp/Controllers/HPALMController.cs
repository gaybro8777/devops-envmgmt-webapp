using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Xml;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DevOpsEnvMgmt.Controllers
{
    [Route("api/HPALM")]
    public class HPALMController : Controller
    {
        // GET: api/<controller>
        //[Route("api/HPALM/{relid}")]
        //[HttpGet("{relid}")]
        //public async Task<string> GetDefectsPerReleaseID(int relid)
        //{
        //    using (var client = new HttpClient())
        //    {
        //        //try
        //        //{
        //            //var client = new HttpClient();
        //            var request = new HttpRequestMessage()
        //            {
        //                RequestUri = new Uri("http://10.17.2.99:8080/qcbin/api/authentication/sign-in"),
        //                Method = HttpMethod.Get,
        //            };

        //            //HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, "http://10.17.2.99:8080");
        //            request.Headers.Add("Authorization", "Basic cl9udW5lejo=");
        //            //request.Headers.Add("Accept", "application/json");
        //            HttpResponseMessage task = await client.SendAsync(request);
        //            string responseText = task.Content.ReadAsStringAsync().Result;
        //            //System.Console.WriteLine("THIS IS DEBUG -----------------------------------------------------------");
        //            //System.Console.WriteLine(responseText);

        //            HttpRequestMessage request2 = new HttpRequestMessage()
        //            {
        //                RequestUri = new Uri("http://10.17.2.99:8080/qcbin/rest/domains/Motiva/projects/Agility/defects?fields=target-rel,user-15,id,user-33,user-17,user-04,severity,priority,user-05,user-12,user-29,user-21,user-47,project,user-39&query={target-rel[" + relid.ToString() + "]}"),
        //                Method = HttpMethod.Get,
        //            };
        //            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));//ACCEPT header
        //            HttpResponseMessage task2 = await client.SendAsync(request2);
        //            string responseText2 = task2.Content.ReadAsStringAsync().Result;
        //            //System.Console.WriteLine("THIS IS DEBUG ============================================================");
        //            //System.Console.WriteLine(responseText2);

        //            return responseText2;
        //        //}
        //        //catch (HttpRequestException httpRequestException)
        //        //{
        //        //    string exceptionMessage = "Error getting weather from OpenWeather: " + httpRequestException.Message;
        //        //    //return BadRequest();
        //        //}

        //        // return new string[] { "value1", "value2" };
        //    }
        //}

        // GET api/<controller>/5
        [HttpGet("{relid}")]
        public async Task<string> Get(int relid)
        {
            //          string someJson = @"{
            //  ""entities"": [
            //    {
            //      ""Fields"": [
            //        {
            //          ""Name"": ""severity"",
            //          ""values"": [
            //            {
            //              ""value"": ""2-High""
            //            }
            //          ]
            //        },
            //        {
            //          ""Name"": ""project"",
            //          ""values"": [
            //            {
            //              ""value"": ""IT OPERATIONS""
            //            }
            //          ]
            //        },
            //        {
            //          ""Name"": ""description"",
            //          ""values"": [
            //            {
            //              ""value"": ""Some Description""
            //            }
            //          ]
            //        },
            //        {
            //          ""Name"": ""priority"",
            //          ""values"": [
            //            {
            //              ""value"": ""P4""
            //            }
            //          ]
            //        },
            //        {
            //          ""Name"": ""user-17"",
            //          ""values"": [
            //            {
            //              ""value"": ""Annush Veeraragav""
            //            }
            //          ]
            //        },
            //        {
            //          ""Name"": ""user-39"",
            //          ""values"": [
            //            {
            //              ""value"": ""N""
            //            }
            //          ]
            //        },
            //        {
            //          ""Name"": ""target-rel"",
            //          ""values"": [
            //            {
            //              ""value"": ""1078"",
            //              ""ReferenceValue"": ""0518 Rel""
            //            }
            //          ]
            //        },
            //        {
            //          ""Name"": ""user-29"",
            //          ""values"": [
            //            {}
            //          ]
            //        },
            //        {
            //          ""Name"": ""user-33"",
            //          ""values"": [
            //            {}
            //          ]
            //        },
            //        {
            //          ""Name"": ""user-12"",
            //          ""values"": []
            //        },
            //        {
            //          ""Name"": ""id"",
            //          ""values"": [
            //            {
            //              ""value"": ""6261""
            //            }
            //          ]
            //        },
            //        {
            //          ""Name"": ""user-21"",
            //          ""values"": [
            //            {}
            //          ]
            //        },
            //        {
            //          ""Name"": ""user-15"",
            //          ""values"": [
            //            {
            //              ""value"": ""MIDDLEWARE""
            //            }
            //          ]
            //        },
            //        {
            //          ""Name"": ""user-04"",
            //          ""values"": [
            //            {
            //              ""value"": ""STL""
            //            }
            //          ]
            //        },
            //        {
            //          ""Name"": ""user-05"",
            //          ""values"": [
            //            {
            //              ""value"": ""Application""
            //            }
            //          ]
            //        },
            //        {
            //          ""Name"": ""status"",
            //          ""values"": [
            //            {
            //              ""value"": ""Assigned""
            //            }
            //          ]
            //        },
            //        {
            //          ""Name"": ""user-47"",
            //          ""values"": [
            //            {
            //              ""value"": ""a_veeraragav""
            //            }
            //          ]
            //        }
            //      ],
            //      ""Type"": ""defect"",
            //      ""children-count"": 0
            //    },
            //    {
            //      ""Fields"": [
            //        {
            //          ""Name"": ""severity"",
            //          ""values"": [
            //            {
            //              ""value"": ""2-High""
            //            }
            //          ]
            //        },
            //        {
            //          ""Name"": ""project"",
            //          ""values"": [
            //            {
            //              ""value"": ""IT OPERATIONS""
            //            }
            //          ]
            //        },
            //        {
            //          ""Name"": ""description"",
            //          ""values"": [
            //            {
            //              ""value"": ""Some other description.""
            //            }
            //          ]
            //        },
            //        {
            //          ""Name"": ""priority"",
            //          ""values"": [
            //            {
            //              ""value"": ""P2""
            //            }
            //          ]
            //        },
            //        {
            //          ""Name"": ""user-17"",
            //          ""values"": [
            //            {
            //              ""value"": ""Ken Bourgeois""
            //            }
            //          ]
            //        },
            //        {
            //          ""Name"": ""user-39"",
            //          ""values"": [
            //            {
            //              ""value"": ""N""
            //            }
            //          ]
            //        },
            //        {
            //          ""Name"": ""target-rel"",
            //          ""values"": [
            //            {
            //              ""value"": ""1078"",
            //              ""ReferenceValue"": ""0518 Rel""
            //            }
            //          ]
            //        },
            //        {
            //          ""Name"": ""user-29"",
            //          ""values"": [
            //            {}
            //          ]
            //        },
            //        {
            //          ""Name"": ""user-33"",
            //          ""values"": [
            //            {
            //              ""value"": ""IN11026232""
            //            }
            //          ]
            //        },
            //        {
            //          ""Name"": ""user-12"",
            //          ""values"": [
            //            {
            //              ""value"": ""2018-03-16""
            //            }
            //          ]
            //        },
            //        {
            //          ""Name"": ""id"",
            //          ""values"": [
            //            {
            //              ""value"": ""7599""
            //            }
            //          ]
            //        },
            //        {
            //          ""Name"": ""user-21"",
            //          ""values"": [
            //            {
            //              ""value"": ""Kevin Moreau""
            //            }
            //          ]
            //        },
            //        {
            //          ""Name"": ""user-15"",
            //          ""values"": [
            //            {
            //              ""value"": ""RIGHTANGLE""
            //            }
            //          ]
            //        },
            //        {
            //          ""Name"": ""user-04"",
            //          ""values"": [
            //            {
            //              ""value"": ""FSM""
            //            }
            //          ]
            //        },
            //        {
            //          ""Name"": ""user-05"",
            //          ""values"": [
            //            {
            //              ""value"": ""Code""
            //            }
            //          ]
            //        },
            //        {
            //          ""Name"": ""status"",
            //          ""values"": [
            //            {
            //              ""value"": ""RA Tulsa Support""
            //            }
            //          ]
            //        },
            //        {
            //          ""Name"": ""user-47"",
            //          ""values"": [
            //            {}
            //          ]
            //        }
            //      ],
            //      ""Type"": ""defect"",
            //      ""children-count"": 0
            //    }
            //  ],
            //    ""TotalResults"": 2
            //}";

            //          return someJson;

            using (var client = new HttpClient())
            {
                //try
                //{
                //var client = new HttpClient();
                var request = new HttpRequestMessage()
                {
                    RequestUri = new Uri("http://10.17.2.99:8080/qcbin/api/authentication/sign-in"),
                    Method = HttpMethod.Get,
                };

                //HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, "http://10.17.2.99:8080");
                request.Headers.Add("Authorization", "Basic cl9udW5lejo=");
                //request.Headers.Add("Accept", "application/json");
                HttpResponseMessage task = await client.SendAsync(request);
                string responseText = task.Content.ReadAsStringAsync().Result;
                //System.Console.WriteLine("THIS IS DEBUG -----------------------------------------------------------");
                //System.Console.WriteLine(responseText);

                HttpRequestMessage request2 = new HttpRequestMessage()
                {
                    RequestUri = new Uri("http://10.17.2.99:8080/qcbin/rest/domains/Motiva/projects/Agility/defects?fields=target-rel,user-15,id,user-33,user-17,user-04,severity,priority,user-05,user-12,user-29,user-21,user-47,project,user-39,status,description,name&query={target-rel[" + relid.ToString() + "]}"),
                    Method = HttpMethod.Get,
                };
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));//ACCEPT header
                HttpResponseMessage task2 = await client.SendAsync(request2);
                string responseText2 = task2.Content.ReadAsStringAsync().Result;
                //System.Console.WriteLine("THIS IS DEBUG ============================================================");
                //System.Console.WriteLine(responseText2);

                return responseText2;
                //}
                //catch (HttpRequestException httpRequestException)
                //{
                //    string exceptionMessage = "Error getting weather from OpenWeather: " + httpRequestException.Message;
                //    //return BadRequest();
                //}

                // return new string[] { "value1", "value2" };
            }
        }
    }
}
