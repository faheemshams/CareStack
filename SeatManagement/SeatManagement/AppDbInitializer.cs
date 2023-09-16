using DataAccessLayer.Entities;
namespace DataAccessLayer.Context;

public class AppDbInitializer
{
    public static void Seed(IApplicationBuilder applicationBuilder)
    {
        using(var serviceScope = applicationBuilder.ApplicationServices.CreateScope()) 
        {
            var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
            context.Database.EnsureCreated();

            if(!context.Cities.Any()) 
            {
                context.Cities.AddRange(new List<City>()
                {
                    new City()
                    {
                        CityName = "Trivandrum",
                        CityAbbreviation = "TVM"
                    },

                    new City()
                    {
                        CityName = "Kochi",
                        CityAbbreviation = "KCH"
                    },

                    new City()
                    {
                        CityName = "Bangalore",
                        CityAbbreviation = "BLR"
                    },
                    new City()
                    {
                        CityName = "Orlando",
                        CityAbbreviation = "ORL"
                    }
                });
                context.SaveChanges();
            }

            if (!context.Buildings.Any())
            {
                context.Buildings.AddRange(new List<Building>()
                {
                    new Building()
                    {
                        BuildingName = "Yamuna",
                        BuildingAbbreviation = "YAM",
                        FloorCount = 11
                    },

                     new Building()
                    {
                        BuildingName = "Transasis Towers",
                        BuildingAbbreviation = "TRN",
                        FloorCount = 30
                    },

                      new Building()
                    {
                        BuildingName = "Ganga",
                        BuildingAbbreviation = "GNG",
                        FloorCount = 10
                    },
                });
                context.SaveChanges();
            }

            if (!context.Departments.Any()) 
            {
                context.Departments.AddRange(new List<Department>()
                {
                    new Department()
                    {
                        DeptName = "HR"
                    },
                    new Department()
                    {
                        DeptName = "Engineering"
                    },
                    new Department()
                    {
                        DeptName = "Product"
                    },
                    new Department()
                    {
                        DeptName = "QA"
                    },
                    new Department()
                    {
                        DeptName = "TOPS"
                    },
                    new Department()
                    {
                        DeptName = "SRE"
                    },
                    new Department()
                    {
                        DeptName = "Marketting"
                    }
                });
                context.SaveChanges();
            }

            if(!context.LookupRoomsType.Any())
            {
                context.LookupRoomsType.AddRange(new List<LookupRoomType>()
                {
                    new LookupRoomType() 
                    {
                        RoomTypeName = "Empty"
                    },
                    
                    new LookupRoomType()
                    {
                        RoomTypeName = "Open Room"
                    },
                    new LookupRoomType()
                    {
                        RoomTypeName = "Cabin Room"
                    },
                    new LookupRoomType()
                    {
                        RoomTypeName = "Meeting Room"
                    }
                });
                context.SaveChanges();
            }

            if(!context.LookupAssets.Any())
            {
                context.LookupAssets.AddRange(new List<LookupAsset>()
                {
                    new LookupAsset()
                    {
                        AssetName = "Projector"
                    },
                    new LookupAsset()
                    {
                        AssetName = "Laptop"
                    },
                    new LookupAsset()
                    {
                        AssetName = "Printer"
                    },
                    new LookupAsset()
                    {
                        AssetName = "Speaker"
                    },
                    new LookupAsset()
                    {
                        AssetName = "Desktop"
                    },
                     new LookupAsset()
                    {
                        AssetName = "KeyBoard"
                    },
                     new LookupAsset()
                    {
                        AssetName = "Mouse"
                    },
                });
                context.SaveChanges();  
            }
        }
    }
}


