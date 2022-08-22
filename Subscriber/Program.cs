using Amazon.Runtime;
using Amazon.SQS;
using Models;
using Subscriber;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IAmazonSQS>(_
    => new AmazonSQSClient(
        new BasicAWSCredentials(builder.Configuration["AWS:SQS:AccessKey"], builder.Configuration["AWS:SQS:SecretKey"]),
        Amazon.RegionEndpoint.EUWest1)
    );

builder.Services.AddScoped<IHandlerBase<User>, UserHandler>();
builder.Services.AddScoped<IHandlerBase<CabinFilters>, CabinGetAllHandler>();
builder.Services.AddScoped<IHandlerBase<Cabin>, CabinPostHandler>();

builder.Services.AddSingleton<HandlerFactory>();

builder.Services.AddHostedService<SubscriberBase>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
