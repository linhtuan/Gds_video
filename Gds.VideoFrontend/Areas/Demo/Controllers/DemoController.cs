using System.Collections.Generic;
using System.Web.Http;
using Gds.VideoFrontend.Infrastructure;

namespace Gds.VideoFrontend.Areas.Demo.Controllers
{
    public class DemoController : ApiController
    {
        // GET: api/Demo
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Demo/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Demo
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Demo/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Demo/5
        public void Delete(int id)
        {
        }
    }
}
