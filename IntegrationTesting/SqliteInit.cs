using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTesting
{
    public class SqliteInit
    {
        [ModuleInitializer]
        public static void Init() => Batteries_V2.Init();
    }
}
