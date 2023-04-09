using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using IMS.CoreBusiness.Models.Enums;

namespace IMS.CoreBusiness.Models
{
    public class Wheel
    {
        private double _pressure;
        private CarTireType _tireType;

        public Wheel(double pressure, CarTireType tireType)
        {
            _pressure = pressure;
            _tireType = tireType;
        }

        public void Inflate(int amount)
        {
            // Code to inflate the wheel...
            _pressure += amount;
        }

        public void Deflate(int amount)
        {
            // Code to deflate the wheel...
            _pressure -= amount;
        }

        public double Pressure
        {
            get { return _pressure; }
        }

        public CarTireType TireType
        {
            get { return _tireType; }
        }
    }
}
