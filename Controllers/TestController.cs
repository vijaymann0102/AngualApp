
using Newtonsoft.Json;
using System;


using System.Net.Http;
using System.Web.Http;
using System.Collections.Generic;

namespace AngularApp.Controllers
{
    [RoutePrefix("api/Test")]
    public class TestController : ApiController
    {
        [HttpPost]
        [Route("GetFilteredJson")]
        public HttpResponseMessage GetFilteredJson(HttpRequestMessage data,[FromBody]DTOs.RequestDTO formdata)
        {
            var js = new JsonSerializerSettings();
            try
            {
                dynamic dataRecived = JsonConvert.DeserializeObject< dynamic > (formdata.data)["payload"];
                var result = new DTOs.ResultDTO();
                foreach (var item in dataRecived)
                {
                    if (item["episodeCount"] != null && item["drm"] != null)
                    {
                        if (item["episodeCount"].Value > 0 && item["drm"].Value == true)
                        {
                            var childresult = new DTOs.response();
                            childresult.image = (item["image"]!=null?item["image"]["showImage"].Value: null);
                            childresult.slug = item["slug"].Value;
                            childresult.title = item["title"].Value;
                            result.response.Add(childresult);
                        }
                    }
                }

                HttpResponseMessage response = Request.CreateResponse(System.Net.HttpStatusCode.OK, result);
                return response;
            }
            catch (Exception e)
            {
                var errorDTo = new DTOs.ErrorDTO();
                errorDTo.error = "Could not decode request: JSON parsing failed";
                HttpResponseMessage response = Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, errorDTo);
                return response;
            }
        }

       
    }
}