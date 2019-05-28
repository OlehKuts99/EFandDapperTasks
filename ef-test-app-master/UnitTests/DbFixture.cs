using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence;

namespace UnitTests
{
  public class DbFixture
  {
    public DbFixture()
    {
      var serviceCollection = new ServiceCollection();
      serviceCollection.AddDbContext<OrderContext>(options =>
            options.UseInMemoryDatabase("TestingDB"));

      ServiceProvider = serviceCollection.BuildServiceProvider();
    }

    public ServiceProvider ServiceProvider { get; private set; }
  }
}
