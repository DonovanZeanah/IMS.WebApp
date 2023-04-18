using IMS.plugins.DataStore.HardCoded;
using IMS.UseCases._PluginInterfaces_.DataStore;
using IMS.UseCases.ContactsUseCases;
using IMS.UseCases.InventoryUseCases;
using IMS.UseCases.InventoryUseCases.Interfaces;
using IMS.UseCases.MercedesUseCases;
using IMS.UseCases.MercedesUseCases.interfaces;
using IMS.UseCases.PluginInterfaces.DataStore;
using IMS.UseCases.SearchProductScreen;
using IMS.UseCases.SearchProductScreen.interfaces;
using InventoryRepository = IMS.Plugins.InMemory.InventoryRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//EF
//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));


builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

//builder.Services.AddSingleton<WeatherForecastService>();

//builder.Services.AddDbContext<IMSContext>(options =>)



// =========================   \\interfaces and their \\implementation
builder.Services.AddTransient<IContactRepository, ContactRepository>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();


//=========================================================================================== 
builder.Services.AddTransient<IMercedesRepository, MercedesRepository>();

builder.Services.AddTransient<ISearchMercede, SearchMercede>();
builder.Services.AddTransient<IViewMercede, ViewMercede>();



//=========================================================================================== 
builder.Services.AddTransient<IProductRepository, ProductRepository>();

builder.Services.AddTransient<ISearchProduct, SearchProduct>();
builder.Services.AddTransient<IViewProduct, ViewProduct>();

//=========================================================================================== 
builder.Services.AddSingleton<IInventoryRepository, InventoryRepository>();

builder.Services.AddTransient<IViewInventoriesByNameUseCase, ViewInventoriesByNameUseCase>();
builder.Services.AddTransient<IAddInventoryUseCase, AddInventoryUseCase>();
builder.Services.AddTransient<IEditInventoryUseCase, EditInventoryUseCase>();
builder.Services.AddTransient<IViewInventoryByIdUseCase , ViewInventoryByIdUseCase>();
//=========================================================================================== 



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
  app.UseExceptionHandler("/Error");
  // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
  app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();

app.MapFallbackToPage("/_Host");

app.Run();
