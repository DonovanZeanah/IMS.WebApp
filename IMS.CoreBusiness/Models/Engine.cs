using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.CoreBusiness.Models
{
    public class Engine
    {
        private bool _isRunning;
        private int _oilLevel;

        public void Start()
        {
            // Code to start the engine...
            _isRunning = true;
        }

        public void Stop()
        {
            // Code to stop the engine...
            _isRunning = false;
        }

        public int OilLevel
        {
            get { return _oilLevel; }
            set { _oilLevel = value; }
        }
    }
}
