using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.CoreBusiness.Models
{
    public class Configuration
    {
        private readonly Dictionary<string, string> _settings;

        public Configuration()
        {
            _settings = new Dictionary<string, string>();
        }

        public void Set(string key, string value)
        {
            _settings[key] = value;
        }

        public string Get(string key)
        {
            return _settings.ContainsKey(key) ? _settings[key] : null;
        }
    }

}
