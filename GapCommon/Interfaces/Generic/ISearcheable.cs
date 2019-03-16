using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GapCommon.Interfaces.Generic
{
    /// <summary>
    /// Interface to expand behavior search
    /// </summary>
    /// <typeparam name="T">the type to inherit</typeparam>
    public interface ISearcheable<T>
    {
        /// <summary>
        /// Method to search a list of entities
        /// </summary>
        /// <param name="expression">lamda expression to search</param>
        /// <param name="page">page for search default 1</param>
        /// <param name="size">size of page default 10</param>
        /// <returns></returns>
        List<T> Search(Expression<Func<T, bool>> expression, int page = 1, int size = 10);
    }
}