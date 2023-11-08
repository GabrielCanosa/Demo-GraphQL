using DemoGraphQL2.Schema.Mutations;
using DemoGraphQL2.Schema.Queries;
using DemoGraphQL2.Schema.Subscriptions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddSubscriptionType<Subscription>()
    .AddInMemorySubscriptions();

var app = builder.Build();

app.UseWebSockets();

app.MapGraphQL();

app.Run();
