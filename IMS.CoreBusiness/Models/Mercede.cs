using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.CoreBusiness.Models
{
    public enum TestType
    {
        Test1,
        Test2,
        Test3,
        Test4,
        Test5,
        Test6,
        Test7,
        Test8,
        Test9,
        Test10
    }
    public class Test
    {
        public TestType Type { get; set; }
        public DateTime Date { get; set; }
    }
    public class Mercede
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? VIN { get; set; }

        public int Year { get; set; }

        public string Make { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public string SoftwareVersion { get; set; }
        public Camera? Camera { get; set; }
        public HeadUnit? HeadUnit { get; set; }
        public List<Test>? Tests { get; set; }

       /* public Mercede()
        {

            Name = $"{Make} {Model} {Year}"; // Set name to make, model, and year
            Description = "";
            SoftwareVersion = "";
            Camera = null;
            HeadUnit = null;
            Tests = new List<Test>();

            // Add initial test with current date and time
            Test initialTest = new Test { Type = TestType.Test1, Date = DateTime.Now };
            Tests.Add(initialTest);
        }*/

        // public List<TestType> Tests { get; set; }

        // public Mercedes()
        //{
        //    Tests = new List<TestType>();
        //}

        /*
        Mercedes myCar = new Mercedes();
        myCar.Tests.Add(TestType.Test1);
        myCar.Tests.Add(TestType.Test2);
        */

    }
    public class Camera
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        // other properties specific to a camera
    }

    public class HeadUnit
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        // other properties specific to a head unit
    }
}
