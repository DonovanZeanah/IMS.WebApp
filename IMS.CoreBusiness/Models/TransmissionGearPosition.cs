using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.CoreBusiness.Models
{
    public class GearPosition
    {
        public static GearPosition Neutral = new GearPosition(0);
        public static GearPosition Drive = new GearPosition(1);
        public static GearPosition Reverse = new GearPosition(-1);
        public static GearPosition Park = new GearPosition(2);

        private int _position;

        private GearPosition(int position)
        {
            _position = position;
        }

        public int Position
        {
            get { return _position; }
        }
        public static bool isParked { get; internal set; }
       /* public static bool isDrive
        public int Position { get; set; }
        public static object Park { get; internal set; }
        public static object Drive { get; internal set; }*/
        // Other properties and methods...
    }
}
