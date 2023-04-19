using GQLDemo.Data;
using GQLDemo.GraphQl;
using GQLDemo.GraphQl.Commands;
using GQLDemo.GraphQl.Platform;
using GraphQL.Server.Ui.Voyager;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPooledDbContextFactory<AppDbContext>(
    opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("GQL")));
builder.Services.AddGraphQLServer().
    AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddSubscriptionType<Subscription>()    
    .AddType<PlatofrmType>()
    .AddType<CommandType>()
    .AddFiltering()
    .AddSorting()
    .AddInMemorySubscriptions();

var app = builder.Build();
app.UseWebSockets();
app.UseRouting();

app.UseEndpoints(endpoint =>
{
    endpoint.MapGraphQL();
});

app.UseGraphQLVoyager(options: new VoyagerOptions
{
    GraphQLEndPoint = @"/graphql"
});
app.Run();
