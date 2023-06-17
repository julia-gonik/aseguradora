using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

using Aseguradora.Repositorios;
using Aseguradora.Aplicacion;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddTransient<AgregarVehiculoUseCase>();
builder.Services.AddTransient<ListarVehiculosUseCase>();
builder.Services.AddTransient<EliminarVehiculoUseCase>();
builder.Services.AddTransient<ModificarVehiculoUseCase>();
builder.Services.AddTransient<ObtenerVehiculoUseCase>();
builder.Services.AddScoped<IRepositorioVehiculo, RepositorioVehiculoTXT>();

builder.Services.AddTransient<AgregarTitularUseCase>();
builder.Services.AddTransient<ListarTitularesUseCase>();
builder.Services.AddTransient<ListarTitularesConSusVehiculosUseCase>();
builder.Services.AddTransient<EliminarTitularUseCase>();
builder.Services.AddTransient<ModificarTitularUseCase>();
builder.Services.AddTransient<ObtenerTitularUseCase>();
builder.Services.AddScoped<IRepositorioTitular, RepositorioTitularTXT>();

builder.Services.AddTransient<AgregarPolizaUseCase>();
builder.Services.AddTransient<ListarPolizasUseCase>();
builder.Services.AddTransient<EliminarPolizaUseCase>();
builder.Services.AddTransient<ModificarPolizaUseCase>();
builder.Services.AddScoped<IRepositorioPoliza, RepositorioPolizaTXT>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
