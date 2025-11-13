using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.data
{
   
    public class User
    {
        public long Id { get; set; }            // 用 long 對上 SQLite 的 Int64
        public string Name { get; set; } = "";
    }

}
