using Microsoft.EntityFrameworkCore;
using Repositorio;
using Servicos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(option =>
    option.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Apresentacao"))
);

builder.Services.AddScoped<IServProduto, ServProduto>();
builder.Services.AddScoped<IRepoProduto, RepoProduto>();

builder.Services.AddScoped<IServFornecedor, ServFornecedor>();
builder.Services.AddScoped<IRepoFornecedor, RepoFornecedor>();

builder.Services.AddScoped<IServAssociar, ServAssociar>();
builder.Services.AddScoped<IRepoAssociar, RepoAssociar>();

builder.Services.AddScoped<IServVender, ServVender>();
builder.Services.AddScoped<IRepoVender, RepoVender>();

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
