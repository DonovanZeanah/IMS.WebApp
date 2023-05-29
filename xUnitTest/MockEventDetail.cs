using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Plugins.xUnitTests
{
    public class MockEventDetail
    {
        public int EventID { get; set; }
        public string StageType { get; set; }
        public int PriorityLevel { get; set; }
        public string ErrorNotes { get; set; }
    }
}
