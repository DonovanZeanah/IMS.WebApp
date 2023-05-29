using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.Plugins.xUnitTests;
using xUnitTests;

namespace xUnitTests.Services
{
    public class MockReportService
    {
        public Task<List<MockEventDetail>> GetTestDriveErrorsAsync()
        {
            return Task.FromResult(new List<MockEventDetail>
        {
            new MockEventDetail { EventID = 1, StageType = "Test", PriorityLevel = 1, ErrorNotes = "Error 1" },
            new MockEventDetail { EventID = 2, StageType = "Test", PriorityLevel = 2, ErrorNotes = "Error 2" },
            // ... add more mock data here ...
        });
        }
    }

}
