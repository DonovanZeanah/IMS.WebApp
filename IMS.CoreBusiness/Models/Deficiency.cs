using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.CoreBusiness.Models
{
    public class Deficiency
    {
        public Deficiency(string description)
        {
            Description = description;
        }

        public string Description { get; set; }
    }
}
