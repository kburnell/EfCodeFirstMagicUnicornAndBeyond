using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace EF6_Beta_Demo_Tests_Unit {

    public abstract class MockableDbSet<T> : DbSet<T>, IQueryable<T> where T : class {
        public abstract IEnumerator<T> GetEnumerator();
        public abstract Expression Expression { get; }
        public abstract Type ElementType { get; }
        public abstract IQueryProvider Provider { get; }
    }
}