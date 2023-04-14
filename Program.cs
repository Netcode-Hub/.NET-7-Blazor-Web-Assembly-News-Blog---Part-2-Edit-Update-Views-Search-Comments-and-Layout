using DemoBlogForYoutube.Client;
using DemoBlogForYoutube.Client.Services.CategoryServices;
using DemoBlogForYoutube.Client.Services.NewsServices;
using DemoBlogForYoutube.Client.Services.WriterServices;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Syncfusion.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddSyncfusionBlazor();
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mgo+DSMBaFt+QHFqVkNrXVNbdV5dVGpAd0N3RGlcdlR1fUUmHVdTRHRcQlljSn5TdERiW3hXdHU=;Mgo+DSMBPh8sVXJ1S0d+X1RPd11dXmJWd1p/THNYflR1fV9DaUwxOX1dQl9gSXpTdUVjW35fcnxUQGE=;ORg4AjUWIQA/Gnt2VFhhQlJBfV5AQmBIYVp/TGpJfl96cVxMZVVBJAtUQF1hSn5XdkZjWX1fcXZdRWFd;MTU5MDU2MkAzMjMxMmUzMTJlMzMzNVRiUDhYeWJueS9Qd1MyZndJVUZpT2lUZFRyZ1VvZmdrUEl3ZjZaY21NL2s9;MTU5MDU2M0AzMjMxMmUzMTJlMzMzNWl6ZEl6b3JidGpmUVMrYklNdW9NRmorMkE2V1k2OUVBSlROekhNMDBySGM9;NRAiBiAaIQQuGjN/V0d+XU9Hc1RDX3xKf0x/TGpQb19xflBPallYVBYiSV9jS31TckVgWX9ccXVXT2BUUA==;MTU5MDU2NUAzMjMxMmUzMTJlMzMzNWYyZVluVG5XZ0krOHIxR3BGenM3N2sxdDRHdXR5TmZveTB1VEN0bWZIQjQ9;MTU5MDU2NkAzMjMxMmUzMTJlMzMzNVlQVWdVdmQ5djlrWkluaGVTemFhYjRUbmZPUTNLMG94L21IbVdQUGdxZEE9;Mgo+DSMBMAY9C3t2VFhhQlJBfV5AQmBIYVp/TGpJfl96cVxMZVVBJAtUQF1hSn5XdkZjWX1fcXZcQWhd;MTU5MDU2OEAzMjMxMmUzMTJlMzMzNUhNbE9WWERBZG1HOENxMVRMUmkvTnNtRURtc3hJWXBSUFdFQ0xIL0tTdk09;MTU5MDU2OUAzMjMxMmUzMTJlMzMzNWsza2I1cXR1ZlJ4WkxsMnU1d1prejFBQkUwbm1wMFp3SUprdXpkemFhNVk9;MTU5MDU3MEAzMjMxMmUzMTJlMzMzNWYyZVluVG5XZ0krOHIxR3BGenM3N2sxdDRHdXR5TmZveTB1VEN0bWZIQjQ9");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<INewsService, NewsService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IWriterService, WriterService>();
await builder.Build().RunAsync();