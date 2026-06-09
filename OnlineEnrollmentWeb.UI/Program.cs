using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor;
using MudBlazor.Services;
using OnlineEnrollmentWeb.UI;
using OnlineEnrollmentWeb.UI.Data;
using OnlineEnrollmentWeb.UI.Pages.Admin;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddAuthorizationCore();
builder.Services.AddBlazoredLocalStorage();


builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://172.20.10.3:5080/") });

builder.Services.AddMudServices();


builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<StudentsService>();

builder.Services.AddScoped<EnrollmentService>();
builder.Services.AddScoped<PaymentService>();
builder.Services.AddScoped<DocumentsService>();
builder.Services.AddScoped<EligibilityService>();



await builder.Build().RunAsync();
