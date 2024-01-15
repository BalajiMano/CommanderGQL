using CommanderGQL.Controllers;
using CommanderGQL.Data;
using CommanderGQL.GraphQL;
using CommanderGQL.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<ICommands,CommandsService>();
builder.Services.AddDbContext<PlatformDBContext>(opt=>
            opt.UseSqlServer(builder.Configuration.GetConnectionString("CommanderStr")));
builder.Services.AddGraphQLServer()
                 .AddQueryType<Query>();
var app = builder.Build();
app.MapControllers();
app.UseHttpsRedirection();
app.MapGraphQL();
app.MapGet("/", () => "Hello World!");

app.Run();
