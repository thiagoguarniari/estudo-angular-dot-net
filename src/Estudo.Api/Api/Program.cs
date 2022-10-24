using Domain.Commands.v1.Lead.AcceptLead;
using Domain.Interfaces.v1.Repositories;
using Infrastructure.Data;
using Infrastructure.Data.Repositories.v1;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();
builder.Services.AddScoped<ILeadRepository, LeadRepository>();
builder.Services.AddMediatR(typeof(AcceptLeadCommandHandler).Assembly);
builder.Services.AddLogging();
builder.Services.AddDbContextPool<DatabaseContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("LeadProjectDatabase")));

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("https://localhost:4200", "http://localhost:4200", "localhost:4200", "localhost");
        });
});

var app = builder.Build();
app.UseCors(policy =>
                policy.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();