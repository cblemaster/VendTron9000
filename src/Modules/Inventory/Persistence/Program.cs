
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Modules.Inventory.Domain.Entities;
using Modules.Inventory.Persistence;

const string CONNSTRING = "Server=.;Database=VendTron9000;Trusted_Connection=true;Trust Server Certificate=true";

Console.WriteLine("Welcome to VendTron-9000!!!...");

IHostBuilder builder = Host
    .CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
        services.AddDbContext<InventoryDbContext>(options =>
            options
            .UseSqlServer(CONNSTRING)
#pragma warning disable IDE0058
            .UseSeeding((context, b) =>
            {
                if (!context.Set<SnackType>().Any())
                {
                    context.Set<SnackType>().Add(new SnackType("Chips", Guid.Parse("48119E16-AE82-4B3F-8C91-0B6DA67DF505")));
                    context.Set<SnackType>().Add(new SnackType("Crackers", Guid.Parse("DBD74CA6-C24A-4C65-8521-32E083C40A8E")));
                    context.Set<SnackType>().Add(new SnackType("Drink", Guid.Parse("3858958D-A929-497D-A178-6DB5FD14437A")));
                    context.Set<SnackType>().Add(new SnackType("Pastry", Guid.Parse("FAB70135-3BC3-4B50-8E91-E639532F4624")));
                    context.SaveChanges();
                }
                if (!context.Set<Snack>().Any())
                {
                    context.Set<Snack>().Add(new Snack("Potato Crisps", 3.05m, 2.70m, Guid.Parse("48119E16-AE82-4B3F-8C91-0B6DA67DF505"), "A1", Guid.Parse("09C5917C-03F5-4F59-95DC-19856D12756F")));
                    context.Set<Snack>().Add(new Snack("Prongles", 1.45m, 1.25m, Guid.Parse("48119E16-AE82-4B3F-8C91-0B6DA67DF505"), "A2", Guid.Parse("46AC5B5F-700A-4AEE-8106-D4B745DCC93B")));
                    context.Set<Snack>().Add(new Snack("Boogles", 2.75m, 2.40m, Guid.Parse("48119E16-AE82-4B3F-8C91-0B6DA67DF505"), "A3", Guid.Parse("720F4919-6BBC-4090-A6C9-00C31798F29D")));
                    context.Set<Snack>().Add(new Snack("Veggie Crisps", 3.65m, 2.95m, Guid.Parse("48119E16-AE82-4B3F-8C91-0B6DA67DF505"), "A4", Guid.Parse("ADAF1AFB-20DF-4EC3-BEFB-A4B3CAFFA159")));

                    context.Set<Snack>().Add(new Snack("Lieutenants Wafers", 1.80m, 1.50m, Guid.Parse("DBD74CA6-C24A-4C65-8521-32E083C40A8E"), "B1", Guid.Parse("269CF2B1-88D0-4809-9154-FCCF0F3D5D20")));
                    context.Set<Snack>().Add(new Snack("Chweesits", 1.50m, 1.05m, Guid.Parse("DBD74CA6-C24A-4C65-8521-32E083C40A8E"), "B2", Guid.Parse("50C557B2-9AAA-4DFD-901F-89E9D3B250DB")));
                    context.Set<Snack>().Add(new Snack("Pita Squares", 1.50m, 1.25m, Guid.Parse("DBD74CA6-C24A-4C65-8521-32E083C40A8E"), "B3", Guid.Parse("5B1910CA-1F60-4A41-BECE-2D19C8F6567C")));
                    context.Set<Snack>().Add(new Snack("Nyblets", 1.75m, 1.35m, Guid.Parse("DBD74CA6-C24A-4C65-8521-32E083C40A8E"), "B4", Guid.Parse("7921B98C-FAF1-4365-96CC-1F46D6FE9197")));

                    context.Set<Snack>().Add(new Snack("Cola", 1.25m, 1.00m, Guid.Parse("3858958D-A929-497D-A178-6DB5FD14437A"), "C1", Guid.Parse("94A52D08-C2FE-43B1-A983-6FEA3ADEC482")));
                    context.Set<Snack>().Add(new Snack("Dr. Rumble", 1.50m, 1.25m, Guid.Parse("3858958D-A929-497D-A178-6DB5FD14437A"), "C2", Guid.Parse("E52EF7D1-1C6E-4E38-85A4-896841B1E448")));
                    context.Set<Snack>().Add(new Snack("Mountain Condensate", 1.50m, 1.15m, Guid.Parse("3858958D-A929-497D-A178-6DB5FD14437A"), "C3", Guid.Parse("E7FA32E5-12B1-4CBE-BBD7-8F87B58CA4E8")));
                    context.Set<Snack>().Add(new Snack("EnergyStroke", 1.50m, 1.00m, Guid.Parse("3858958D-A929-497D-A178-6DB5FD14437A"), "C4", Guid.Parse("07F3FC1D-A5C9-4960-82F0-AE570AE88FB8")));

                    context.Set<Snack>().Add(new Snack("Cinnamon Pastry", 0.85m, 0.70m, Guid.Parse("FAB70135-3BC3-4B50-8E91-E639532F4624"), "D1", Guid.Parse("89CB3F5D-7BF0-4461-B103-F3554397B31C")));
                    context.Set<Snack>().Add(new Snack("Strawberry Pastry", 0.95m, 0.80m, Guid.Parse("FAB70135-3BC3-4B50-8E91-E639532F4624"), "D2", Guid.Parse("65A508C4-C9C4-4422-9301-2205CAE811B3")));
                    context.Set<Snack>().Add(new Snack("Blueberry Pastry", 0.75m, 0.65m, Guid.Parse("FAB70135-3BC3-4B50-8E91-E639532F4624"), "D3", Guid.Parse("1AA5C1E1-C861-4409-8685-A0BAD52C2F40")));
                    context.Set<Snack>().Add(new Snack("Apple Pastry", 0.75m, 0.60m, Guid.Parse("FAB70135-3BC3-4B50-8E91-E639532F4624"), "D4", Guid.Parse("FC8B9ACB-B194-4F82-B55D-583367B7A467")));
                    context.SaveChanges();
                }
            }).UseAsyncSeeding(async(context, b, c) =>
            {
                if (!context.Set<SnackType>().Any())
                {
                    context.Set<SnackType>().Add(new SnackType("Chips", Guid.Parse("48119E16-AE82-4B3F-8C91-0B6DA67DF505")));
                    context.Set<SnackType>().Add(new SnackType("Crackers", Guid.Parse("DBD74CA6-C24A-4C65-8521-32E083C40A8E")));
                    context.Set<SnackType>().Add(new SnackType("Drink", Guid.Parse("3858958D-A929-497D-A178-6DB5FD14437A")));
                    context.Set<SnackType>().Add(new SnackType("Pastry", Guid.Parse("FAB70135-3BC3-4B50-8E91-E639532F4624")));
                    await context.SaveChangesAsync(c);
                }
                if (!context.Set<Snack>().Any())
                {
                    context.Set<Snack>().Add(new Snack("Potato Crisps", 3.05m, 2.70m, Guid.Parse("48119E16-AE82-4B3F-8C91-0B6DA67DF505"), "A1", Guid.Parse("09C5917C-03F5-4F59-95DC-19856D12756F")));
                    context.Set<Snack>().Add(new Snack("Prongles", 1.45m, 1.25m, Guid.Parse("48119E16-AE82-4B3F-8C91-0B6DA67DF505"), "A2", Guid.Parse("46AC5B5F-700A-4AEE-8106-D4B745DCC93B")));
                    context.Set<Snack>().Add(new Snack("Boogles", 2.75m, 2.40m, Guid.Parse("48119E16-AE82-4B3F-8C91-0B6DA67DF505"), "A3", Guid.Parse("720F4919-6BBC-4090-A6C9-00C31798F29D")));
                    context.Set<Snack>().Add(new Snack("Veggie Crisps", 3.65m, 2.95m, Guid.Parse("48119E16-AE82-4B3F-8C91-0B6DA67DF505"), "A4", Guid.Parse("ADAF1AFB-20DF-4EC3-BEFB-A4B3CAFFA159")));

                    context.Set<Snack>().Add(new Snack("Lieutenants Wafers", 1.80m, 1.50m, Guid.Parse("DBD74CA6-C24A-4C65-8521-32E083C40A8E"), "B1", Guid.Parse("269CF2B1-88D0-4809-9154-FCCF0F3D5D20")));
                    context.Set<Snack>().Add(new Snack("Chweesits", 1.50m, 1.05m, Guid.Parse("DBD74CA6-C24A-4C65-8521-32E083C40A8E"), "B2", Guid.Parse("50C557B2-9AAA-4DFD-901F-89E9D3B250DB")));
                    context.Set<Snack>().Add(new Snack("Pita Squares", 1.50m, 1.25m, Guid.Parse("DBD74CA6-C24A-4C65-8521-32E083C40A8E"), "B3", Guid.Parse("5B1910CA-1F60-4A41-BECE-2D19C8F6567C")));
                    context.Set<Snack>().Add(new Snack("Nyblets", 1.75m, 1.35m, Guid.Parse("DBD74CA6-C24A-4C65-8521-32E083C40A8E"), "B4", Guid.Parse("7921B98C-FAF1-4365-96CC-1F46D6FE9197")));

                    context.Set<Snack>().Add(new Snack("Cola", 1.25m, 1.00m, Guid.Parse("3858958D-A929-497D-A178-6DB5FD14437A"), "C1", Guid.Parse("94A52D08-C2FE-43B1-A983-6FEA3ADEC482")));
                    context.Set<Snack>().Add(new Snack("Dr. Rumble", 1.50m, 1.25m, Guid.Parse("3858958D-A929-497D-A178-6DB5FD14437A"), "C2", Guid.Parse("E52EF7D1-1C6E-4E38-85A4-896841B1E448")));
                    context.Set<Snack>().Add(new Snack("Mountain Condensate", 1.50m, 1.15m, Guid.Parse("3858958D-A929-497D-A178-6DB5FD14437A"), "C3", Guid.Parse("E7FA32E5-12B1-4CBE-BBD7-8F87B58CA4E8")));
                    context.Set<Snack>().Add(new Snack("EnergyStroke", 1.50m, 1.00m, Guid.Parse("3858958D-A929-497D-A178-6DB5FD14437A"), "C4", Guid.Parse("07F3FC1D-A5C9-4960-82F0-AE570AE88FB8")));

                    context.Set<Snack>().Add(new Snack("Cinnamon Pastry", 0.85m, 0.70m, Guid.Parse("FAB70135-3BC3-4B50-8E91-E639532F4624"), "D1", Guid.Parse("89CB3F5D-7BF0-4461-B103-F3554397B31C")));
                    context.Set<Snack>().Add(new Snack("Strawberry Pastry", 0.95m, 0.80m, Guid.Parse("FAB70135-3BC3-4B50-8E91-E639532F4624"), "D2", Guid.Parse("65A508C4-C9C4-4422-9301-2205CAE811B3")));
                    context.Set<Snack>().Add(new Snack("Blueberry Pastry", 0.75m, 0.65m, Guid.Parse("FAB70135-3BC3-4B50-8E91-E639532F4624"), "D3", Guid.Parse("1AA5C1E1-C861-4409-8685-A0BAD52C2F40")));
                    context.Set<Snack>().Add(new Snack("Apple Pastry", 0.75m, 0.60m, Guid.Parse("FAB70135-3BC3-4B50-8E91-E639532F4624"), "D4", Guid.Parse("FC8B9ACB-B194-4F82-B55D-583367B7A467")));
                    await context.SaveChangesAsync(c);
                }
            })));
#pragma warning restore IDE0058
IHost host = builder.Build();
