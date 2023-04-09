using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.CoreBusiness.Models
{
    public class Note
    {
        private string _text;

        public void AddText(string text)
        {
            _text += text;
        }

        public string Text
        {
            get { return _text; }
        }

        public override string ToString()
        {
            return _text;
        }
    }
}
