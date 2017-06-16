using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Dialogue
{
    public class Initialization
    {
        public int prot = int.Parse(ConfigurationManager.AppSettings["prot"]);
        public string host = ConfigurationManager.AppSettings["host"];
    }
}
