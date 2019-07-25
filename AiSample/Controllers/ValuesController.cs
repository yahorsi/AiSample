using Microsoft.ApplicationInsights;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AiSample.Controllers
{
    public class ValuesController : ApiController
    {
        private TelemetryClient _telemetryClient;

        public ValuesController()
        {
            _telemetryClient = new TelemetryClient();
        }

        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            try
            {
                throw new Exception("Test Exception");
            }
            catch(Exception e)
            {
                var properties = new Dictionary<string, string>
                {
                    { "requestParameters", "some data"},
                };

                _telemetryClient.TrackException(e, properties);

                return "exception logged";
            }
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
