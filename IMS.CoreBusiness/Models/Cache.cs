using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.CoreBusiness.Models
{
    public class Cache
    {
        private readonly Dictionary<string, object> _cache;

        public Cache()
        {
            _cache = new Dictionary<string, object>();
        }

        public void Add(string key, object value)
        {
            _cache[key] = value;
        }

        public object Get(string key)
        {
            return _cache.ContainsKey(key) ? _cache[key] : null;
        }
    }

}
