using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODO
{
    internal class Todo
    {
        public int id { get; set; }
        public int userId { get; set; }
        public string title { get; set; }
        public bool completed { get; set; }
    }
}
