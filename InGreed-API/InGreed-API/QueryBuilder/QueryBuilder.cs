using System.Linq.Expressions;

namespace InGreed_API.QueryBuilder
{
    public class QueryBuilder<T>
    {
        private IQueryable<T> query;

        public QueryBuilder(IQueryable<T> initialQuery)
        {
            query = initialQuery;
        }

        public void Filter(Expression<Func<T, bool>> filter)
        {
            query = query.Where(filter);
        }

        public void Sort<TKey>(Expression<Func<T, TKey>> keySelector, bool ascending)
        {
            query = ascending ? query.OrderBy(keySelector) : query.OrderByDescending(keySelector);
        }

        public void Paginate(int pageSize, int pageNumber)
        {
            query = query.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        }

        public void Contact(IQueryable<T> query)
        {
            this.query = this.query.Concat(query);
        }

        public IQueryable<T> Build()
        {
            return query;
        }

        public IQueryable<TResult> BuildWithSelect<TResult>(Expression<Func<T, TResult>> selector)
        {
            return query.Select(selector);
        }
    }
}
