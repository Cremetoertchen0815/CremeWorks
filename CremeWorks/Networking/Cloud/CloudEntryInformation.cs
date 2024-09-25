using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CremeWorks.App.Networking.Cloud;
public class CloudEntryInformation
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public DateTime LastTimeUpdated { get; set; }
    public int Hash { get; set; }
    public bool IsPublic { get; set; }
}
