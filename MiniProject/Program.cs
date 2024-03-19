using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using Microsoft.VisualBasic.FileIO;
using MiniProject.Entities.Enums;
using MiniProject.Extensions;
using MiniProject.Models.DataContext;
using MiniProject.Models.Entities;
using MiniProject.Models.Menu;

namespace MiniProject
{
    internal class Program
    {
        static TurboDbContext Db = new TurboDbContext();


        static void Main(string[] args)
        {
            int menuOption;
            do
            {
                Console.WriteLine("1 - Add a brand");
                Console.WriteLine("2 - Delete a brand");
                Console.WriteLine("3 - Show all brands");
                Console.WriteLine("4 - Find a brand by ID");
                Console.WriteLine("5 - Edit a brand");

                Console.WriteLine("\n");

                Console.WriteLine("6 - Add a model");
                Console.WriteLine("7 - Delete a model");
                Console.WriteLine("8 - Show all models");
                Console.WriteLine("9 - Find a model by ID");
                Console.WriteLine("10 - Edit a model");

                Console.WriteLine("\n");

                Console.WriteLine("11 - Add an announcement");
                Console.WriteLine("12 - Delete an announcement");
                Console.WriteLine("13 - Show all announcements");
                Console.WriteLine("14 - Find an announcement by ID");
                Console.WriteLine("15 - Edit an announcement");



                menuOption = Helper.ReadInt("\nChoose an option from the list:", "There is no such option on the list!");
                switch (menuOption)
                {
                    case 1:
                        AddNewBrand();
                        break;
                    case 2:
                        DeleteBrand();
                        break;
                    case 3:
                        GetAllBrand();
                        break;
                    case 4:
                        GetBrandById();
                        break;
                    case 5:
                        EditBrand();
                        break;
                    case 6:
                        AddNewModel();
                        break;
                    case 7:
                        DeleteModel();
                        break;
                    case 8:
                        GetAllModels();
                        break;
                    case 9:
                        GetModelById();
                        break;
                    case 10:
                        EditModel();
                        break;
                    case 11:
                        AddNewAnnouncement();
                        break;
                    case 12:
                        DeleteAnnouncement();
                        break;
                    case 13:
                        GetAllAnnouncements();
                        break;
                    case 14:
                        GetAnnouncementById();
                        break;
                    case 15:
                        EditAnnouncement();
                        break;

                }


            } while (true);
        }



        private static void GetAnnouncementById()
        {
            int announcementId;
        l1:
            announcementId = Helper.ReadInt("Enter the ID of the announcement that you want to find: ", "Not correct!");
            Announcement announcements = Db.announcements.FirstOrDefault(m => m.Id == announcementId);

            if (announcements == null)
            {
                Console.WriteLine("The announcment with that ID does not exist.Please,try again!");
                goto l1;
            }
            Console.WriteLine($"ID-{announcements.Id}\nPrice-{announcements.Price}\nYear-{announcements.Year}\nMarch-{announcements.March}\nFuel type-{announcements.fuelTypes}\nCategory-{announcements.categories}\nGear box-{announcements.gears}\nTransmission-{announcements.transmissions}\n");

        }

        private static void GetAllAnnouncements()
        {
            if (!Db.announcements.Any())
            {
                Console.WriteLine("The announcement list is empty!");
                return;
            }
            foreach (var item in Db.announcements)
            {
                Console.WriteLine($"ID-{item.Id}\nPrice-{item.Price}\nYear-{item.Year}\nMileage-{item.March}\nFuel type-{item.fuelTypes}\nCategory-{item.categories}\nGear box-{item.gears}\nTransmission-{item.transmissions}");
            }
            Console.WriteLine("\n");
        }

        private static void DeleteAnnouncement()
        {
            if (!Db.announcements.Any())
            {
                Console.WriteLine("No announcements exist.");
                return; 
            }

            foreach (var item in Db.announcements)
            {
                Console.WriteLine($"ID-{item.Id}\nPrice-{item.Price}\nYear-{item.Year}\nMileage-{item.March}\nFuel type-{item.fuelTypes}\nCategory-{item.categories}\nGear box-{item.gears}\nTransmission-{item.transmissions}");
            }

            int announcementId = Helper.ReadInt("Enter the ID of the announcement:", "Not correct");

            Announcement announcement = Db.announcements.FirstOrDefault(x => x.Id == announcementId);

                announcement.DeletedAt = DateTime.Now;
                announcement.DeletedBy = 0;

                Db.announcements.Remove(announcement);
                Db.SaveChanges();

                Console.WriteLine("Announcement deleted successfully.");
            
        }

