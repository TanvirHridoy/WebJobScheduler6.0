using WebJobScheduler6._0.Works;

var builder = WebApplication.CreateBuilder(args);
SchedulerTask.StartAsync().GetAwaiter().GetResult();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
