using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.CoreBusiness.Models
{
    public class Transmission
    {
        private GearPosition _currentGear;

        public void ShiftGear(GearPosition gear)
        {
            // Code to shift the gear...
            _currentGear = gear;
        }

        public GearPosition CurrentGear
        {
            get { return _currentGear; }
        }
    }
}
