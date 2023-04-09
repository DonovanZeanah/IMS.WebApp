using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.CoreBusiness.Models
{
    public class File
    {
        public static string Read(string path)
        {
            return System.IO.File.ReadAllText(path);
        }

        public static void Write(string path, string content)
        {
            System.IO.File.WriteAllText(path, content);
        }

        public static bool Exists(string path)
        {
            return System.IO.File.Exists(path);
        }
    }
}
