using GoodBooks.Data;
using GoodBooks.Services;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

WebApplicationBuilder webApplicationBuilder = WebApplication.CreateBuilder(args);
webApplicationBuilder.Services.AddDbContext<GoodBooksDbContext>(options => options.UseSqlServer(webApplicationBuilder.Configuration.GetConnectionString("GoodBooksConnection")));
webApplicationBuilder.Services.AddScoped<IBooksService, BooksService>();
webApplicationBuilder.Services.AddControllers();
webApplicationBuilder.Services.AddOpenApi();

webApplicationBuilder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

WebApplication webApplication = webApplicationBuilder.Build();

GoodBooksDbContext goodBooksDbContext = webApplication.Services.CreateScope().ServiceProvider.GetRequiredService<GoodBooksDbContext>();
goodBooksDbContext.Database.Migrate();

webApplication.UseCors("AllowAll");
webApplication.MapOpenApi();
webApplication.MapScalarApiReference();
webApplication.MapControllers();
webApplication.Run();