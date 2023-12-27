using Sorted.Business.IContract;
using Sorted.Business.Mapping;
using Sorted.Business.Services;
using Sorted.Rainfall;

var builder = WebApplication.CreateBuilder(args);

ConfigureServices(builder.Services, builder.Configuration);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
    services.AddHttpClient("RainFallAPI", client =>
    {
        client.BaseAddress = new Uri("https://environment.data.gov.uk");
        client.Timeout = Timeout.InfiniteTimeSpan;
    });


    services.AddAutoMapper(typeof(DomainToPersistenceToDomain));

    //Inject Rainfall Services
    services.AddTransient<IStationReadingService, StationReadingService>();

    //business object
    services.AddTransient<ISortedReadingStationService, SortedReadingStationService>();

}
