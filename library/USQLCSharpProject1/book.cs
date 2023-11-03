using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USQLCSharpProject1
{
    public class book
    {
        public int art { get; set; }
        public string author { get; set; }
        public string naming { get; set; }
        public int year { get; set; }
        public int colv { get; set; }
        public book(int art, string author, string naming, int year, int colv)
        {
            this.art = art;
            this.author = author;
            this.naming = naming;
            this.year = year;
            this.colv = colv;
        }
    }

}
