using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfazApi
{
    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public string url_image { get; set; }
        public List<Model> models { get; set; }
    }
}
