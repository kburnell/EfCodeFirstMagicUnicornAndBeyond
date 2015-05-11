using System.Data.Entity;

namespace Demo1.DataContext {

    public class DataContextInitializer : DropCreateDatabaseIfModelChanges<Demo1DataContext> {}
}