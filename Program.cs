using MassTransit.AspNetCoreIntegration;
using MassTransit;
using KSR_Docker.Models.Consumers;
using KSR_Docker.Models.QueryClasses;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddMassTransit( x =>
{    
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(new Uri("rabbitmq://cow.rmq2.cloudamqp.com/uklfscur"), h =>
        {
            h.Username("uklfscur");
            h.Password("l-2PHIXrRbG2lreh61yvypU6sx4dPGoi");
        });
    });

    x.AddConsumer<RoomsConsumer>();
    x.AddRequestClient<RoomsQuery>();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.Use(async (context, next) =>
{
    await next();
    if (context.Response.StatusCode == 404)
    {
        context.Request.Path = "/Error/NotFound";
        await next();
    }
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
