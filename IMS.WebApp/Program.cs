using IMS.CoreBusiness.Models;
using IMS.plugins.DataStore.HardCoded;
using IMS.Plugins.InMemory;
using IMS.Plugins.SQLite;
using IMS.UseCases._PluginInterfaces_.DataStore;
using IMS.UseCases.ContactsUseCases;
using IMS.UseCases.InventoryUseCases;
using IMS.UseCases.InventoryUseCases.Interfaces;
using IMS.UseCases.MercedesUseCases;
using IMS.UseCases.MercedesUseCases.interfaces;
using IMS.UseCases.PluginInterfaces.DataStore;
using IMS.UseCases.SearchProductScreen;
using IMS.UseCases.SearchProductScreen.interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using InventoryRepository = IMS.Plugins.InMemory.InventoryRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container. //EF

//builder.Services.AddDbContext<IMSSQLiteDbContext>(options =>
//options.UseSqlite(builder.Configuration.GetConnectionString("SQLiteDatabase")));


//builder.Services.AddDbContext<IMSSQLiteDbContext>(options => options.UseSqlite("Data Source=ims.db"));
//builder.Services.AddDbContext<IMSSQLiteDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("SQLiteConnection")));



//using (var context = ServiceProvider.GetService<IMSContext>())
//{
//    // Check if the database has already been seeded
//    if (!context.Inventories.Any())
//    {
//        // If not, seed the database
//        SeedData.Initialize(context);
//    }
//}

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

//builder.Services.AddSingleton<WeatherForecastService>();

//builder.Services.AddDbContext<IMSContext>(options =>)

builder.Services.AddScoped<IMSSQLiteDbContext>(provider =>
{
    var options = new DbContextOptionsBuilder<IMSSQLiteDbContext>()
        .UseSqlite("Data Source=IMS.db")
        .Options;

    var context = new IMSSQLiteDbContext(options);
    context.Database.Migrate(); // Add this line to apply any pending migrations
    context.Database.EnsureCreated(); // Add this line to create the database if it doesn't exist
    return context;
});

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
builder.Services.AddTransient<IViewInventoryByIdUseCase, ViewInventoryByIdUseCase>();
//=========================================================================================== 



var app = builder.Build();

// Seed the data
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<IMSSQLiteDbContext>();
    context.Database.EnsureCreated(); // Add this line to create the database if it doesn't exist
    SeedData.Initialize(context);
}
//using var scope = app.Services.CreateScope();
//var dbContext = scope.ServiceProvider.GetRequiredService<IMSSQLiteDbContext>();

//// Query the sources and their related inventories
//var sources = dbContext.Sources
//    .Include(s => s.Inventories)
//    .AsNoTracking()
//    .ToList();

//// Display the sources and their related inventories
//Console.WriteLine("Sources:");
//foreach (var source in sources)
//{
//    Console.WriteLine($"- Id: {source.Id}, Name: {source.Name}, Type: {source.GetType().Name}");

//    if (source.Inventories != null)
//    {
//        Console.WriteLine("  Inventories:");
//        foreach (var inventory in source.Inventories)
//        {
//            Console.WriteLine($"  - Id: {inventory.Id}, InventoryId: {inventory.InventoryId}, InventoryName: {inventory.InventoryName}, Quantity: {inventory.Quantity}, Price: {inventory.Price}");
//        }
//    }








//// Add the code snippet here:
//using var scope = app.Services.CreateScope();
//var dbContext = scope.ServiceProvider.GetRequiredService<IMSSQLiteDbContext>();

//// Query the sources and their related inventories
//var sources = dbContext.Set<Source>()
//    .Include(s => s.Inventories)
//    .AsNoTracking()
//    .ToList();

//// Display the sources and their related inventories
//Console.WriteLine("Sources:");
//foreach (var source in sources)
//{
//    Console.WriteLine($"- Id: {source.Id}, Name: {source.Name}, Type: {source.GetType().Name}");

//    if (source.Inventories != null)
//    {
//        Console.WriteLine("  Inventories:");
//        foreach (var inventory in source.Inventories)
//        {
//            Console.WriteLine($"  - Id: {inventory.Id}, InventoryId: {inventory.InventoryId}, InventoryName: {inventory.InventoryName}, Quantity: {inventory.Quantity}, Price: {inventory.Price}");
//        }
//    }
//}
//// End of the code snippet

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
    using (var imsscope = app.Services.CreateScope())
    {
        var imsDbContext = imsscope.ServiceProvider.GetRequiredService<IMSSQLiteDbContext>();

        // Apply any pending migrations
        imsDbContext.Database.Migrate();
    }

    app.Run();

