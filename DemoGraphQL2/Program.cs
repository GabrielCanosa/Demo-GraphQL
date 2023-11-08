using DemoGraphQL2.Schema.Mutations;
using DemoGraphQL2.Schema.Queries;
using DemoGraphQL2.Schema.Subscriptions;
using DemoGraphQL2.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddSubscriptionType<Subscription>()
    .AddInMemorySubscriptions();

//AddPooledDbContextFactory ensures that we will have a "pool" of DbContext's ready
// This allows Hot Chocolate to safely execute EF operations in parallel
builder.Services.AddPooledDbContextFactory<SchoolDbContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

app.UseWebSockets();

app.MapGraphQL();

app.Run();
