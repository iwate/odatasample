using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;

namespace ODataSample.V7.Controllers
{
    public class SampleController : ODataController
    {
        private static readonly IEnumerable<Datum> Data = new[]
        {
            new Datum { Key1 = 1, Key2 = "A", Value = "1A" },
            new Datum { Key1 = 1, Key2 = "B", Value = "1B" },
            new Datum { Key1 = 2, Key2 = "A", Value = "2A" },
            new Datum { Key1 = 2, Key2 = "B", Value = "2B" },
        };

        [EnableQuery]
        [ODataRoute("/Data")]
        public IActionResult Get()
        {
            return Ok(Data);
        }

        [ODataRoute("/Data(Key1={Key1},Key2={Key2})")]
        public IActionResult GetOne(long Key1, string Key2)
        {
            var entity = Data.FirstOrDefault(d => d.Key1 == Key1 && d.Key2 == Key2);

            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }
    }

    public class Datum
    {
        public long Key1 { get; set; }

        public string Key2 { get; init; }

        public string Value { get; set; }
    }
}
