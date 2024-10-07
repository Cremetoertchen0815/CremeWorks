using Microsoft.EntityFrameworkCore;

namespace CremeWorks.Backend;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
}
