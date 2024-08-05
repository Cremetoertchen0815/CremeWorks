using CremeWorks.App.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CremeWorks.App;
public interface IDataParent
{
    public Database Database { get; }
}
