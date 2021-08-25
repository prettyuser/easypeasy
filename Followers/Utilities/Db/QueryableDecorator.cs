using System.Linq;

namespace Utilities.Db
{ 
    public delegate IQueryable<T> QueryableDecorator<T>(IQueryable<T> query);
}
