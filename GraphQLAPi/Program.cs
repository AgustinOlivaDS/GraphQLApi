using GraphiQl;
using GraphQL.Server;
using GraphQL.Types;
using GraphQLAPi.Data;
using GraphQLAPi.Intefaces;
using GraphQLAPi.Mutation;
using GraphQLAPi.Query;
using GraphQLAPi.Schema;
using GraphQLAPi.Services;
using GraphQLAPi.Type;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Writers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Inyect
builder.Services.AddTransient<iProduct, ProductService>();

builder.Services.AddTransient<ProductType>();
builder.Services.AddTransient<ProductQuery>();
builder.Services.AddTransient<ProductMutation>();
builder.Services.AddTransient<ISchema, ProductSchema>();

builder.Services.AddDbContext<GraphQLDbContext>(options => options.UseSqlServer(@"Data Source=LAPTOP-JT42OBMR;Initial Catalog=Testing;User Id=sa;Password=Luxsys2010;TrustServerCertificate=True"));

builder.Services.AddGraphQL(options =>
{
    options.EnableMetrics = false;
}).AddSystemTextJson();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<GraphQLDbContext>();

    //EnsureDeleted() is an additional option that first deletes an existing database.
    //dbContext.Database.EnsureDeleted();
    dbContext.Database.EnsureCreated();

}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

app.UseGraphiQl("/graphql");
app.UseGraphQL<ISchema>();

app.Run();
