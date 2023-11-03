using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USQLCSharpProject1
{
    public class reader
    {
        public string name { get; set; }
        public string num { get; set; }
        public List<book> listbook { get; set; }

        public reader()
        {
            listbook = new List<book>();
        }
    }
}
