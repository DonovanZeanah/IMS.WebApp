using System.ComponentModel.DataAnnotations;
using System.Reflection.PortableExecutable;

namespace IMS.Plugins.SQLite
{
    public class Accessory
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Type { get; set; } 
        public double Version { get; set; }
    }
}