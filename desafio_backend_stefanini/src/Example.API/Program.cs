using Example.Application.ExampleService.Service;
using Example.Domain.Interfaces;
using Example.Infra.Data;
using Example.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddScoped<IExampleService, ExampleService>();
builder.Services.AddScoped<ICidadeService, CidadeService>();
builder.Services.AddScoped<IPessoaService, PessoaService>();
builder.Services.AddDbContext<ApplicationContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//builder.Services.AddCors(x => x.AddPolicy("IIS_APDATA", z => z.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));


//builder.Services.AddSession();

//builder.Services.AddDbContext<ApplicationContext>(options =>
//            options.UseSqlServer(
//                builder.Configuration.GetConnectionString("DefaultConnection"),
//                b => b.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)));

//#region Repositories
//builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
//builder.Services.AddTransient<IExempleRepository, ExempleRepository>();
//#endregion

var app = builder.Build();

app.UseCors(options => options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
    dataContext.Database.Migrate();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

