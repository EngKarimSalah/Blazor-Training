using BlazorApp3.Components;
using BlazorApp3.Data.Repositories;
using BlazorApp3.Services;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;

namespace BlazorApp3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDbContext<ApplicationDbContext>(

                options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))

                );

            builder.Services.AddScoped<IProductRepository, ProductRepository>();    
            builder.Services.AddScoped<IProductService, ProductService>();  

            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            builder.Services.AddMudServices();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();            

            app.Run();
        }
    }
}