        private static void AddNewAnnouncement()
        {
            int modelId;

            decimal price;
            int march;
            int year;
            int categories;
            int fuelTypes;
            int transmissions;
            int gears;

            
            Console.WriteLine("Choose one of the models to create an announcement: ");
            foreach (var item in Db.models.Include(m=>m.Brand).ToList())
            {
                Console.WriteLine($"\nID-{item.Id},Name-{item.Name},Brand-{item.Brand.Name}");
            }
        l1:
            modelId = Helper.ReadInt("Insert the ID of the model: ", "Not correct");
            Model model = Db.models.FirstOrDefault(x => x.Id == modelId);
            if (model == null)
            {
                Console.WriteLine("There is no model like that.");
                goto l1;
            }
        l2:
            price = Helper.ReadDecimal("Enter the price: ", "Not correct");
            if (price <= 500)
            {
                Console.WriteLine("The price cannot be lesser than 500!");
                goto l2;
            }
        l3:
            march = Helper.ReadInt("Insert the march:", "Not correct");
            if (march < 0)
            {
                Console.WriteLine("The march cannot be lesser than 0!");
                goto l3;
            }
        l7:
            year = Helper.ReadInt("Insert the year:", "Not correct");
            if (year < 1770)
            {
                Console.WriteLine("The year cannot be lesser than the minimum!");
                goto l3;
            }
            foreach (var item in Enum.GetValues(typeof(FuelTypes)))
            {
                Console.WriteLine($"{(int)item}-{item}");
            }
            FuelTypes fuelType;
        l4:
            fuelTypes = Helper.ReadInt("Choose the fuel type: ", "Not correct!");

            if (Enum.IsDefined(typeof(FuelTypes), fuelTypes))
            {
                fuelType = (FuelTypes)fuelTypes;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
                goto l4;
            }
            Categories category;
        l5:

            foreach (var item in Enum.GetValues(typeof(Categories)))
            {
                Console.WriteLine($"{(int)item}-{item}");
            }
            categories = Helper.ReadInt("Choose the category: ", "Not correct");
            if (Enum.IsDefined(typeof(Categories), categories))
            {
                category = (Categories)categories;
            }
            else
            {
                Console.WriteLine("Option like that does not exist.Please try again!");
                goto l5;
            }
        l6:
            Gears gearBox;
            foreach (var item in Enum.GetValues(typeof(Gears)))
            {
                Console.WriteLine($"{(int)item}-{item}");
            }
            gears = Helper.ReadInt("Choose the gear box:", "Not correct");
            if (Enum.IsDefined(typeof(Gears), gears))
            {
                gearBox = (Gears)gears;
            }
            else
            {
                Console.WriteLine("Option like that does not exist.Please try again!");
                goto l6;
            }
        lT:
            Transmissions transmission;
            foreach (var item in Enum.GetValues(typeof(Transmissions)))
            {
                Console.WriteLine($"{(int)item}-{item}");
            }
            transmissions = Helper.ReadInt("Choose the transmission:", "Not correct");
            if (Enum.IsDefined(typeof(Transmissions), transmissions))
            {
                transmission = (Transmissions)transmissions;
            }
            else
            {
                Console.WriteLine("Option like that does not exist.Please try again!");
                goto lT;
            }
            Announcement announcements = new Announcement();
           
            announcements.Price = price;
            announcements.Year = year;
            announcements.March = march;
            announcements.fuelTypes = fuelType;
            announcements.categories = category;
            announcements.gears = gearBox;
            announcements.transmissions = transmission;
            announcements.Model = model;

            Db.announcements.Add(announcements);
            announcements.CreatedAt= DateTime.Now;
            announcements.CreatedBy = 0;
            Db.SaveChanges();

        }

