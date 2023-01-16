using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_DAL.Entities
{
    class Spectacle
    {
        // INTEGER
        public int id { get; set; }
        //NVARCHAR(50)
        public string nom { get; set; }
        //NVARCHAR(MAX)
        public string description { get; set; }
    }
}
