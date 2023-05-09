using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorApp.Client;
// To use FluentUI library
using Microsoft.Fast.Components.FluentUI;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration["API_Prefix"] ?? builder.HostEnvironment.BaseAddress) });

// Add FluentUI components
builder.Services.AddFluentUIComponents(options =>
{
    options.HostingModel = BlazorHostingModel.WebAssembly;
    options.IconConfiguration = ConfigurationGenerator.GetIconConfiguration();
    options.EmojiConfiguration = ConfigurationGenerator.GetEmojiConfiguration();
});

await builder.Build().RunAsync();
