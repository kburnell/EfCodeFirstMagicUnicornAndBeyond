using System.Data.Entity;
using Demo1.DataContext;

namespace Demo1.Tests.Integration.DataContext
{
    public class TestDataContextInitializer : DropCreateDatabaseIfModelChanges<Demo1DataContext>
    {
    }
}
