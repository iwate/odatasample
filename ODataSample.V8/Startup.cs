using Microsoft.AspNetCore.OData;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using ODataSample.V8.Controllers;

namespace ODataSample.V8
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddOData(options =>
            {
                options.AddRouteComponents(edm());
            });
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
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
