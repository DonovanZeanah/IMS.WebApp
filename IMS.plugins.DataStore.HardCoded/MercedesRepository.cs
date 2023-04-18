using IMS.CoreBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.UseCases.PluginInterfaces.DataStore;
using static System.Net.Mime.MediaTypeNames;

namespace IMS.plugins.DataStore.HardCoded
{
    public class MercedesRepository : IMercedesRepository
    { 
        
        private List<Mercede> _mercedes; // = new List<Mercedes>()

            public MercedesRepository()
            {
                
                _mercedes = new List<Mercede>()
                {
                    new Mercede() { Id = 1, Year = 2024, Make = "Mercedes1",   Name = "", Model = "S-Class", Description = "", SoftwareVersion = "", Camera = null, HeadUnit = null, Tests = new List<Test> { new Test { Type = TestType.Test1, Date = DateTime.Now } } },
                    new Mercede() { Id = 10, Year = 2024, Make = "Mercedes2",  Name = "",Model = "S-Class", Description = "", SoftwareVersion = "", Camera = null, HeadUnit = null, Tests = new List<Test> { new Test { Type = TestType.Test1, Date = DateTime.Now } } },
                    new Mercede() { Id = 11, Year = 2024, Make = "Mercedes3",  Name = "" ,Model = "E-Class", Description = "", SoftwareVersion = "", Camera = null, HeadUnit = null, Tests = new List<Test> { new Test { Type = TestType.Test2, Date = DateTime.Now } } },
                    new Mercede() { Id = 12, Year = 2024, Make = "Mercedes4",  Name = "" ,Model = "C-Class", Description = "", SoftwareVersion = "", Camera = null, HeadUnit = null, Tests = new List<Test> { new Test { Type = TestType.Test3, Date = DateTime.Now } } },
                    new Mercede() { Id = 13, Year = 2024, Make = "Mercedes5",  Name = "" ,Model = "S-Class", Description = "", SoftwareVersion = "", Camera = null, HeadUnit = null, Tests = new List<Test> { new Test { Type = TestType.Test3, Date = DateTime.Now } } },
                    new Mercede() { Id = 14, Year = 2024, Make = "Mercedes6",  Name = "" ,Model = "E-Class", Description = "", SoftwareVersion = "", Camera = null, HeadUnit = null, Tests = new List<Test> { new Test { Type = TestType.Test2, Date = DateTime.Now } } },
                    new Mercede() { Id = 15, Year = 2024, Make = "Mercedes7",  Name = "" ,Model = "C-Class", Description = "", SoftwareVersion = "", Camera = null, HeadUnit = null, Tests = new List<Test> { new Test { Type = TestType.Test1, Date = DateTime.Now } } },
                    new Mercede() { Id = 16, Year = 2024, Make = "Mercedes8",  Name = "" ,Model = "T-Class", Description = "", SoftwareVersion = "", Camera = null, HeadUnit = null, Tests = new List<Test> { new Test { Type = TestType.Test1, Date = DateTime.Now } } },
                    new Mercede() {Id = 9, Year = 2022, Make = "Mercedes9",    Name = "" ,Model = "S-Class", Description = "", SoftwareVersion = "", Camera = null, HeadUnit = null, Tests = new List<Test> { new Test { Type = TestType.Test1, Date = DateTime.Now } } },
                    new Mercede() {Id = 2, Year = 2023, Make = "Mercedes",     Name = "" ,Model = "E-Class", Description = "", SoftwareVersion = "", Camera = null, HeadUnit = null, Tests = new List<Test> { new Test { Type = TestType.Test2, Date = DateTime.Now } } },
                    new Mercede() {Id = 3, Year = 2024, Make = "Mercedes",     Name = "" ,Model = "C-Class", Description = "", SoftwareVersion = "", Camera = null, HeadUnit = null, Tests = new List<Test> { new Test { Type = TestType.Test3, Date = DateTime.Now } } },
                    new Mercede() {Id = 4, Year = 2022, Make = "Mercedes",     Name = "" ,Model = "GLS", Description = "", SoftwareVersion = "", Camera = null, HeadUnit = null, Tests = new List<Test> { new Test { Type = TestType.Test1, Date = DateTime.Now } } },
                    new Mercede() {Id = 5, Year = 2023, Make = "Mercedes",     Name = "" ,Model = "GLE", Description = "", SoftwareVersion = "", Camera = null, HeadUnit = null, Tests = new List<Test> { new Test { Type = TestType.Test2, Date = DateTime.Now } } },
                    new Mercede() {Id = 6, Year = 2024, Make = "Mercedes",     Name = "" ,Model = "GLC", Description = "", SoftwareVersion = "", Camera = null, HeadUnit = null, Tests = new List<Test> { new Test { Type = TestType.Test3, Date = DateTime.Now } } },
                    new Mercede() {Id = 7, Year = 2022, Make = "Mercedes",     Name = "" ,Model = "A-Class", Description = "", SoftwareVersion = "", Camera = null, HeadUnit = null, Tests = new List<Test> { new Test { Type = TestType.Test1, Date = DateTime.Now } } },
                    new Mercede() {Id = 8, Year = 2023, Make = "Mercedes",     Name = "" ,Model = "B-Class", Description = "", SoftwareVersion = "", Camera = null, HeadUnit = null, Tests = new List<Test> { new Test { Type = TestType.Test2, Date = DateTime.Now } } },
                    new Mercede() {Id = 17, Year = 2022, Make = "Mercedes",    Name = "" ,Model = "S-Class", Description = "", SoftwareVersion = "", Camera = null, HeadUnit = null, Tests = new List<Test> { new Test { Type = TestType.Test1, Date = DateTime.Now } } },
                    new Mercede() {Id = 18, Year = 2023, Make = "Mercedes",    Name = "" ,Model = "E-Class", Description = "", SoftwareVersion = "", Camera = null, HeadUnit = null, Tests = new List<Test> { new Test { Type = TestType.Test2, Date = DateTime.Now } } },
                    new Mercede() {Id = 19, Year = 2024, Make = "Mercedes",    Name = "" ,Model = "C-Class", Description = "", SoftwareVersion = "", Camera = null, HeadUnit = null, Tests = new List<Test> { new Test { Type = TestType.Test3, Date = DateTime.Now } } },
                    new Mercede() {Id = 20, Year = 2022, Make = "Mercedes",    Name = "" ,Model = "GLS", Description = "", SoftwareVersion = "", Camera = null, HeadUnit = null, Tests = new List<Test> { new Test { Type = TestType.Test1, Date = DateTime.Now } } },
                };
            }                                       // Constructor        - // Construct 20 Hard Coded Instances of Mercedes Class
            public static void GetMercedesList()
            {
                var mercedesList = new List<Mercede>
                {
                new Mercede {Id = 21, Year = 2022, Make = "Mercedes", Model = "S-Class", Description = "", SoftwareVersion = "", Camera = null, HeadUnit = null, Tests = new List<Test> { new Test { Type = TestType.Test1, Date = DateTime.Now } } },
                new Mercede {Id = 22, Year = 2023, Make = "Mercedes", Model = "E-Class", Description = "", SoftwareVersion = "", Camera = null, HeadUnit = null, Tests = new List<Test> { new Test { Type = TestType.Test2, Date = DateTime.Now } } },
                new Mercede {Id = 23, Year = 2024, Make = "Mercedes", Model = "C-Class", Description = "", SoftwareVersion = "", Camera = null, HeadUnit = null, Tests = new List<Test> { new Test { Type = TestType.Test3, Date = DateTime.Now } } },
                new Mercede {Id = 24, Year = 2022, Make = "Mercedes", Model = "GLS", Description = "", SoftwareVersion = "", Camera = null, HeadUnit = null, Tests = new List<Test> { new Test { Type = TestType.Test1, Date = DateTime.Now } } },
                new Mercede {Id = 25, Year = 2023, Make = "Mercedes", Model = "GLE", Description = "", SoftwareVersion = "", Camera = null, HeadUnit = null, Tests = new List<Test> { new Test { Type = TestType.Test2, Date = DateTime.Now } } },
                new Mercede {Id = 26, Year = 2024, Make = "Mercedes", Model = "GLC", Description = "", SoftwareVersion = "", Camera = null, HeadUnit = null, Tests = new List<Test> { new Test { Type = TestType.Test3, Date = DateTime.Now } } },
                new Mercede {Id = 27, Year = 2022, Make = "Mercedes", Model = "A-Class", Description = "", SoftwareVersion = "", Camera = null, HeadUnit = null, Tests = new List<Test> { new Test { Type = TestType.Test1, Date = DateTime.Now } } },
                new Mercede {Id = 28, Year = 2023, Make = "Mercedes", Model = "B-Class", Description = "", SoftwareVersion = "", Camera = null, HeadUnit = null, Tests = new List<Test> { new Test { Type = TestType.Test2, Date = DateTime.Now } } },
                };
        }                              // GetMercedesList()  - // Static Method to Construct 8 Hard Coded Instances of Mercedes Class


            public Mercede GetMercede(int id)
            {
                return _mercedes.FirstOrDefault(x => x.Id == id);
            }                                    // GetMercede()       - // Get Mercedes by Id
            public IEnumerable<Mercede> GetMercedes(string filter = null)
            {
                if (string.IsNullOrWhiteSpace(filter)) return _mercedes;

                return _mercedes.Where(x => x.Name.ToLower().Contains(filter.ToLower())); //|| x.Model.Contains(filter));
            }    // GetMercedes()      - // Get Mercedes by Filter (Name)
    }
}

 