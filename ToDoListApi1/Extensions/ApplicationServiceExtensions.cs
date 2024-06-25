using ToDoListApi1.Data;
using ToDoListApi1.Services;

namespace ToDoListApi1.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddSingleton<ToDoRepository>();
            services.AddSingleton<ToDoService>();

            return services;
        }
    }
}
