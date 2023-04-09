using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.CoreBusiness.Models.Enums;

namespace IMS.CoreBusiness.Models.structs
{
    public struct CarTestResult
    {
        public CarTestType carTestType { get; }
        public bool Passed { get; }
        public string Notes { get; }

        public CarTestResult(CarTestType testType, bool passed, string notes)
        {
            carTestType = testType;
            Passed = passed;
            Notes = notes;
        }
    }
}
