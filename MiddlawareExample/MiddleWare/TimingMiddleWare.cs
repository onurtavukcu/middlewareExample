using static System.Net.Mime.MediaTypeNames;

namespace MiddlawareExample.MiddleWare
{
    public class TimingMiddleWare
    {
        private readonly ILogger<TimingMiddleWare> _logger;
        private readonly RequestDelegate _next;

        public TimingMiddleWare(ILogger<TimingMiddleWare> logger, RequestDelegate next)
        {
            _logger = logger;
            _next = next;
        }

        public async Task Invoke(HttpContext ctx) // sadece bunu eklersek ve program.cs'ten app.UseMiddleware<TimingMiddleWare>() şekinde çağırabiliriz.
        {
            var start = DateTime.UtcNow;
            Console.WriteLine("Test");
            var userInstance = new User(1, "onur");
            Console.WriteLine(userInstance.Id);
            Console.WriteLine(userInstance.Name);
            await _next.Invoke(ctx); //pass the context
            _logger.LogInformation($"Timing:{(DateTime.UtcNow - start).TotalMilliseconds}");
        }
    }


    public static class TimingExtension
    {
        public static IApplicationBuilder UseTiming(this IApplicationBuilder app)  //bunu ekleyerek program.cs'ten app.UseTiming olarak çağırılabilmesini sağladık.
        {
            return app.UseMiddleware<TimingMiddleWare>();
        }
    }
}
