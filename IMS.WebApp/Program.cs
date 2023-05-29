using BlazorSignalRChartApp.Models;
using IMS.plugins.DataStore.HardCoded;
using IMS.Plugins.InMemory;
using IMS.Plugins.SQLite;
using IMS.Plugins.SQLite.Data;
using IMS.UseCases._PluginInterfaces_.DataStore;
using IMS.UseCases.InventoriesUseCases.Interfaces;
using IMS.UseCases.InventoryUseCases;
using IMS.UseCases.InventoryUseCases.Interfaces;
using IMS.UseCases.MercedesUseCases;
using IMS.UseCases.MercedesUseCases.interfaces;
using IMS.UseCases.PluginInterfaces.DataStore;
using IMS.UseCases.SearchProductScreen;
using IMS.UseCases.SearchProductScreen.interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container. //EF

/*var connectionString = builder.Configuration.GetConnectionString("IdentityDbConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));*/

// Add Contact Web DB Connection
//var mcmdContext = builder.Configuration.GetConnectionString("SQLConnection");
var connectionString = builder.Configuration.GetConnectionString("SQLConnection");



builder.Services.AddScoped(provider =>
{
    var dbContextFactory = provider.GetRequiredService<IDbContextFactory<T4Context>>();
    return dbContextFactory.CreateDbContext();
});
//builder.Services.AddDbContext<T4Context>(options =>
  //  options.UseSqlServer(connectionString));


//builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddRoles<IdentityRole>()
//    .AddEntityFrameworkStores<ApplicationDbContext>();





//builder.Services.AddDbContext<IMSSQLiteDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("SQLiteConnection")));





builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

//builder.Services.AddSingleton<WeatherForecastService>();

//builder.Services.AddDbContext<IMSContext>(options =>)

builder.Services.AddScoped(provider =>
{
    var options = new DbContextOptionsBuilder<IMSSQLiteDbContext>()
        .UseSqlite("Data Source=IMS2.db")
        .Options;

    var context = new IMSSQLiteDbContext(options);
    // context.Database.Migrate(); // Add this line to apply any pending migrations
    context.Database.EnsureCreated(); // Add this line to create the database if it doesn't exist
    return context;
});


// =========================   \\interfaces and their \\implementation
//builder.Services.AddTransient<IContactRepository, ContactRepository>();
//builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();


//=========================================================================================== 
builder.Services.AddTransient<IMercedesRepository, MercedesRepository>();

builder.Services.AddTransient<ISearchMercede, SearchMercede>();
builder.Services.AddTransient<IViewMercede, ViewMercede>();



//=========================================================================================== 
builder.Services.AddTransient<IProductRepository, ProductRepository>();

builder.Services.AddTransient<ISearchProduct, SearchProduct>();
builder.Services.AddTransient<IViewProduct, ViewProduct>();

//=========================================================================================== 
//builder.Services.AddSingleton<IInventoryRepository, InMemoryInventoryRepository>();
//builder.Services.AddScoped<ISQLiteInventoryRepository, SqliteInventoryRepository>();
builder.Services.AddScoped<ISQLiteInventoryRepository, InMemoryInventoryRepository>();

builder.Services.AddScoped<ISQLiteBaseSourceRepository, SQLiteBaseSourceRepository>();



builder.Services.AddTransient<IViewInventoriesByNameUseCase, ViewInventoriesByNameUseCase>();
builder.Services.AddTransient<IAddInventoryUseCase, AddInventoryUseCase>();
builder.Services.AddTransient<IEditInventoryUseCase, EditInventoryUseCase>();
builder.Services.AddTransient<IViewInventoryByIdUseCase, ViewInventoryByIdUseCase>();
//=========================================================================================== 
builder.Services.AddLogging(loggingBuilder =>
{
    loggingBuilder.AddConsole(); // Add the console logger
});


var app = builder.Build();

// Seed the data




// Log the registered services

// Other operations


//using (var scope = app.Services.CreateScope())
//{
//    var services1 = new ServiceCollection();

//    // Register services

//    // ...

//    var serviceProvider = services1.BuildServiceProvider();

//    // Get an instance of ILogger
//    var logger = serviceProvider.GetRequiredService<ILogger<Program>>();

//    // Log the registered services
//    foreach (var service in services1)
//    {
//        logger.LogInformation($"Registered service: {service.ServiceType} - {service.ImplementationType}");
//    }

//    var services = scope.ServiceProvider;
//    var context = services.GetRequiredService<IMSSQLiteDbContext>();
//    context.Database.EnsureCreated(); // Add this line to create the database if it doesn't exist
//    SeedData.Initialize(context);
//}


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

//using (var imsscope = app.Services.CreateScope())
//{
//    var imsDbContext = imsscope.ServiceProvider.GetRequiredService<IMSSQLiteDbContext>();

//    // Apply any pending migrations
//    imsDbContext.Database.Migrate();
//}

app.Run();