        private static void EditModel()
        {
            int modelId;
            foreach (var item in Db.models)
            {
                Console.WriteLine($"\nID-{item.Id},Name-{item.Name},Brand-{item.Brand}\n");
            }
        l1:
            modelId = Helper.ReadInt("Enter the ID of the model that you want to change:", "Not correct!");
            Model model = Db.models.FirstOrDefault(m => m.Id == modelId);
            if (model != null)
            {
                Console.WriteLine($"{modelId} is not found");
                goto l1;
            }
            string newModelName = Helper.ReadString("Enter the new name of the model: ", "Not correct!");
            model.Name = newModelName;
            model.LastModifiedAt = DateTime.Now; 
            model.LastModifiedBy =0;
            Db.SaveChanges();
            Console.WriteLine("\nChanges have been made!\n");
        }

        private static void GetModelById()
        {
            int modelId;
        l1:
            modelId = Helper.ReadInt("Enter the ID of the model that you want to find:", "Not correct!");

            Model model = Db.models.FirstOrDefault(x => x.Id == modelId);

            if (model == null)
            {
                Console.WriteLine("The model with this ID is not found!");
                goto l1;
            }
            Console.WriteLine($"ID-{model.Id},Name-{model.Name},Brand-{model.Brand}  \n");
        }

        private static void GetAllModels()
        {
            if (!Db.models.Any())
            {
                Console.WriteLine("The model list is empty!");
                return;
            }

            foreach (var item in Db.models)
            {
                Console.WriteLine($"ID-{item.Id}, Name-{item.Name}, Brand-{item.Brand.Name}");
            }
            Console.WriteLine("\n");
        }

        private static void DeleteModel()
        {
        l1:
            if (!Db.models.Any())
            {
                Console.WriteLine("Nonexistend model! ");
            }
            foreach (var item in Db.models)
            {
                Console.WriteLine($"ID-{item.Id},Name-{item.Name},Brand-{item.Brand}\n");
            }
            int modelId = Helper.ReadInt("Enter the ID of the model", "Not correct");
            Model model = Db.models.FirstOrDefault(x => x.Id == modelId);
            if (model != null)
            {
                Console.WriteLine($"{modelId} is not found");
                goto l1;
            }
            Db.models.Remove(model);
            model.DeletedAt = DateTime.Now;
            model.DeletedBy = 0;
            Db.SaveChanges();
            Console.WriteLine("The model has been removed!");
        }

        private static void AddNewModel()
        {
            string modelName;
            if (!Db.brands.Any())
            {
                Console.WriteLine("The brand list is empty!");
                return;
            }
            modelName = Helper.ReadString("Enter the name of the model:", "Not correct!");
            int brandId;
            foreach (Brand item in Db.brands)
            {
                Console.WriteLine($"ID-{item.Id},Name-{item.Name}");
            }
        l1:
            brandId = Helper.ReadInt("Choose the ID of the brand:", "Not correct!");
            Brand brand = Db.brands.FirstOrDefault(m => m.Id == brandId);
            if (brand == null)
            {
                Console.WriteLine("The ID is incorrect!");
                goto l1;
            }
            Model model = new Model();
            model.Brand = brand;
            model.Name = modelName;

            Db.models.Add(model);
            model.CreatedAt = DateTime.Now;
            model.CreatedBy = 0;
            Db.SaveChanges();
            Console.WriteLine("The model has been added!  \n");
        }

        private static void EditBrand()
        {
            int brandId;
            foreach (Brand item in Db.brands)
            {
                Console.WriteLine($"ID - {item.Id}, Name - {item.Name}");
            }
        l1:
            brandId = Helper.ReadInt("Enter the ID of the brand that you want to change: ", "Not correct!");
            Brand brand = Db.brands.FirstOrDefault(m => m.Id == brandId);
            if (brand is null)
            {
                Console.WriteLine($"{brandId} is not found");
                goto l1;

            }

            string newBrandName = Helper.ReadString("Enter the new name of the brand:", "Not correct");
            brand.Name = newBrandName;
            brand.LastModifiedAt = DateTime.Now;
            brand.LastModifiedBy = 0;
            Db.SaveChanges();
            Console.WriteLine("Changes have been made! \n");
        }

        private static void GetBrandById()
        {
            int brandId = Helper.ReadInt("Enter the ID of the brand:", "Not correct");
            Brand brand = Db.brands.FirstOrDefault(m => m.Id == brandId);
            if (brand is null)
            {
                Console.WriteLine($"{brandId} is not found");
            }
            else
            {
                Console.WriteLine($"Id - {brand.Id} Name - {brand.Name} \n");
            }

        }

