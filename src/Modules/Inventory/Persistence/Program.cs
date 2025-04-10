// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Modules.Inventory.Persistence;

const string CONNSTRING = "Server=.;Database=VendTron9000;Trusted_Connection=true;Trust Server Certificate=true";

Console.WriteLine("Welcome to VendTron-9000!!!...");

IHostBuilder builder = Host
    .CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddDbContext<InventoryDbContext>(options =>
            options.UseSqlServer(CONNSTRING));
    });
IHost host = builder.Build();
