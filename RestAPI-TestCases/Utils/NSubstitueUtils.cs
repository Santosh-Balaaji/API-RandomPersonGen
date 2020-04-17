using Microsoft.EntityFrameworkCore;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestAPI_TestCases.Utils
{
    //This class provides a mockDBSet by setting up IQueryable methods as a substitute for the actual DBSet using NSubstitute.
    public static class NSubstitueUtils
    {
        public static DbSet<T> CreateMockDbSet<T>(IEnumerable<T> data = null)
            where T : class
        {
            var mockSet = Substitute.For<DbSet<T>, IQueryable<T>>();
            if (data != null)
            {
                var queryable = data.AsQueryable();

                ((IQueryable<T>)mockSet).Provider.Returns(queryable.Provider);
                ((IQueryable<T>)mockSet).Expression.Returns(queryable.Expression);
                ((IQueryable<T>)mockSet).ElementType.Returns(queryable.ElementType);
                ((IQueryable<T>)mockSet).GetEnumerator().Returns(queryable.GetEnumerator());
            }
            return mockSet;
        }
    }
}
