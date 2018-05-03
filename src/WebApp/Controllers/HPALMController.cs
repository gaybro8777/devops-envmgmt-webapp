using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Xml;

namespace DevOpsEnvMgmt.Controllers
{
    [Route("api/[controller]")]
    public class HPALMController : Controller
    {
        const string _HPALMUrl = "http://10.17.2.99:8080";
        const string _HPALMApiUrl = _HPALMUrl + "/qcbin/api";
        const string _HPALMRestUrl = _HPALMUrl + "/qcbin/rest";
        const string _HeaderBasicAuthValue = "Basic cl9udW5lejo=";

        [HttpGet] // this api/HPALM
        public string Get()
        {
            return string.Format("Get: simple get");
        }

        // GET api/HPALM/ReleaseBundle/5
        [HttpGet]
        [Route("ReleaseBundle/{relid}")]
        public async Task<string> GetReleaseBundle(int relid)
        {

            #region Sample json
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
            #endregion

            using (var client = new HttpClient())
            {
                //try
                //{
                //var client = new HttpClient();
                var request = new HttpRequestMessage()
                {
                    RequestUri = new Uri(_HPALMApiUrl + "/authentication/sign-in"),
                    Method = HttpMethod.Get,
                };

                //HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, "http://10.17.2.99:8080");
                request.Headers.Add("Authorization", _HeaderBasicAuthValue);
                //request.Headers.Add("Accept", "application/json");
                HttpResponseMessage task = await client.SendAsync(request);
                string responseText = task.Content.ReadAsStringAsync().Result;
                //System.Console.WriteLine("THIS IS DEBUG -----------------------------------------------------------");
                //System.Console.WriteLine(responseText);

                HttpRequestMessage request2 = new HttpRequestMessage()
                {
                    RequestUri = new Uri(_HPALMRestUrl + "/domains/Motiva/projects/Agility/defects?fields=target-rel,user-15,id,user-33,user-17,user-04,severity,priority,user-05,user-12,user-29,user-21,user-47,project,user-39,status,description,name&query={target-rel[" + relid.ToString() + "]}"),
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

        // GET api/HPALM/ReleaseList/5
        [HttpGet]
        [Route("ReleaseList/{parentid}")]
        public async Task<string> GetReleaseList(int parentid)
        {
            using (var client = new HttpClient())
            {
                //try
                //{
                //var client = new HttpClient();
                var request = new HttpRequestMessage()
                {
                    RequestUri = new Uri(_HPALMApiUrl + "/authentication/sign-in"),
                    Method = HttpMethod.Get,
                };

                request.Headers.Add("Authorization", _HeaderBasicAuthValue);
                HttpResponseMessage task = await client.SendAsync(request);
                string responseText = task.Content.ReadAsStringAsync().Result;

                HttpRequestMessage request2 = new HttpRequestMessage()
                {
                    RequestUri = new Uri(_HPALMRestUrl + "/domains/Motiva/projects/Agility/releases?fields=id,name,parent-id&order-by={name}&query={parent-id[" + parentid.ToString() + "]}"),
                    Method = HttpMethod.Get,
                };
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));//ACCEPT header
                HttpResponseMessage task2 = await client.SendAsync(request2);
                string responseText2 = task2.Content.ReadAsStringAsync().Result;
                return responseText2;
            }
        }

        // GET api/HPALM/ReleaseList/5
        [HttpGet]
        [Route("PivotData1/{relid}")]
        public async Task<string> GetDefectsForPivot(int relid)
        {
            using (var client = new HttpClient())
            {
                //try
                //{
                //var client = new HttpClient();
                var request = new HttpRequestMessage()
                {
                    RequestUri = new Uri(_HPALMApiUrl + "/authentication/sign-in"),
                    Method = HttpMethod.Get,
                };

                request.Headers.Add("Authorization", _HeaderBasicAuthValue);
                HttpResponseMessage task = await client.SendAsync(request);
                string responseText = task.Content.ReadAsStringAsync().Result;

                HttpRequestMessage request2 = new HttpRequestMessage()
                {
                    RequestUri = new Uri(_HPALMRestUrl + "/domains/Motiva/projects/Agility/defects?fields=user-15,id,status,target-rel,user-15&query={target-rel[" + relid.ToString() + "]}"),
                    Method = HttpMethod.Get,
                };
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));//ACCEPT header
                HttpResponseMessage task2 = await client.SendAsync(request2);
                string responseText2 = task2.Content.ReadAsStringAsync().Result;
                return responseText2;
            }
        }
    }
}