        private static void GetAllBrand()
        {
            if (Db.brands.Any())
            {
                foreach (var item in Db.brands)
                {
                    Console.WriteLine($"ID:{item.Id},Name:{item.Name}");
                }
            }
            else
            {
                Console.WriteLine("The brand list is empty!");
            }
        }

        private static void DeleteBrand()
        {
            foreach (var item in Db.brands)
            {
                Console.WriteLine($"ID-{item.Id},Name-{item.Name}");
            }

            if (!Db.brands.Any())
            {
                Console.WriteLine("Nonexistend brand!");
                return;
            }

        l1:
            int brandId = Helper.ReadInt("Enter the ID of the brand:", "Not correct");
            Brand brand = Db.brands.FirstOrDefault(m => m.Id == brandId);
            if (brand is null)
            {
                Console.WriteLine($"{brandId} is not found");
                goto l1;
            }

            Db.brands.Remove(brand);
            brand.DeletedAt = DateTime.Now;
            brand.DeletedBy = 0;
            Db.SaveChanges();
            Console.WriteLine("Deleted! \n");
        }

        private static void AddNewBrand()
        {
            string brandName;
        l1:
            brandName = Helper.ReadString("Enter the name of the brand: ", "Not correct!");

            if (string.IsNullOrWhiteSpace(brandName) || brandName.Length < 3)
            {
                Console.WriteLine("Empty space or a name that has less than 2 letters is not allowed!");
                goto l1;
            }

            Brand brand = new Brand()
            {
                Name = brandName,
            };

            Db.brands.Add(brand);
            brand.CreatedAt = DateTime.Now;
            brand.CreatedBy = 0;
            Db.SaveChanges();
            Console.WriteLine("Sucessfully added! \n");
        }

        private static void EditAnnouncement()
        {
            var allAnnouncements = Db.announcements.ToList();
            foreach (var item in allAnnouncements)
            {
                Console.WriteLine($"ID-{item.Id}\nPrice-{item.Price}\nYear-{item.Year}\nMileage-{item.March}\nFuel type-{item.fuelTypes}\nCategory-{item.categories}\nGear box-{item.gears}\nTransmission-{item.transmissions}");
            l1:
                int announcementId;
           
                announcementId = Helper.ReadInt("Enter the ID of the announcement that you want to change: ", "Not correct!");
                Announcement announcements = Db.announcements.FirstOrDefault(m => m.Id == announcementId);

                if (announcements == null)
                {
                    Console.WriteLine("There is no such announcement under that ID. Please try again!");
                    goto l1;
                }

                if (announcements == null)
                {
                    Console.WriteLine("There is no such announcement under that ID.Please,try again!");
                    goto l1;
                }
                decimal newPrice = Helper.ReadDecimal("Please enter the new price: ", "Not correct!");
                announcements.Price = newPrice;

                int newYear = Helper.ReadInt("Please enter the new year: ", "Not correct!");
                announcements.Year = newYear;

                int newMarch = Helper.ReadInt("Please enter the new mileage: ", "Not correct!");
                announcements.March = newMarch;


                foreach (var fuel in Enum.GetValues(typeof(FuelTypes)))
                {
                    Console.WriteLine($"{(int)fuel}-{fuel}");
                }

                int newFuelType = Helper.ReadInt("Choose the fuel type: ", "Not correct!");

                announcements.fuelTypes = (FuelTypes)newFuelType;


                foreach (var categori in Enum.GetValues(typeof(Categories)))
                {
                    Console.WriteLine($"{(int)categori}-{categori}");
                }
                int newCategory = Helper.ReadInt("Choose the category: ", "Not correct!");

                announcements.categories = (Categories)newCategory;


                foreach (var gear in Enum.GetValues(typeof(Gears)))
                {
                    Console.WriteLine($"{(int)gear}-{gear}");
                }
                int newGearBox = Helper.ReadInt("Choose the gear box: ", "Not correct!");
                announcements.gears = (Gears)newGearBox;

                foreach (var transmission in Enum.GetValues(typeof(Transmissions)))
                {
                    Console.WriteLine($"{(int)transmission}-{transmission}");
                }
                int newTransmission = Helper.ReadInt("Choose the transmission: ", "Not correct!");
                announcements.transmissions = (Transmissions)newTransmission;
                announcements.LastModifiedAt= DateTime.Now;
                announcements.LastModifiedBy = 0;
                Db.SaveChanges();
                Console.WriteLine("Changes have been made!\n");



            }

        }
    }
}
