using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.CoreBusiness.Models.Enums;

namespace IMS.CoreBusiness.Models
{
    public class CarTestResult
    {
        public CarTestResult(CarTestType type, bool passed)
        {
            Type = type;
            Passed = passed;
        }

        public CarTestType Type { get; set; }
        public bool Passed { get; set; }
    }
}
