using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.CoreBusiness.Models.Enums;

namespace IMS.CoreBusiness.Models
{
    public partial class Car
    {
        private Engine _engine;
        private Transmission _transmission;
        private Wheel[] _wheels;
        //private Maintenance _maintenance;
        private List<EngineNote> _engineNotes;
        private List<TransmissionNote> _transmissionNotes;
        private List<WheelNote> _wheelNotes;

        public Car()
        {
            _engine = new Engine();
            _transmission = new Transmission();
            _wheels = new Wheel[4];
            //_maintenance = new Extra.Car.Maintenance();
            _engineNotes = new List<EngineNote>();
            _transmissionNotes = new List<TransmissionNote>();
            _wheelNotes = new List<WheelNote>();
            for (int i = 0; i < _wheels.Length; i++)
            {
                _wheels[i] = new Wheel(100.00, CarTireType.AllTerrain);
            }
        }

        public void Start()
        {
            _engine.Start();
            _transmission.ShiftGear(GearPosition.Drive);
        }

        public void Stop()
        {
            _transmission.ShiftGear(GearPosition.Park);
            _engine.Stop();
        }

        /* public Maintenance Maintenance
         {
             get { return _maintenance; }
         }
 
         public List<EngineNote> EngineNotes
         {
             get { return _engineNotes; }
         }
 
         public List<TransmissionNote> TransmissionNotes
         {
             get { return _transmissionNotes; }
         }
 
         public List<WheelNote> WheelNotes
         {
             get { return _wheelNotes; }
         }
 
         public class Maintenance
         {
             private List<CarTestResult> _tests;
             private List<Deficiency> _deficiencies;
             private TimeSpan _timeWorked;
 
             public Maintenance()
             {
                 _tests = new List<CarTestResult>();
                 _deficiencies = new List<Deficiency>();
                 _timeWorked = TimeSpan.Zero;
             }
 
             // ...
         }
 
         // ...
     }*/

        public class EngineNote : Note
        {
            // Additional properties or methods specific to Engine notes...
        }

        public class TransmissionNote : Note
        {
            // Additional properties or methods specific to Transmission notes...
        }

        public class WheelNote : Note
        {
            // Additional properties or methods specific to Wheel notes...
        }

    }
}
