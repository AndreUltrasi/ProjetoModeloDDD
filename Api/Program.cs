using ProjetoModeloDDD.Infra.Contexto;
using Microsoft.EntityFrameworkCore;
using ProjetoModeloDDD.Core.Services;
using ProjetoModeloDDD.Core.Interfaces.Services;
using ProjetoModeloDDD.Core.Interfaces.Repositories;
using ProjetoModeloDDD.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IProdutoService, ProdutoService>();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();

var connection = @"Server=(localdb)\mssqllocaldb;Database=ProjetoModeloDDD;Trusted_Connection=True;";

builder.Services.AddDbContext<ProjetoModeloContext>(options => options.UseSqlServer(connection));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
