using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CremeWorks.Common.Networking
{
    public class ConcertData
    {
        public ConcertData(string name, string[] setList)
        {
            this.name = name;
            this.setList = setList;
        }

        public string name { get; private set; }
        public string[] setList { get; private set; }
    }
}