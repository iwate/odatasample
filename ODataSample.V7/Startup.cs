using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.OData.Edm;
using ODataSample.V7.Controllers;

namespace ODataSample.V7
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOData();
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapODataRoute("default", null, edm());
                endpoints.MapControllers();
            });

        }
        IEdmModel edm()
        {
            var builder = new ODataConventionModelBuilder();
            var type = builder.AddEntityType(typeof(Datum));
            type.HasKey(typeof(Datum).GetProperty(nameof(Datum.Key1)));
            type.HasKey(typeof(Datum).GetProperty(nameof(Datum.Key2)));
            builder.AddEntitySet("Data", type);
            return builder.GetEdmModel();
        }
    }
}
