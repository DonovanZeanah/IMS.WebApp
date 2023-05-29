using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.CoreBusiness.Models
{
    public class MockCar
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
    }


    
    public interface IMockCarService
    {
        Task<List<MockCar>> GetAllCars();
    }

    public class MockCarService : IMockCarService
    {
        public Task<List<MockCar>> GetAllCars()
        {
            var cars = new List<MockCar>
            {
                new MockCar { Id = 1, Make = "Toyota", Model = "Corolla", Year = 2020 },
                new MockCar { Id = 2, Make = "Honda", Model = "Civic", Year = 2019 },
                // Add more cars if needed
            };

            return Task.FromResult(cars);
        }
    }


}
