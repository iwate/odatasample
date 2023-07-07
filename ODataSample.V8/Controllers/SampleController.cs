using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace ODataSample.V8.Controllers
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
        [Route("/Data")]
        public IActionResult Get()
        {
            return Ok(Data);
        }

        [Route("/Data({Key1},{Key2})")]
        public IActionResult GetOne1(long Key1, string Key2)
        {
            var entity = Data.FirstOrDefault(d => d.Key1 == Key1 && d.Key2 == Key2);

            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }

        [Route("/Data(Key1={Key1},Key2={Key2})")]
        public IActionResult GetOne2(long Key1, string Key2) => GetOne1(Key1, Key2);


        [Route("/Data(Key2={Key2},Key1={Key1})")]
        public IActionResult GetOne3(long Key1, string Key2) => GetOne1(Key1, Key2);
    }

    public class Datum
    {
        public long Key1 { get; set; }

        public string Key2 { get; init; }

        public string Value { get; set; }
    }
}
